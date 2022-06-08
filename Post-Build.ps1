param(
	# The name of the current project configuration, for example, "Debug".
	[Parameter()] $ConfigurationName,

	# Path to the output file directory, relative to the project directory. This resolves to the value for the Output Directory property. It includes the trailing backslash '\'.
	[Parameter()] $OutDir,

	# The installation directory of Visual Studio (defined with drive and path; includes the trailing backslash '\'.
	[Parameter()] $DevEnvDir,

	# The name of the currently targeted platform. For example, "AnyCPU".
	[Parameter()] $PlatformName,

	# The directory of the project (defined with drive and path; includes the trailing backslash '\'.
	[Parameter()] $ProjectDir,

	# The absolute path name of the project (defined with drive, path, base name, and file extension.
	[Parameter()] $ProjectPath,

	# The base name of the project.
	[Parameter()] $ProjectName,

	# The file name of the project (defined with base name and file extension.
	[Parameter()] $ProjectFileName,

	# The file extension of the project. It includes the '.' before the file extension.
	[Parameter()] $ProjectExt,

	# The directory of the solution (defined with drive and path; includes the trailing backslash '\'.
	[Parameter()] $SolutionDir,

	# The absolute path name of the solution (defined with drive, path, base name, and file extension.
	[Parameter()] $SolutionPath,

	# The base name of the solution.
	[Parameter()] $SolutionName,

	# The file name of the solution (defined with base name and file extension.
	[Parameter()] $SolutionFileName,

	# The file extension of the solution. It includes the '.' before the file extension.
	[Parameter()] $SolutionExt,

	# The directory of the primary output file for the build (defined with drive and path. It includes the trailing backslash '\'.
	[Parameter()] $TargetDir,

	# The absolute path name of the primary output file for the build (defined with drive, path, base name, and file extension.
	[Parameter()] $TargetPath,

	# The base name of the primary output file for the build.
	[Parameter()] $TargetName,

	# The file name of the primary output file for the build (defined as base name and file extension.
	[Parameter()] $TargetFileName,

	# The file extension of the primary output file for the build. It includes the '.' before the file extension.
	[Parameter()] $TargetExt
)

Remove-Item "$($TargetDir)\$($ProjectName)" -Recurse -Verbose -Force -ErrorAction SilentlyContinue
Copy-Item -Path "$($ProjectDir)\$($ProjectName)" -Destination $TargetDir -Force -Verbose -Recurse
Copy-Item -Path $TargetPath -Destination "$($TargetDir)$($ProjectName)\" -Force -Verbose
$PSBoundParameters|Export-Clixml "$($TargetDir)\PostBuild.clixml"

$DLL = Get-Item $TargetPath

$CMDletCommand = (Import-Module $DLL.FullName -Passthru).ExportedCmdlets.Values.Name
$FunctionNames = (Import-Module "$($ProjectDir)\$($ProjectName)\$($ProjectName).psm1" -Passthru).ExportedFunctions.Values.Name
$MMPath = "$($DLL.Directory.FullName)\$($ProjectName)\$($DLL.BaseName).psd1"
$paramNewModuleManifest = @{
    Path = $MMPath
    NestedModules = $DLL.Name
	Author = "Marc Collins"
	CompanyName = "Qlik Professional Services"
	Copyright = "Copyright© $([datetime]::Now.Year), All rights reserved."
	RootModule = "$($DLL.BaseName).psm1"
	ModuleVersion = "$($Dll.VersionInfo.FileMajorPart).$($Dll.VersionInfo.FileMinorPart).$($Dll.VersionInfo.FileBuildPart)"
	Description = "PowerShell module to interact with QlikView - APIs"
	ProcessorArchitecture = 'None'
	PowerShellVersion = "4.0"
	RequiredModules = $RequiredModules
	FileList = "$($DLL.Name)", "$($DLL.BaseName).psm1"
	FunctionsToExport = $FunctionNames
	VariablesToExport = ""
	AliasesToExport = ""
	CmdletsToExport = $CMDletCommand
	Tags = "Qlik", "QlikView", "Qlik-View", "QlikView-CLI", "Qlik-API", "API"
	ProjectUri = 'https://github.com/QlikProfessionalServices/QlikView-CLI'
	ReleaseNotes = "https://github.com/QlikProfessionalServices/QlikView-CLI/releases/tag/$($DLL.VersionInfo.ProductVersion)"
    LicenseUri = 'https://github.com/QlikProfessionalServices/QlikView-CLI/blob/main/LICENSE'
}

New-ModuleManifest @paramNewModuleManifest