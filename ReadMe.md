
# QlikView-CLI

The source code for this module is hosted on GitHub [QlikView-CLI](https://github.com/QlikProfessionalServices/QlikView-CLI)

If you just want to use the module, Published Versions can be downloaded from the following Locations:

[PowerShell Gallery](https://www.powershellgallery.com/packages/QlikView-CLI) and on [GitHub](https://github.com/QlikProfessionalServices/QlikView-CLI/releases/)

or in PowerShell you can run the command `Install-Module QlikView-CLI`


## About

QlikView-CLI is a PowerShell module that provides a command line interface for managing Qlik View environments.

As the Module is procedurally generated and provides PowerShell functions to interface with the QlikView QMSAPIs.
These functions can be used for viewing and editing configuration settings, as well as managing tasks and other features available through the APIs.

[IQMS7 Methods](https://help.qlik.com/en-US/qlikview-developer/csh/QMSAPIref/Content/PIX.Services.V12.Api7.IQMS7.htm#)

The Mapping between QMSAPI Methods and the PowerShell Commandlets can be found here:

[QMSAPI Method to Cmdlets](./QMSAPI_Method_to_Cmdlet.md)


The QMSAPI Data objects included in this module can be found here:

[QMSAPI DataObjects](./QMSAPI_DataObjects.md)


## To Do:
 - [ ] More detailed documentation around using the APIs
 - [ ] More examples
 - [ ] Common processes


## Usage

Either place the Module Folder into `C:\Program Files\WindowsPowerShell\Modules`

or run `Import-Module .\QlikView-CLI` to import it manually.


### Connecting to Qlik View

    $Connection = Connect-QlikView [-Hostname ServerName][-credential Credentials] [-Version IQMS*] [-PassThru]

-Version can be used to connect to previous releases of QlikView.
- IQMS: QlikView 11.20 and 12.00
- IQMS2: QlikView 12.10
- IQMS3: QlikView 12.30 (November 2018)
- IQMS4: QlikView 12.40 (April 2019)
- IQMS5: QlikView 12.50 (April 2020)
- IQMS6: QlikView 12.60 (May 2021)
- IQMS7: QlikView 12.70 (May 2022)

[The QlikView Management Service API](https://help.qlik.com/en-US/qlikview-developer/csh/Subsystems/QMSAPIref/Content/Home.htm)


If -PassThru is ommited from the Connect-QlikView command, the connection established will be a Global Connection that will be used for all subsequent API calls.

If -PassThru is added to the Connect-QlikView command it is not added as a Global Connection, and subsequent commands will require the Connection Object returned by the Connect-QlikView command.

### Examples

#### Create new Source Directories and add Administrators

    $SourceDirectories = "C:\QlikView\Dir1", "\\Server\Share\Directory"
    $SourceDirectoriesAdministrators = "User1", "User2"

    #Import the Module
    Import-module .\QlikView-CLI

    #Establish the connection
    $Connection = Connect-QlikView
    $Connection

    #Get the QDS Settings
    $QDS = Get-QVQDSSettings -Scope All
    $NewDocFolders = [System.Collections.ArrayList]::new()

    foreach ($SourceDir in $SourceDirectories)
    {
    	#Create the Folder General Properties
    	$QVDocFolderGeneral = New-QVDocumentFolderGeneral -Path $SourceDir -Sendalertemailfordocumentadministrators $True -Type Source

    	#Create the New Folder Object
    	$QVDocumentFolder = New-QVDocumentFolder -Scope General -General $QVDocFolderGeneral

    	#Add the new Folder to the QDS Settings
    	$QDS.General.SourceFolders.Add($QVDocumentFolder)

    	#And to the NewDocFolders as the Folder needs to be added to QDS before we can assign Admin
    	$NewDocFolders.Add($QVDocumentFolder) | out-null
    }

    #Save the Updated QDS Settings
    Save-QVQDSSettings -Qdssettings $QDS

    #Process each of the New folders add the Admins to it.
    foreach ($NewDocFolder in $NewDocFolders)
    {
    	foreach ($Admin in $SourceDirectoriesAdministrators)
    	{
    		Set-QVDocumentFolderAdministrator -Foldertype SourceDocumentFolder -Folderid $NewDocFolder.ID -Username $Admin
    	}
    }

