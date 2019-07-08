using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVFeature")]
    public class NewQVFeature : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Feature feature;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Valid;
        [Parameter]
        public System.String Value;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            feature = new QlikView_CLI.QMSAPI.Feature() { Name = Name, Valid = Valid, Value = Value };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(feature);
        }
    }
}
