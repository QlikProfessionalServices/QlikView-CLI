using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDocumentLoadClusterSetting")]
    public class NewQVTaskDocumentLoadClusterSetting : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting.TaskDocumentLoadClusterSetting taskdocumentloadclustersetting;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentLoadMode Mode = default(QlikView_CLI.QMSAPI.DocumentLoadMode);
        [Parameter]
        public System.Guid Qlikviewserverclusternodeid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdocumentloadclustersetting = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting.TaskDocumentLoadClusterSetting() { Mode = Mode, QlikViewServerClusterNodeId = Qlikviewserverclusternodeid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdocumentloadclustersetting);
        }
    }
}
