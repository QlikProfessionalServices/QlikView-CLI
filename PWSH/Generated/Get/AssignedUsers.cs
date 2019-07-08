using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVAssignedUsers")]
    public class GetQVAssignedUsers : PSClient
    {

        [Parameter]
        public string Additionalfilter;
        private QlikView_CLI.QMSAPI.Assignments Assignments;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Assignments = Connection.client.GetAssignedUsers(Additionalfilter);

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
            WriteObject(Assignments);
        }

    }

}
