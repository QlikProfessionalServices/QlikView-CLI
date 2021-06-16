using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSClusterInfo")]
    public class NewQVQDSClusterInfo : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSSettings.QDSClusterInfo qdsclusterinfo;
        [Parameter]
        public System.Int32 Dedicatedqvbdist = new System.Int32();
        [Parameter]
        public System.Int32 Dedicatedtaskgracetimeminutes = new System.Int32();
        [Parameter]
        public System.Boolean Dedicatedtaskrunalone = new System.Boolean();
        [Parameter]
        public List<System.String> Distributiongroups = new List<System.String>();
        [Parameter]
        public System.Int32 Maxclouddist = new System.Int32();
        [Parameter]
        public System.Int32 Maxqvbadmin = new System.Int32();
        [Parameter]
        public System.Int32 Maxqvbdist = new System.Int32();
        [Parameter]
        public System.Uri Url;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdsclusterinfo = new QlikView_CLI.QMSAPI.QDSSettings.QDSClusterInfo() { DedicatedQvbDist = Dedicatedqvbdist, DedicatedTaskGraceTimeMinutes = Dedicatedtaskgracetimeminutes, DedicatedTaskRunAlone = Dedicatedtaskrunalone, DistributionGroups = Distributiongroups, MaxCloudDist = Maxclouddist, MaxQvbAdmin = Maxqvbadmin, MaxQvbDist = Maxqvbdist, Url = Url };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdsclusterinfo);
        }
    }
}
