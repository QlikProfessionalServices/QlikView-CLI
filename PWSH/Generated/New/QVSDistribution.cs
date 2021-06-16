using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSDistribution")]
    public class NewQVQVSDistribution : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSDistribution qvsdistribution;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.QVSSupervisionAccount> Accounts = new List<QlikView_CLI.QMSAPI.QVSSupervisionAccount>();
        [Parameter]
        public System.Boolean Ispublisherqds = new System.Boolean();
        [Parameter]
        public System.Guid QDSID;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsdistribution = new QlikView_CLI.QMSAPI.QVSSettings.QVSDistribution() { Accounts = Accounts, IsPublisherQDS = Ispublisherqds, QDSID = QDSID };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsdistribution);
        }
    }
}
