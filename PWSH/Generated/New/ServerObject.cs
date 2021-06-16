using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVServerObject")]
    public class NewQVServerObject : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ServerObject serverobject;
        [Parameter]
        public System.String Id;
        [Parameter]
        public System.String Ownerid;
        [Parameter]
        public System.String Ownername;
        [Parameter]
        public System.Boolean Shared = new System.Boolean();
        [Parameter]
        public System.String Subtype;
        [Parameter]
        public System.Boolean Temporary = new System.Boolean();
        [Parameter]
        public System.String Type;
        [Parameter]
        public System.String Utcmodifytime;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            serverobject = new QlikView_CLI.QMSAPI.ServerObject() { Id = Id, OwnerId = Ownerid, OwnerName = Ownername, Shared = Shared, SubType = Subtype, Temporary = Temporary, Type = Type, UtcModifyTime = Utcmodifytime };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(serverobject);
        }
    }
}
