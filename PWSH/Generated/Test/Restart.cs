using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsDiagnostic.Test, "QVRestart")]
    public class TestQVRestart : PSClient
    {

        [Parameter]
        public string Reason;[Parameter]
        public Guid[] qvsID;

        private bool Bool;

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
                    Bool = Connection.client.QVSNeedRestart(obj, Reason);
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
            WriteObject(Bool);
        }

    }

}
