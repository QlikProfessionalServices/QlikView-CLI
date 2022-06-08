using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVFieldList")]
    public class GetQVFieldList : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSDocumentSession Session;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.Field> Field = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.Field>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Field = Connection.client.GetFieldList(Session);

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
            WriteObject(Field);
        }

    }

}
