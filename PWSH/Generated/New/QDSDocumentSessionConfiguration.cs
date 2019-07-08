using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSDocumentSessionConfiguration")]
    public class NewQVQDSDocumentSessionConfiguration : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSDocumentSessionConfiguration qdsdocumentsessionconfiguration;
        [Parameter]
        public System.Boolean Clearlocks = new System.Boolean();
        [Parameter]
        public System.Boolean Clearoneandonlyone = new System.Boolean();
        [Parameter]
        public System.Boolean Clearselections = new System.Boolean();
        [Parameter]
        public System.String Encryptedsectionaccessusername;
        [Parameter]
        public System.String Filepath;
        [Parameter]
        public System.String Groupname;
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public System.Boolean Reduce = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdsdocumentsessionconfiguration = new QlikView_CLI.QMSAPI.QDSDocumentSessionConfiguration() { ClearLocks = Clearlocks, ClearOneAndOnlyOne = Clearoneandonlyone, ClearSelections = Clearselections, EncryptedSectionAccessUserName = Encryptedsectionaccessusername, FilePath = Filepath, GroupName = Groupname, QDSID = QDSID, Reduce = Reduce };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdsdocumentsessionconfiguration);
        }
    }
}
