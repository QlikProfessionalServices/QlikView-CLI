using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Find, "QVEDX")]
    public class FindQVEDX : PSClient
    {

        [Parameter]
        public string Name;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskInfo> Taskinfo = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskInfo>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Taskinfo = Connection.client.FindEDX(Name);

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
