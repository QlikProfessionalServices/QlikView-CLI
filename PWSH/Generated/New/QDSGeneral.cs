using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSGeneral")]
    public class NewQVQDSGeneral : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSSettings.QDSGeneral qdsgeneral;
        [Parameter]
        public System.String Applicationdatafolder;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.QDSSettings.QDSClusterInfo> Clusterinfo = new List<QlikView_CLI.QMSAPI.QDSSettings.QDSClusterInfo>();
        [Parameter]
        public System.String Clustername;
        [Parameter]
        public System.Boolean Disabletasktriggersfordocadmins = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.LogLevel Loglevel = default(QlikView_CLI.QMSAPI.LogLevel);
        [Parameter]
        public System.Guid Selecteddscid;
        [Parameter]
        public System.Boolean Showalerts = new System.Boolean();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentFolder> Sourcefolders = new List<QlikView_CLI.QMSAPI.DocumentFolder>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdsgeneral = new QlikView_CLI.QMSAPI.QDSSettings.QDSGeneral() { ApplicationDataFolder = Applicationdatafolder, ClusterInfo = Clusterinfo, ClusterName = Clustername, DisableTaskTriggersForDocAdmins = Disabletasktriggersfordocadmins, LogLevel = Loglevel, SelectedDscID = Selecteddscid, ShowAlerts = Showalerts, SourceFolders = Sourcefolders };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdsgeneral);
        }
    }
}
