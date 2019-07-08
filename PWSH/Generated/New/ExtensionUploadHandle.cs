using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVExtensionUploadHandle")]
    public class NewQVExtensionUploadHandle : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ExtensionUploadHandle extensionuploadhandle;
        [Parameter]
        public System.Int64 Position = new System.Int64();
        [Parameter]
        public System.Guid Qvsclusterid;
        [Parameter]
        public System.Guid Qvsclustermemberid;
        [Parameter]
        public System.Int32 Qvshandle = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            extensionuploadhandle = new QlikView_CLI.QMSAPI.ExtensionUploadHandle() { Position = Position, QVSClusterID = Qvsclusterid, QVSClusterMemberID = Qvsclustermemberid, QVSHandle = Qvshandle };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(extensionuploadhandle);
        }
    }
}
