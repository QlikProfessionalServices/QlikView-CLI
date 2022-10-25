<#
	.NOTES
	===========================================================================
	 Created on:   	2020-10-16 10:30 AM
	 Created by:   	Marc Collins (Marc.Collins@Qlik.com)
	 Organization: 	Qlik Professional Services
	 Filename:     	Generate_API_Functions.ps1
	===========================================================================
	.DESCRIPTION
		QlikView Cmdlet Generator
#>

#First Update the QMSAPI and generate the Assembly. (Stage 1)
$QlikViewCLIAssembly = "$($PWD.Path)\bin\Release\QlikView-CLI.dll"
$BaseQMSAPIURL = "https://help.qlik.com/en-US/qlikview-developer/csh2/QMSAPIref/Content/"
$QVVersion = "12"

[System.IO.DirectoryInfo]$OutputDirectory = "$($PWD.Path)\PWSH\Generated"
#Import the Generated Assembly
Import-Module $QlikViewCLIAssembly

$TextInfo = (Get-Culture).TextInfo
$Services = "dscID", "qdsID", "qvsID", "qvwsID"

$QMSClients = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes()  | Where-Object {$_.NameSpace -eq 'QlikView_CLI.QMSAPI' -and $_.Name -like "QMS*Client"}|select -Property @{Name = "Version";E={$_.name -replace "QMS","" -replace "Client","" }},@{Name = "Object";E={$_}}
$QMSClientLatest = $QMSClients|Sort-Object -Property version|Select-Object -Last 1

#Create a dummyclient
$BasicHttpBinding = [System.ServiceModel.BasicHttpBinding]::new()
$Client = $QMSClientLatest.Object::new($BasicHttpBinding, "http://localhost")
#Get All of the Methods availiable on the Client
$ClientMethods = $Client | Get-Member -MemberType Methods
$Overloaded = @{
}


#$ClientMethod = $ClientMethods|?{$_.name -eq "QVSNeedRestart" }
#Process Each Method to extract the Required Overloads
foreach ($ClientMethod in $ClientMethods)
{
	TRY
	{
		$Overloads = ($ClientMethod.Definition -split "(?<=\)),").trim()
		$Definitions = $(New-Object System.Collections.ArrayList)
		foreach ($Overload in $Overloads)
		{
			$overloader = [ORDERED]@{
			}
			#Split the Overload into Fields
			$OverloadFields = $overload -split "\("
			$OverloadField = $OverloadFields[1] -split "\)"
			$OverloadField = $($OverloadField -split ", ").trim()
			$OverloadField | Where-Object{
				$_ -ne ""
			} | ForEach-Object{
				$AllFields = ($_ -split " "); $overloader.add($AllFields[($AllFields).Length - 1], ($AllFields[0 .. (($AllFields).Length - 2)] -join " "))
			}
			$OverloadFieldType = $OverloadFields[0] -split " "

			$ReturnType = $OverloadFieldType[0]
			if ($ReturnType -eq "void")
			{
				$ReturnType = $null
			}
			#Generate the Method Definition
			$Definition = [pscustomobject][ordered]@{
				Name = $OverloadFieldType[1]
				ReturnType = $ReturnType

				Input = $overloader
			}

			$Definitions.Add($Definition) | out-null
		}
		$Overloaded.Add($ClientMethod.Name, $Definitions) | out-null
	}
	catch
	{
		Write-warning "Error Encountered when Generating Definitions for $($ClientMethod.Name)"
	}
}

$OverloadedObj = ([pscustomobject]$Overloaded)
$Global:QVOverloads = $OverloadedObj
$Code = [System.Collections.ArrayList]::new()
$CmdLetMapping = [System.Collections.ArrayList]::new()

