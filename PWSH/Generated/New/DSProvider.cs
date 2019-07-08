using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDSProvider")]
    public class NewQVDSProvider : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DSProvider dsprovider;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Type;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            dsprovider = new QlikView_CLI.QMSAPI.DSProvider() { Name = Name, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(dsprovider);
        }
    }
}
