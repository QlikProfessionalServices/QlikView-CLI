using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQMSVersion")]
    public class NewQVQMSVersion : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QMSVersion qmsversion;
        [Parameter]
        public System.Int32 Major = new System.Int32();
        [Parameter]
        public System.Int32 Minor = new System.Int32();
        [Parameter]
        public System.Int32 Patch = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qmsversion = new QlikView_CLI.QMSAPI.QMSVersion() { Major = Major, Minor = Minor, Patch = Patch };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qmsversion);
        }
    }
}
