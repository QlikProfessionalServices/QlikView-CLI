using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDistributionGroupsDefinition")]
    public class GetQVDistributionGroupsDefinition : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DistributionConfigValues> Distributionconfigvalues = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DistributionConfigValues>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == default)
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
                    Distributionconfigvalues = Connection.client.GetDistributionGroupsDefinition(obj);
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
            WriteObject(Distributionconfigvalues);
        }

    }

}
