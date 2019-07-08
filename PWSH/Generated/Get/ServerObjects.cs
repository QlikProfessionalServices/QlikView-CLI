using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVServerObjects")]
    public class GetQVServerObjects : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public string Documentname;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServerObject> Serverobject = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServerObject>();

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
                    Serverobject = Connection.client.GetServerObjects(obj, Documentname);
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
            WriteObject(Serverobject);
        }

    }

}
