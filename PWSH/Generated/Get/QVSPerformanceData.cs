using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVQVSPerformanceData")]
    public class GetQVQVSPerformanceData : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.QueryTarget Target;
        private System.Collections.Generic.Dictionary<string, string> String;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == default)
            {
                qvsID = Connection.QlikViewServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvsID)
                {
                    String = Connection.client.GetQVSPerformanceData(obj, Target);
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
            WriteObject(String);
        }

    }

}
