using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Find, "QVTask")]
    public class FindQVTask : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.TaskType Tasktype;
        [Parameter]
        public string Name;
        private QlikView_CLI.QMSAPI.TaskInfo Taskinfo;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == null)
            {
                qdsID = Connection.QlikViewDistributionService.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qdsID)
                {
                    Taskinfo = Connection.client.FindTask(obj, Tasktype, Name);
                }

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
            WriteObject(Taskinfo);
        }

    }

}