#Filter out the Async Method Definitions
#$Methods = $ClientMethods.name | ?{ $_ -like "$Verb*" -and (!($_ -like "*Async")) }
$Methods = $ClientMethods.name | Where-Object{
	(!($_ -like "*Async")) -and (!($_ -like "Begin*") -and (!($_ -like "End*")) -and (!($_ -eq "Dispose")) -and (!($_ -eq "Equals")) -and (!($_ -eq "Abort")) -and (!($_ -eq "Close")) -and (!($_ -eq "Open")))
}
$Methods = $Methods | Where-Object{
	$_ -ne "GetType" -and $_ -ne "ToString"
}
$VerbRegex = [regex]::new("(?<=[a-z])(?=[A-Z])")

#Process the Methods
foreach ($Method in $Methods)
{
	$MethodNameParts = $VerbRegex.Split($Method)
	if ($MethodNameParts.Length -eq 1)
	{
		$MethodName = $MethodNameParts[0]
	}
	else
	{
		$MethodName = ($MethodNameParts[1 .. $($MethodNameParts.Length)]) -join ""
	}
	$MethodVerb = $MethodNameParts[0]

	if ($MethodVerb -eq "Remote")
	{
		$MethodVerb = $MethodNameParts[1]; $MethodName = ($MethodNameParts[0] + (($MethodNameParts[2 .. $($MethodNameParts.Length)]) -join ""))
	}
	if ($MethodVerb -eq "Create")
	{
		$MethodVerb = "New";
	}
	if ($MethodVerb -eq "Take")
	{
		$MethodVerb = "Get"
	}
	#Set the PowerShell Cmdlet Verbs for each
	switch ($MethodVerb)
	{
		"Abort"{
			$CMDLetType = "VerbsLifecycle.Stop"
		}
		"Add"{
			$CMDLetType = "VerbsCommon.Add"
		}
		"Check"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"Clear"{
			$CMDLetType = "VerbsCommon.Clear"
		}
		"Close"{
			$CMDLetType = "VerbsCommon.Close"
		}
		"Create"{
			$CMDLetType = "VerbsCommon.New";
		}
		"Delete"{
			$CMDLetType = "VerbsCommon.Remove"
		}
		"Display"{
			$CMDLetType = "VerbsCommon.Show"
		}
		"Find"{
			$CMDLetType = "VerbsCommon.Find"
		}
		"Get"{
			$CMDLetType = "VerbsCommon.Get"
		}
		"Has"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"Import"{
			$CMDLetType = "VerbsData.Import"
		}
		"Initiate"{
			$CMDLetType = "VerbsLifecycle.Invoke"
		}
		"Is"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"Lookup"{
			$CMDLetType = "VerbsCommon.Find"
		}
		"New"{
			$CMDLetType = "VerbsCommon.New"
		}
		"Open"{
			$CMDLetType = "VerbsCommon.Open"
		}
		"Ping"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"Qds"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"QDSNeed"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"QVSNeed"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"Resolve"{
			$CMDLetType = "VerbsDiagnostic.Resolve"
		}
		"Restart"{
			$CMDLetType = "VerbsLifecycle.Restart"
		}
		"Run"{
			$CMDLetType = "VerbsLifecycle.Start"
		}
		"Save"{
			$CMDLetType = "VerbsData.Save"
		}
		"Select"{
			$CMDLetType = "VerbsCommon.Select"
		}
		"Send"{
			$CMDLetType = "VerbsCommunications.Send"
		}
		"Service"{
			$CMDLetType = "VerbsDiagnostic.Test"
		}
		"Set"{
			$CMDLetType = "VerbsCommon.Set"
		}
		"Shutdown"{
			$CMDLetType = "VerbsLifecycle.Stop"
		}
		"Take"{
			$CMDLetType = "VerbsCommon.Get"
		}
		"Trigger"{
			$CMDLetType = "VerbsLifecycle.Start"
		}
		"Update"{
			$CMDLetType = "VerbsData.Update"
		}
		"Validate"{
			$CMDLetType = "VerbsLifecycle.Confirm"
		}
		"Write"{
			$CMDLetType = "VerbsCommunications.Write"
		}
		default{
			$CMDLetType = ""
		}
	}

	Write-host "$($Method)"
	$Definition = $Global:QVOverloads.$Method | Where-Object{
		(!($_.name -like "IQMS*"))
	}

	#region BeginBlock
	$BeginBlock = ""
	$ServiceParam = ""
	$ServiceProp = ""
	if ($Definition.Input.Keys -contains "dscID")
	{
		$ServiceParam = "dscID"
		$ServiceProp = "QlikViewDirectoryServiceConnector"
		$BeginBlock = @"
if (dscID == default)
{
    dscID = Connection.QlikViewDirectoryServiceConnector.Select(x => x.ID).ToArray();
}
"@
	}

	if ($Definition.Input.Keys -contains "qdsID")
	{
		$ServiceParam = "qdsID"
		$ServiceProp = "QlikViewDistributionService"
		$BeginBlock = @"
if (qdsID == default)
{
    qdsID = Connection.QlikViewDistributionService.Select(x => x.ID).ToArray();
}
"@
	}

	if ($Definition.Input.Keys -contains "qvsID")
	{
		$ServiceParam = "qvsID"
		$ServiceProp = "QlikViewServer"
		$BeginBlock = @"
if (qvsID == default)
{
    qvsID = Connection.QlikViewServer.Select(x => x.ID).ToArray();
}
"@
	}

	if ($Definition.Input.Keys -contains "qvwsID")
	{
		$ServiceParam = "qvwsID"
		$ServiceProp = "QlikViewWebServer"
		$BeginBlock = @"
if (qvwsID == default)
{
    qvwsID = Connection.QlikViewWebServer.Select(x => x.ID).ToArray();
}
"@
	}
	#endregion BeginBlock

	#region Inputs
	#
	#public $(if (!$Definition.Input.$Key.StartsWith($QVModule)){$($TextInfo.ToTitleCase($Definition.Input.$Key.ToLower()))}else{$Definition.Input.$Key}) $($Key)"
	$InputsLine = foreach ($Key in $Definition.Input.Keys)
	{


		If ($Key -in $Services)
		{
			$Key = $Key.Replace("Id", "ID")
			"[Parameter]
    public Guid[] $($Key);
    "
		}
		else
		{

			if ($Definition.Input.$Key.Contains("[]"))
			{
				"
                [Parameter]
               public $($Definition.Input.$Key.Replace("guid", "Guid").Replace("uri", "Uri").Replace('<ref> ', '')) $($TextInfo.ToTitleCase($Key));"

			}
			else
			{
				"
                [Parameter]
               public $($Definition.Input.$Key.Replace("[", "<").replace("]", ">").Replace("guid", "Guid").Replace("uri", "Uri").Replace('<ref> ', '')) $($TextInfo.ToTitleCase($Key));"
			}
		}
	}
	if ($Definition.Input.keys.Count -gt 0)
	{
		$MIKeys = $($Definition.Input.keys | Where-Object{
				(!($_ -in $Services))
			})
		if (($MIKeys | Measure-Object).count -gt 0)
		{
			$Inputoverloads = $TextInfo.ToTitleCase($MIKeys -join ",")
		}
		else
		{
			$Inputoverloads = ""
		}

	}
	else
	{
		$Inputoverloads = ""
	}

	#endregion Inputs

	#region ReturnType
	$ReturnTypeName = ""
	if ($null -ne $Definition.ReturnType)
	{
		if ($Definition.ReturnType.StartsWith("System.Collections.Generic"))
		{
			$ReturnType = $Definition.ReturnType.Replace("[", "<").replace("]", ">")
			$ReturnTypeName = $TextInfo.ToTitleCase(($ReturnType.Split("<")[1]).replace(">", "").split(".")[-1])
			if ($ReturnTypeName -like "*,*")
			{
				$ReturnTypeName = ($ReturnTypeName -split ",")[0]
			}
		}
		else
		{
			$ReturnType = $Definition.ReturnType.Replace("uri", "Uri")
		}

		if ($ReturnTypeName -eq "")
		{
			$ReturnTypeName = $($TextInfo.ToTitleCase($($ReturnType.split(".")[-1]).ToLower()))
		}
		if ($ReturnTypeName -eq "")
		{
			$ReturnTypeName = $($TextInfo.ToTitleCase($ReturnType.ToLower()))
		}

		$ReturnTypeNameEQ = "$($ReturnTypeName) = "

		if ($ReturnType.StartsWith("System.Collections.Generic.List"))
		{
			$ReturnTypeLine = "private $($ReturnType) $($ReturnTypeName) = new $($ReturnType)();"
		}
		else
		{
			$ReturnTypeLine = "private $($ReturnType) $($ReturnTypeName);"
		}
		$ReturnTypeLine = $ReturnTypeLine.Replace("guid", "Guid")
	}
	else
	{
		$ReturnTypeLine = ""
		$ReturnTypeName = "_"
		$ReturnTypeNameEQ = ""
	}
	#endregion ReturnType

<#
    $Verb
    $MethodName
    $ReturnType
    $Inputs
    $ReturnTypeLine
    $BeginBlock
    $ServiceParam
    $ServiceProp
    #>

	#region Code
	###########
	#Get the CMDLetType Name
	$Verb = $CMDLetType.Split(".")[1]
	$TextInfo = (Get-Culture).TextInfo

	$Snip = @"
    [Cmdlet($CMDLetType, "QV$MethodName")]
    public class $($Verb)QV$($MethodName) : PSClient
    {
        $InputsLine
        $ReturnTypeLine

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            $(if ($ServiceParam -ne "")
		{
			"if ($ServiceParam == null)
            {
                $ServiceParam =  Connection.$ServiceProp.Select(x => x.ID).ToArray();
            }
            "
		})
        }

        protected override void ProcessRecord()
        {
            try
            {
                $(if ($ServiceParam -ne "")
		{

			if ($Inputoverloads -ne "")
			{
				$Inputover = "obj,$Inputoverloads"
			}
			else
			{
				$Inputover = "obj"
			}
			"foreach (Guid obj in $ServiceParam){
                $ReturnTypeNameEQ Connection.client.$($Method)($Inputover);
                }"
		}
		else
		{
			"$ReturnTypeNameEQ Connection.client.$($Method)($Inputoverloads);"
		})

            }
            catch (System.Exception e)
            {
				var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified,Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject($(if ($ReturnTypeName -ne "_")
		{
			$ReturnTypeName
		}
		else
		{
			"null"
		}));
        }

    }

