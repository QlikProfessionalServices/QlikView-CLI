using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistribute")]
    public class NewQVTaskDistribute : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute taskdistribute;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeCloudNative Cloudnativelinks = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeCloudNative();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeDynamic Dynamic = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeDynamic();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeNotification Notification = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeNotification();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput Output = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeStatic Static = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeStatic();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistribute = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute() { CloudNativeLinks = Cloudnativelinks, Dynamic = Dynamic, Notification = Notification, Output = Output, Static = Static };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistribute);
        }
    }
}
