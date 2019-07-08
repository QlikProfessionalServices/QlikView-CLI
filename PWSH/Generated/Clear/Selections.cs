using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Clear, "QVSelections")]
    public class ClearQVSelections : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSDocumentSession Session;
        [Parameter]
        public string Fieldname;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentClearOptions Clearoptions;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Connection.client.ClearSelections(Session, Fieldname, Clearoptions);

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
            WriteObject(null);
        }

    }

}
