using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Set, "QVQVWSSetting")]
    public class SetQVQVWSSetting : PSClient
    {
        [Parameter]
        public Guid[] qvwsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.QVWSSettings Qvwssetting;


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
                    Connection.client.SetQVWSSetting(obj, Qvwssetting);
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
            WriteObject(null);
        }

    }

}