"@


	[System.IO.DirectoryInfo]$VerbDir = "$($OutputDirectory.FullName)\$(($CMDLetType.split("."))[1])"
	$VerbDir.Create()

	#Add the Headers to the Function and save to file
	@"
using QlikView_CLI.QMSAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace QlikView_CLI.PWSH
{
    $Snip
}
"@ | Out-File "$($VerbDir.FullName)\$($MethodName).cs" -Encoding utf8
	$Code.Add($Snip) | Out-Null

	#Add to Mapping for Documentation
	$CMDLetMap = @{
		Method = $Method
		CMDLet = "$($Verb)-QV$($MethodName)"
		Type = $(($CMDLetType.split("."))[1])
		CMDLetName = $($MethodName)
	}
	$CmdLetMapping.Add($CMDLetMap) | out-null
	###########
	#endregion
}

$MDBody = $CmdLetMapping | ForEach-Object{
	$CmdMap = $_
	"- [$($CmdMap.Method)]($($BaseQMSAPIURL)PIX.Services.V$($QVVersion).Api$($QMSClientLatest.Version).IQMS$($QMSClientLatest.Version).$($CmdMap.Method).htm) = [$($CmdMap.CMDLet)]($($(Resolve-Path "$($OutputDirectory.ToString())/$($CmdMap.Type)/$($CmdMap.CMDLetName).cs" -Relative) -replace "\\", "/"))"
}
"
`### Method to Cmdlet Mapping`n`n
$($MDBody -join "`n`n")
" | out-file .\QMSAPI_Method_to_Cmdlet.md -Encoding utf8

if ($Null -ne $(get-command dotnet-format))
{
	& dotnet-format -v diag --folder .\
}
