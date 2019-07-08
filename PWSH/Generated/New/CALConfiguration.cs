using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCALConfiguration")]
    public class NewQVCALConfiguration : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.CALConfiguration calconfiguration;
        [Parameter]
        public QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationDocumentCALs Documentcals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationDocumentCALs();
        [Parameter]
        public QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationNamedCALs Namedcals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationNamedCALs();
        [Parameter]
        public System.Guid QVSID;
        [Parameter]
        public QlikView_CLI.QMSAPI.CALConfigurationScope Scope = default(QlikView_CLI.QMSAPI.CALConfigurationScope);
        [Parameter]
        public QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationSessionCALs Sessioncals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationSessionCALs();
        [Parameter]
        public System.Boolean Uncapped = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationUsageCALs Usagecals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationUsageCALs();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            calconfiguration = new QlikView_CLI.QMSAPI.CALConfiguration() { DocumentCALs = Documentcals, NamedCALs = Namedcals, QVSID = QVSID, Scope = Scope, SessionCALs = Sessioncals, Uncapped = Uncapped, UsageCALs = Usagecals };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(calconfiguration);
        }
    }
}
