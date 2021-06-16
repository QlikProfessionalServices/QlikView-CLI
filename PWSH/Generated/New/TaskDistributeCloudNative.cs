using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributeCloudNative")]
    public class NewQVTaskDistributeCloudNative : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeCloudNative taskdistributecloudnative;
        [Parameter]
        public System.Guid Clouddeploymentid;
        [Parameter]
        public System.Boolean Sendclouddoc = new System.Boolean();
        [Parameter]
        public System.Boolean Sendcloudlink = new System.Boolean();
        [Parameter]
        public System.String Tags;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributecloudnative = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeCloudNative() { CloudDeploymentID = Clouddeploymentid, SendCloudDoc = Sendclouddoc, SendCloudLink = Sendcloudlink, Tags = Tags };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributecloudnative);
        }
    }
}
