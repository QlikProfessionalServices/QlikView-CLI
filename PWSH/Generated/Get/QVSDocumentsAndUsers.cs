using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVQVSDocumentsAndUsers")]
    public class GetQVQVSDocumentsAndUsers : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.QueryTarget Target;
        private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> List;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == null)
            {
                qvsID = Connection.QlikViewWebServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvsID)
                {
                    List = Connection.client.GetQVSDocumentsAndUsers(obj, Target);
                }

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
            WriteObject(List);
        }

    }

}
