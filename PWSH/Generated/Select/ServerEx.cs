using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Select, "QVServerEx")]
    public class SelectQVServerEx : PSClient
    {
        [Parameter]
        public Guid[] qvwsID;

        [Parameter]
        public string Document;
        private Uri Uri;

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
                    Uri = Connection.client.SelectServerEx(obj, Document);
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
            WriteObject(Uri);
        }

    }

}
