using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDistributionConfigValues")]
    public class NewQVDistributionConfigValues : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DistributionConfigValues distributionconfigvalues;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            distributionconfigvalues = new QlikView_CLI.QMSAPI.DistributionConfigValues() { };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(distributionconfigvalues);
        }
    }
}
