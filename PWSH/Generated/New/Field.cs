using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVField")]
    public class NewQVField : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Field field;
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            field = new QlikView_CLI.QMSAPI.Field() { Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(field);
        }
    }
}
