using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVSectionAccessColumn")]
    public class NewQVSectionAccessColumn : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessColumn sectionaccesscolumn;
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            sectionaccesscolumn = new QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessColumn() { Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(sectionaccesscolumn);
        }
    }
}
