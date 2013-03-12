[T4Scaffolding.Scaffolder(Description = "Print Details for class")][CmdletBinding()]
param(    
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,    
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)
$foundModelType = Get-ProjectType $ModelType -Project $Project -BlockUi
if (!$foundModelType) { return }

$outputPath = Join-Path "Details" $ModelType

Add-ProjectItemViaTemplate $outputPath -Template Details `
		-Model @{  ModelType = $foundModelType  } `
		-SuccessMessage "Yippee-ki-yay"`
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force