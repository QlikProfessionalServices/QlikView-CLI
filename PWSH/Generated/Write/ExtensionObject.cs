using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommunications.Write, "QVExtensionObject")]
    public class WriteQVExtensionObject : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.ExtensionUploadHandle Handle;
        [Parameter]
        public byte[] Chunk;
        private QlikView_CLI.QMSAPI.ExtensionUploadHandle Extensionuploadhandle;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Extensionuploadhandle = Connection.client.WriteExtensionObject(Handle, Chunk);

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
