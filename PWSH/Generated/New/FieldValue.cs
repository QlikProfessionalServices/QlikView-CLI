using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVFieldValue")]
    public class NewQVFieldValue : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.FieldValue fieldvalue;
        [Parameter]
        public System.Boolean Isnumeric = new System.Boolean();
        [Parameter]
        public System.Double Number = new System.Double();
        [Parameter]
        public System.Int32 Sortorder = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.FieldValueState State = default(QlikView_CLI.QMSAPI.FieldValueState);
        [Parameter]
        public System.String Text;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            fieldvalue = new QlikView_CLI.QMSAPI.FieldValue() { IsNumeric = Isnumeric, Number = Number, SortOrder = Sortorder, State = State, Text = Text };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(fieldvalue);
        }
    }
}
