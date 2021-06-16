using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskGeneral")]
    public class NewQVTaskGeneral : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskGeneral taskgeneral;
        [Parameter]
        public System.String Distributiongroup;
        [Parameter]
        public System.Boolean Enabled = new System.Boolean();
        [Parameter]
        public System.String Taskdescription;
        [Parameter]
        public System.String Taskname;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskWizardTrack Taskwizardtrack = default(QlikView_CLI.QMSAPI.TaskWizardTrack);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskgeneral = new QlikView_CLI.QMSAPI.DocumentTask.TaskGeneral() { DistributionGroup = Distributiongroup, Enabled = Enabled, TaskDescription = Taskdescription, TaskName = Taskname, TaskWizardTrack = Taskwizardtrack };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskgeneral);
        }
    }
}
