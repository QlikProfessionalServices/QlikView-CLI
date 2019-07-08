using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDirectoryServiceObject")]
    public class NewQVDirectoryServiceObject : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DirectoryServiceObject directoryserviceobject;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Otherproperty;
        [Parameter]
        public QlikView_CLI.QMSAPI.DirectoryServiceObjectType Type = default(QlikView_CLI.QMSAPI.DirectoryServiceObjectType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            directoryserviceobject = new QlikView_CLI.QMSAPI.DirectoryServiceObject() { Name = Name, OtherProperty = Otherproperty, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(directoryserviceobject);
        }
    }
}
