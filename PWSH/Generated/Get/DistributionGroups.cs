using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDistributionGroups")]
    public class GetQVDistributionGroups : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        private System.Collections.Generic.List<string> String = new System.Collections.Generic.List<string>();

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
                    String = Connection.client.GetDistributionGroups(obj);
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
