using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDSResource")]
    public class NewQVDSResource : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DSResource dsresource;
        [Parameter]
        public QlikView_CLI.QMSAPI.DSResourceType Dsresourcetype = default(QlikView_CLI.QMSAPI.DSResourceType);
        [Parameter]
        public System.String Errstatus;
        [Parameter]
        public System.Guid Id = Guid.NewGuid();
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Password;
        [Parameter]
        public System.String Path;
        [Parameter]
        public Dictionary<System.String, System.String> Settings = new Dictionary<System.String, System.String>();
        [Parameter]
        public System.String Type;
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            dsresource = new QlikView_CLI.QMSAPI.DSResource() { DSResourceType = Dsresourcetype, ErrStatus = Errstatus, Id = Id, Name = Name, Password = Password, Path = Path, Settings = Settings, Type = Type, Username = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(dsresource);
        }
    }
}
