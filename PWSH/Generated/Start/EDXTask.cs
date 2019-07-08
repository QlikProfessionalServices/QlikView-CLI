using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsLifecycle.Start, "QVEDXTask")]
    public class StartQVEDXTask : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public string Tasknameorid;
        [Parameter]
        public string Password;
        [Parameter]
        public string Variablename;
        [Parameter]
        public System.Collections.Generic.List<string> Variablevalues;
        private QlikView_CLI.QMSAPI.TriggerEDXTaskResult Triggeredxtaskresult;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == null)
            {
                qdsID = Connection.QlikViewDistributionService.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qdsID)
                {
                    Triggeredxtaskresult = Connection.client.TriggerEDXTask(obj, Tasknameorid, Password, Variablename, Variablevalues);
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
            WriteObject(Triggeredxtaskresult);
        }

    }

}
