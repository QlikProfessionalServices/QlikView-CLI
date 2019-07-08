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