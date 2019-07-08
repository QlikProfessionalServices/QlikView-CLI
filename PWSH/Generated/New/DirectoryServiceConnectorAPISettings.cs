using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDirectoryServiceConnectorAPISettings")]
    public class NewQVDirectoryServiceConnectorAPISettings : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DirectoryServiceConnectorAPISettings directoryserviceconnectorapisettings;
        [Parameter]
        public List<System.Uri> Allurls = new List<System.Uri>();
        [Parameter]
        public System.Guid Id = Guid.NewGuid();
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            directoryserviceconnectorapisettings = new QlikView_CLI.QMSAPI.DirectoryServiceConnectorAPISettings() { AllUrls = Allurls, Id = Id, Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(directoryserviceconnectorapisettings);
        }
    }
}
