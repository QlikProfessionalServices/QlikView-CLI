using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVSectionAccessCell")]
    public class NewQVSectionAccessCell : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessCell sectionaccesscell;
        [Parameter]
        public System.String Value;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            sectionaccesscell = new QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessCell() { Value = Value };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(sectionaccesscell);
        }
    }
}
