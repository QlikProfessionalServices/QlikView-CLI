<#
	.NOTES
	===========================================================================
	 Created on:   	2020-10-16 10:30 AM
	 Created by:   	Marc Collins (Marc.Collins@Qlik.com)
	 Organization: 	Qlik Professional Services
	 Filename:     	Generate_API_ObjectCreators.ps1
	===========================================================================
	.DESCRIPTION
		QlikView DataObject Generator
#>
#First Update the QMSAPI and generate the Assembly. (Stage 1)
$QlikViewCLIAssembly = "$($PWD.Path)\bin\Release\QlikView-CLI.dll"

[System.IO.DirectoryInfo]$OutputDirectory = "$($PWD.Path)\PWSH\Generated"
$BaseQMSAPIURL = "https://help.qlik.com/en-US/qlikview-developer/csh2/QMSAPIref/Content/"

#Import the Generated Assembly
Import-Module $QlikViewCLIAssembly

$QVModule = "QlikView_CLI.QMSAPI"
$TextInfo = (Get-Culture).TextInfo
$Services = "dscID", "qdsID", "qvsID", "qvwsID"

$CmdLetMapping = [System.Collections.ArrayList]::new()

#Extract the QV Objects form the Assembly
$QVObjects = ((([appdomain]::currentdomain.GetAssemblies()) | Where-Object{
			$_.fullname.StartsWith("QlikView")
		}).getTypes() | Where-Object{
		$_.Namespace -eq $QVModule -and $_.IsEnum -eq $false -and $_.IsClass -eq $true -and $_.IsSerializable -eq $true
	})
#Exclude the QV Exception object as we dont need it.
$QVObjects = $QVObjects | Where-Object{
	$_.Name -ne "Exception"
}
foreach ($QVObject in $QVObjects)
{
	write-host $QVObject.Name
	$PropertyList = [System.Collections.ArrayList]::new()
	$QVObjProperties = foreach ($QVObjProperty in $QVObject.DeclaredProperties)
	{
		$PropteryTitle = $TextInfo.ToTitleCase($QVObjProperty.Name)
		if ($QVObjProperty.Name -eq "ExtensionData")
		{
			#Exclude the ExtensionData property from the creator as it is irrelevant
		}
		else
		{
			#Add the Property Value to the List
			$PropertyList.add(@{
					Name = $QVObjProperty.Name
					Title = $PropteryTitle
				}) | Out-Null

			#Build the Property Parameter
			$SB = [System.Text.StringBuilder]::new()

			#Add the Parameter Header
			$SB.Append("`t[Parameter]`n") | out-null

			#Set the Scope
			$SB.Append("`tpublic ") | out-null

			#Set the Type
			if ($QVObjProperty.PropertyType.Name -eq 'List`1')
			{
				$SB.Append("List<$($QVObjProperty.PropertyType.GenericTypeArguments.FullName.Replace("+", "."))> ") | out-null
			}
			elseif ($QVObjProperty.PropertyType.Name -eq 'Dictionary`2')
			{
				$SB.Append("Dictionary<$($QVObjProperty.PropertyType.GenericTypeArguments.FullName -join ", ")> ") | out-null
			}
			else
			{
				$SB.Append("$($QVObjProperty.PropertyType.FullName.Replace("+", ".")) ") | out-null
			}

			#Set the Property name
			$SB.Append("$($PropteryTitle)") | out-null

			#Set the Default Value (if)
			if ($QVObjProperty.PropertyType.FullName -eq "System.Guid" -and !($QVObjProperty.Name -in $Services))
			{
				#Adding a default guid causes confusion as the property value is not retained when the object is saved
				if ($QVObjProperty.Name -eq "ID")
				{
					$SB.Append(" = Guid.NewGuid()") | out-null
				}
			}
			elseif ($QVObjProperty.PropertyType.FullName -eq "System.String")
			{
				#Does not require a default value
			}
			elseif ($QVObjProperty.PropertyType.FullName -eq "System.Uri")
			{
				#Does not require a default value
			}
			elseif ($QVObjProperty.Name -in $Services)
			{
				#Does not require a default value
			}
			elseif ($QVObjProperty.PropertyType.BaseType.FullName -eq "System.Enum")
			{
				$SB.Append(" = default($($QVObjProperty.PropertyType.FullName.Replace("+", ".")))") | out-null
			}
			elseif ($QVObjProperty.PropertyType.Name -eq 'List`1')
			{
				$SB.Append("= new List<$($QVObjProperty.PropertyType.GenericTypeArguments.FullName.Replace("+", "."))>()") | out-null
			}
			elseif ($QVObjProperty.PropertyType.Name -eq 'Dictionary`2')
			{
				$SB.Append("= new Dictionary<$($QVObjProperty.PropertyType.GenericTypeArguments.FullName -join ", ")>()") | out-null
			}
			else
			{
				$SB.Append(" = new $($QVObjProperty.PropertyType.FullName.Replace("+", "."))()") | out-null
			}
			$SB.Append(";`n") | out-null
			$SB.ToString()
		}
	}
	#Build and save the output file
	@"
    using $QVModule;
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
    namespace QlikView_CLI.PWSH
    {
        [Cmdlet(VerbsCommon.New, "QV$($QVObject.Name)")]
        public class NewQV$($QVObject.Name) : PSCmdlet
        {
private $($QVObject.FullName.Replace("+", ".")) $($QVObject.Name.ToLower());
$QVObjProperties

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
			base.ProcessRecord();
			$($QVObject.Name.ToLower()) = new $($QVObject.FullName.Replace("+", "."))(){$(($PropertyList | ForEach-Object{
				"$($_.name) = $($_.title)"
			}) -join ",")};
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject($($QVObject.Name.ToLower()));
        }
    }
    }
