using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVSectionAccessTables")]
    public class GetQVSectionAccessTables : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.SectionAccessScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.SectionAccessTable> Sectionaccesstable = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.SectionAccessTable>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Sectionaccesstable = Connection.client.GetSectionAccessTables(Scope);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Sectionaccesstable);
        }

    }

}
