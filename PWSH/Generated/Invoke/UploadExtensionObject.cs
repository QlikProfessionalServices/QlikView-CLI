using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsLifecycle.Invoke, "QVUploadExtensionObject")]
    public class InvokeQVUploadExtensionObject : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        private QlikView_CLI.QMSAPI.ExtensionUploadHandle Extensionuploadhandle;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == null)
            {
                qvsID = Connection.QlikViewWebServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvsID)
                {
                    Extensionuploadhandle = Connection.client.InitiateUploadExtensionObject(obj);
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
            WriteObject(Extensionuploadhandle);
        }

    }

}
