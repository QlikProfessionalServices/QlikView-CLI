using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Close, "QVAndInstallExtensionObject")]
    public class CloseQVAndInstallExtensionObject : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.ExtensionUploadHandle Handle;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.QVSMessage> Qvsmessage = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.QVSMessage>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Qvsmessage = Connection.client.CloseAndInstallExtensionObject(Handle);

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
            WriteObject(Qvsmessage);
        }

    }

}
