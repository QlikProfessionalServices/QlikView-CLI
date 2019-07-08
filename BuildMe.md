## Building the QlikView-CLI Module
The following instructions are used for rebuilding the QlikView-CLI Module

This requires the project to be built twice, once to update the Assembly with any new Interface Methods and DataObjects and once to update the PowerShell Cmdlets.

Inorder to maintain consistency in the generated Files it is recommended that you install [Dotnet-Format](https://github.com/dotnet/format) to format the generated Cmdlets.
This can be insalled from the commadn line by running `dotnet tool install -g dotnet-format`

If installed the Fotmat command will be run at the end of the Generator Processes.

### Stage 1 - Update QMSAPI
Updates the Assembly from a current version of QlikView.

- Open the Solution in Visual Studio 
- Edit the Connected Service/QMSAPI to point to a QlikView Server
- Update the Connected Service
- Build the Solution

This will produce a new version of the QlikView-CLI module, however it will not include any Cmdlets for new features/functions.

### Stage 2 - Update PowerShell Cmdlets
Updates the Cmdlets in the Assembly.

Once **Stage 1** has been completed, there will be a updated version of the QlikView-CLI.dll which should include any new APIs & Object Models. 
This updated Assembly is then used by the PowerShell Scripts:
- Generate_API_Functions.ps1
- Generate_API_ObjectCreators.ps1

Make sure the variable on the first line of both of these scripts points to the Assembly from Stage 1 e.g. *$QlikViewCLIAssembly = ".\bin\Release\QlikView-CLI.dll"*

Run each of the PowerShell scripts to update the Generated QlikView API Functions & New-QV object models creators.

### Update the Project.

In Visual Studio, make sure any new files generated are included in the QlikView-CLI Project.
These will be located in the Subfolder */Generated*

Build the solution. 