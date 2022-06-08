using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVReports")]
    public class GetQVReports : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSDocumentSession Session;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.Report> Report = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.Report>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Report = Connection.client.GetReports(Session);

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
            WriteObject(Report);
        }

    }

}
