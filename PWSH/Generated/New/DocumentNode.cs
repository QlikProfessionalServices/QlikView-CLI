using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentNode")]
    public class NewQVDocumentNode : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentNode documentnode;
        [Parameter]
        public System.Guid Folderid;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.Boolean Isorphan = new System.Boolean();
        [Parameter]
        public System.Boolean Issubfolder = new System.Boolean();
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Relativepath;
        [Parameter]
        public System.Int32 Taskcount = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentType Type = default(QlikView_CLI.QMSAPI.DocumentType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentnode = new QlikView_CLI.QMSAPI.DocumentNode() { FolderID = Folderid, ID = ID, IsOrphan = Isorphan, IsSubFolder = Issubfolder, Name = Name, RelativePath = Relativepath, TaskCount = Taskcount, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentnode);
        }
    }
}
