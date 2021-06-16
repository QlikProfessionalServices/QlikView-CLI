using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVSectionAccessRow")]
    public class NewQVSectionAccessRow : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessRow sectionaccessrow;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessCell> Cells = new List<QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessCell>();
        [Parameter]
        public System.Int32 Rownumber = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            sectionaccessrow = new QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessRow() { Cells = Cells, RowNumber = Rownumber };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(sectionaccessrow);
        }
    }
}
