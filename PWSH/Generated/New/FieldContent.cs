using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVFieldContent")]
    public class NewQVFieldContent : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.FieldContent fieldcontent;
        [Parameter]
        public System.String Name;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.FieldValue> Values = new List<QlikView_CLI.QMSAPI.FieldValue>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            fieldcontent = new QlikView_CLI.QMSAPI.FieldContent() { Name = Name, Values = Values };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(fieldcontent);
        }
    }
}
