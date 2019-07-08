<#
This script will run on debug.
It will load in a PowerShell command shell and import the module developed in the project. To end debug, exit this shell.
#>

# Write a reminder on how to end debugging.
$message = "| Exit this shell to end the debug session! |"
$line = "-" * $message.Length
$color = "Cyan"
Write-Host -ForegroundColor $color $line
Write-Host -ForegroundColor $color $message
Write-Host -ForegroundColor $color $line
Write-Host

try{
	#Properties Variable will contain any information provided by the PostBuild.
	#Can be usefull if you want to know the Configuraiton type, Project Dir etc.
    $Properties = Import-Clixml .\PostBuild.clixml
}
catch{}

if ($null -eq $Cred)
{
	$CredFile = "..\$($env:USERNAME)-$($Env:COMPUTERNAME).cred.clixml"
	if (Test-Path $CredFile)
	{
		$Cred = Import-Clixml $CredFile
	}
	else
	{
		$Cred = Get-Credential -Message "QlikView Connection Credentials"
		$Cred | Export-Clixml $CredFile
	}
}

# Load the module.
$env:PSModulePath = $env:PSModulePath + "$([System.IO.Path]::PathSeparator)$((Resolve-Path .).Path)" 
Import-Module 'QlikView-CLI' -Verbose


$ConnectionCMDOr = "`$QVConnection = Connect-QlikView"
$ConnectionCMD = "`$QVConnection = Connect-QlikView -Hostname qvserver -Credential `$Creds -Passthru" 

$line = "-" * $ConnectionCMD.Length
Write-Host -ForegroundColor $color $line
Write-host "To Connect to a Qlik View Server use a command similar to" -ForegroundColor $color
Write-host $ConnectionCMDOr
Write-host $ConnectionCMD
Write-Host -ForegroundColor $color $line

# Happy debugging :-)