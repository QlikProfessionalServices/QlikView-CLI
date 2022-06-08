using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVServerObjectMetaDataForUser")]
    public class GetQVServerObjectMetaDataForUser : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public string User;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServerObjectMetaData> Serverobjectmetadata = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServerObjectMetaData>();

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
                    Serverobjectmetadata = Connection.client.GetServerObjectMetaDataForUser(obj, User);
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
            WriteObject(Serverobjectmetadata);
        }

    }

}
