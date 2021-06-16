using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskInfo")]
    public class NewQVTaskInfo : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskInfo taskinfo;
        [Parameter]
        public System.String Distributiongroup;
        [Parameter]
        public System.Boolean Enabled = new System.Boolean();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskType Type = default(QlikView_CLI.QMSAPI.TaskType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskinfo = new QlikView_CLI.QMSAPI.TaskInfo() { DistributionGroup = Distributiongroup, Enabled = Enabled, ID = ID, Name = Name, QDSID = QDSID, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskinfo);
        }
    }
}
