using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVTaskStatusNodes")]
    public class GetQVTaskStatusNodes : PSClient
    {

        [Parameter]
        public System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskStatusNodeRequest> Taskstatusnoderequests;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusFilter Filter;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskStatusNode> Taskstatusnode = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskStatusNode>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Taskstatusnode = Connection.client.GetTaskStatusNodes(Taskstatusnoderequests, Filter, Scope);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Taskstatusnode);
        }

    }

}
