using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTemplate.App_LocalResources;
using webTemplate.Helpers;
using webTemplate.Model;
using webTemplate.Models.ViewModels;
using webTemplate.Models.ViewModels.User;
using webTemplate.Tools;
using webTemplate.Tools.Mail;

namespace webTemplate.Areas.Default.Controllers
{
    public class UserController : DefaultController
    {
        private static string AvatarFolder = "/Content/files/avatars/";

        private static string AvatarSize = "AvatarSize";

        public ActionResult Index(int id = 0)
        {
            if (id == 0)
            {
                if (CurrentUser != null)
                {
                    CurrentUser.CurrentLang = CurrentLangID;
                    return View(CurrentUser);
                }
                return RedirectToLoginPage;
            }
            var user = Repository.Users.FirstOrDefault(p => p.ID == id);
            if (user != null)
            {
                CurrentUser.CurrentLang = CurrentLangID;
                return View(user);
            }
            return RedirectToNotFoundPage;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {
            if (CurrentUser != null)
            {
                CurrentUser.CurrentLang = CurrentLangID;
                var userView = (UserView)ModelMapper.Map(CurrentUser, typeof(User), typeof(UserView));
                return View(userView);
            }
            return RedirectToLoginPage;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(UserView userView)
        {
            if (CurrentUser.ID == userView.ID)
            {
                if (ModelState.IsValid)
                {
                    var user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));
                    user.CurrentLang = CurrentLangID;
                    Repository.UpdateUser(user);

                    return RedirectToAction("Index");
                }
                return View(userView);
            }
            return RedirectToLoginPage;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var registerUserView = new RegisterUserView();
            return View(registerUserView);
        }

        [HttpPost]
        public ActionResult Register(RegisterUserView registerUserView)
        {
            if (Session[CaptchaImage.CaptchaValueKey] as string != registerUserView.Captcha)
            {
                ModelState.AddModelError("Captcha", GlobalRes.captcha_error);
            }
            if (ModelState.IsValid)
            {
                var user = (User)ModelMapper.Map(registerUserView, typeof(RegisterUserView), typeof(User));
                Repository.CreateUser(user);

                NotifyMail.SendNotify("Register_" + CurrentLangCode, user.Email,
                                      format => string.Format(format, HostName),
                                      format => string.Format(format, CurrentLangCode, user.ActivatedLink, HostName));
                return View("RegisterSuccess", user);
            }
            return View(registerUserView);
        }

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            // Create a CAPTCHA image using the text stored in the Session object.
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }

        public ActionResult Activate(string id)
        {
            var user = Repository.Users.FirstOrDefault(p => string.Compare(p.ActivatedLink, id, true) == 0);
            if (user != null)
            {
                Repository.ActivateUser(user);
                Auth.Login(user.Email);
                return View("ActivateSuccess");
            }
            return RedirectToNotFoundPage;
        }

        [HttpPost]
        public JsonResult UploadAvatar(string qqfile)
        {
            var fileName = string.Empty;
            var inputStream = GetInputStream(qqfile, out fileName);
            if (inputStream != null)
            {
                var extension = Path.GetExtension(fileName);
                if (extension != null)
                {
                    extension = extension.ToLower();
                    var mimeType = Config.MimeTypes.FirstOrDefault(p => p.Extension == extension);

                    if (mimeType != null && PreviewCreator.SupportMimeType(mimeType.Name))
                    {
                        var ms = GetMemoryStream(inputStream);
                        var avatarUrl = MakeAvatar(ms);
                        return Json(new
                                        {
                                            success = true,
                                            result = "ok",
                                            data = new
                                                       {
                                                           AvatarUrl = avatarUrl
                                                       }
                                        }, "text/html");
                    }
                }
            }
            return Json(new { success = true, result = "error" });
        }

        private static MemoryStream GetMemoryStream(Stream inputStream)
        {
            var buffer = new byte[inputStream.Length];
            var ms = new MemoryStream(buffer);
            inputStream.CopyTo(ms);
            return ms;
        }

        private string MakeAvatar(MemoryStream ms)
        {
            var avatarUrl = string.Format("{0}{1}.jpg", AvatarFolder, StringExtension.GenerateNewFile());
            var avatarSizes = Config.IconSizes.FirstOrDefault(c => c.Name == AvatarSize);
            if (avatarSizes != null)
            {
                var previewSize = new Size(avatarSizes.Width, avatarSizes.Height);
                PreviewCreator.CreateAndSaveAvatar(ms, previewSize, Server.MapPath(avatarUrl));
            }
            return avatarUrl;
        }

        private Stream GetInputStream(string qqfile, out string fileName)
        {
            fileName = string.Empty;
            if (Request.Files != null && Request.Files.Count > 0)
            {
                var httpPostedFileBase = Request.Files["qqfile"];
                if (httpPostedFileBase != null)
                {
                    fileName = qqfile;
                    return httpPostedFileBase.InputStream;
                }
            }
            else
            {
                if (qqfile != null)
                {
                    fileName = qqfile;
                    return Request.InputStream;
                }
            }
            return null;
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            var changePasswordView = new ChangePasswordView
                                         {
                                             ID = CurrentUser.ID
                                         };
            return View(changePasswordView);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordView changePasswordView)
        {
            if (ModelState.IsValid)
            {
                CurrentUser.Password = changePasswordView.NewPassword;
                Repository.ChangePassword(CurrentUser);
                TempData["message"] = GlobalRes.saved;
            }
            return View(changePasswordView);
        }
    }
}
