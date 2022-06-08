using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVServerObject")]
    public class GetQVServerObject : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public string Documentname;
        [Parameter]
        public string Id;
        [Parameter]
        public string Owner;


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
                    Connection.client.TakeServerObject(obj, Documentname, Id, Owner);
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
            WriteObject(null);
        }

    }

}