"@ | Out-File ".\PWSH\Generated\New\$($QVObject.Name).cs" -Encoding utf8

	#Add to Mapping for Documentation
	$CMDLetMap = @{
		CMDLet = "New-QV$($QVObject.Name)"
		ObjName = $QVObject.FullName.Substring($QVModule.length + 1) -replace "\+", "."
		Type = $($QVObject.Name)
	}
	$CmdLetMapping.Add($CMDLetMap) | out-null

}

#$CmdLetMapping|sort|%{"- $_"}|clip
Write-host "Checking QMSAPI Documentation URLs ========================"
$MDBody = $CmdLetMapping | ForEach-Object{
	$CmdMap = $_
	$State = $true
    Write-host "Testing URIs: $($CmdMap.ObjName)"
	try
	{
		$URI = "$($BaseQMSAPIURL)PIX.QMSAPI.DataObjects.$($CmdMap.ObjName).htm"
		$R = Invoke-RestMethod $URI
	}
	catch
	{
		try
		{
			$URI = "$($BaseQMSAPIURL)PIX.QMSAPI.DataObjects.CALs.$($CmdMap.ObjName).htm"
			$R = Invoke-RestMethod $URI
		}
		catch
		{
			try
			{
				$URI = "$($BaseQMSAPIURL)PIX.QMSAPI.DataObjects.Document.$($CmdMap.ObjName).htm"
				$R = Invoke-RestMethod $URI
			}
			catch
			{
				try
				{
					$URI = "$($BaseQMSAPIURL)PIX.QMSAPI.DataObjects.Enums.$($CmdMap.ObjName).htm"
					$R = Invoke-RestMethod $URI
				}
				catch
				{
					try
					{
						$URI = "$($BaseQMSAPIURL)PIX.QMSAPI.DataObjects.Triggers.$($CmdMap.ObjName).htm"
						$R = Invoke-RestMethod $URI
					}
					catch
					{
						try
						{
							$URI = "$($BaseQMSAPIURL)PIX.$($CmdMap.ObjName).htm"
							$R = Invoke-RestMethod $URI
						}
						catch
						{
							write-host "Unable to Identify QMSAPI URL for $($CmdMap.ObjName)" -ForegroundColor Red
							$State = $False
						}
					}
				}
			}
		}
	}


	if ($State -eq $true)
	{
		"- [$($CmdMap.Type)]($($URI)) = [$($CmdMap.CMDLet)]($($(Resolve-Path "$($OutputDirectory.ToString())/New/$($CmdMap.Type).cs" -Relative) -replace "\\", "/"))"
	}
	else
	{
		"- $($CmdMap.Type) = [$($CmdMap.CMDLet)]($($(Resolve-Path "$($OutputDirectory.ToString())/New/$($CmdMap.Type).cs" -Relative) -replace "\\", "/"))"
	}
}
"
`### Method to Cmdlet Mapping`n`n
$($MDBody -join "`n`n")
" | out-file .\QMSAPI_DataObjects.md -Encoding utf8

if ($Null -ne $(get-command dotnet-format))
{
	& dotnet-format -v diag --folder .\
}

Get-ChildItem ".\PWSH\Generated\New" | ForEach-Object{
	$(Get-Content $_.fullname) | out-file $_.fullname -Encoding utf8BOM
}