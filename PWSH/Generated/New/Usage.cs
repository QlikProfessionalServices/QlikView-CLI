using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVUsage")]
    public class NewQVUsage : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Usage usage;
        [Parameter]
        public System.String Class;
        [Parameter]
        public System.Int32 Minimum = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            usage = new QlikView_CLI.QMSAPI.Usage() { Class = Class, Minimum = Minimum };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(usage);
        }
    }
}
