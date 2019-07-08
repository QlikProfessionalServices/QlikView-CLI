using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsDiagnostic.Test, "QVPublisherQDS")]
    public class TestQVPublisherQDS : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        private bool Bool;

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
                    Bool = Connection.client.IsPublisherQDS(obj);
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
