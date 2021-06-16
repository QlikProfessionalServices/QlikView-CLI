using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSSettings")]
    public class NewQVQVSSettings : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings qvssettings;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSCluster Cluster = new QlikView_CLI.QMSAPI.QVSSettings.QVSCluster();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSDistribution Distribution = new QlikView_CLI.QMSAPI.QVSSettings.QVSDistribution();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments Documents = new QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSFolders Folders = new QlikView_CLI.QMSAPI.QVSSettings.QVSFolders();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSGeneral General = new QlikView_CLI.QMSAPI.QVSSettings.QVSGeneral();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSLogging Logging = new QlikView_CLI.QMSAPI.QVSSettings.QVSLogging();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance Performance = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance();
        [Parameter]
        public System.Guid QVSID;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettingsScope Scope = default(QlikView_CLI.QMSAPI.QVSSettingsScope);
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity Security = new QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvssettings = new QlikView_CLI.QMSAPI.QVSSettings() { Cluster = Cluster, Distribution = Distribution, Documents = Documents, Folders = Folders, General = General, Logging = Logging, Performance = Performance, QVSID = QVSID, Scope = Scope, Security = Security };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvssettings);
        }
    }
}
