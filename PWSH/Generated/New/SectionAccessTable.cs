using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVSectionAccessTable")]
    public class NewQVSectionAccessTable : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.SectionAccessTable sectionaccesstable;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessColumn> Columns = new List<QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessColumn>();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Name;
        [Parameter]
        public List<System.String> Roles = new List<System.String>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessRow> Rows = new List<QlikView_CLI.QMSAPI.SectionAccessTable.SectionAccessRow>();
        [Parameter]
        public QlikView_CLI.QMSAPI.SectionAccessScope Scope = default(QlikView_CLI.QMSAPI.SectionAccessScope);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            sectionaccesstable = new QlikView_CLI.QMSAPI.SectionAccessTable() { Columns = Columns, ID = ID, Name = Name, Roles = Roles, Rows = Rows, Scope = Scope };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(sectionaccesstable);
        }
    }
}
