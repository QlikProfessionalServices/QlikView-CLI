using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSMount")]
    public class NewQVQVSMount : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSMount qvsmount;
        [Parameter]
        public System.Boolean Browsable = new System.Boolean();
        [Parameter]
        public System.Guid Folderid;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Path;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsmount = new QlikView_CLI.QMSAPI.QVSMount() { Browsable = Browsable, FolderID = Folderid, Name = Name, Path = Path };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsmount);
        }
    }
}
