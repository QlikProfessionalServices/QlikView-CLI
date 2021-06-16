using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTrigger")]
    public class NewQVTrigger : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Trigger trigger;
        [Parameter]
        public System.Boolean Enabled = new System.Boolean();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskTriggerType Type = default(QlikView_CLI.QMSAPI.TaskTriggerType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            trigger = new QlikView_CLI.QMSAPI.Trigger() { Enabled = Enabled, ID = ID, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(trigger);
        }
    }
}
