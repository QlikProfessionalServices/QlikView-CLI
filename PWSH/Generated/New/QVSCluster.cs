using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSCluster")]
    public class NewQVQVSCluster : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSCluster qvscluster;
        [Parameter]
        public System.Int32 Alternatebuildnumber = new System.Int32();
        [Parameter]
        public System.String Alternatedocumentrootfolder;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSCluster.QVSClusterLicense License = new QlikView_CLI.QMSAPI.QVSSettings.QVSCluster.QVSClusterLicense();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.QVSClusterMember> Members = new List<QlikView_CLI.QMSAPI.QVSClusterMember>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvscluster = new QlikView_CLI.QMSAPI.QVSSettings.QVSCluster() { AlternateBuildNumber = Alternatebuildnumber, AlternateDocumentRootFolder = Alternatedocumentrootfolder, License = License, Members = Members };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvscluster);
        }
    }
}
