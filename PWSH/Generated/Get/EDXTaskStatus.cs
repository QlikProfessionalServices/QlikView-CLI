using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVEDXTaskStatus")]
    public class GetQVEDXTaskStatus : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public Guid Executionid;
        private QlikView_CLI.QMSAPI.EDXStatus Edxstatus;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == default)
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
                    Edxstatus = Connection.client.GetEDXTaskStatus(obj, Executionid);
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
            WriteObject(Edxstatus);
        }

    }

}
