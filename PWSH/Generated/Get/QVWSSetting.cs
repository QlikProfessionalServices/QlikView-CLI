using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVQVWSSetting")]
    public class GetQVQVWSSetting : PSClient
    {
        [Parameter]
        public Guid[] qvwsID;

        private QlikView_CLI.QMSAPI.QVWSSettings Qvwssettings;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvwsID == null)
            {
                qvwsID = Connection.QlikViewWebServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvwsID)
                {
                    Qvwssettings = Connection.client.GetQVWSSetting(obj);
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
            WriteObject(Qvwssettings);
        }

    }

}
