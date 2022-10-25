using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Set, "QVQVWSAuthentication")]
    public class SetQVQVWSAuthentication : PSClient
    {
        [Parameter]
        public Guid[] qvwsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.QVWSAuthentication Authenticationtype;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvwsID == default)
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
                    Connection.client.SetQVWSAuthentication(obj, Authenticationtype);
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
