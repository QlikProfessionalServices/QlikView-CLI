using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDSPSettings")]
    public class NewQVDSPSettings : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DSPSettings dspsettings;
        [Parameter]
        public System.Int32 Customdirectoryport = new System.Int32();
        [Parameter]
        public System.Guid DSCID;
        [Parameter]
        public System.String Dsptype;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DSResource> Resources = new List<QlikView_CLI.QMSAPI.DSResource>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            dspsettings = new QlikView_CLI.QMSAPI.DSPSettings() { CustomDirectoryPort = Customdirectoryport, DSCID = DSCID, DSPType = Dsptype, Resources = Resources };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(dspsettings);
        }
    }
}
