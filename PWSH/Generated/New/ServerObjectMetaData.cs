using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVServerObjectMetaData")]
    public class NewQVServerObjectMetaData : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ServerObjectMetaData serverobjectmetadata;
        [Parameter]
        public System.String Documentname;
        [Parameter]
        public System.String Id;
        [Parameter]
        public System.String Ownerid;
        [Parameter]
        public System.Boolean Restricted = new System.Boolean();
        [Parameter]
        public System.Boolean Shared = new System.Boolean();
        [Parameter]
        public System.String Subtype;
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
            serverobjectmetadata = new QlikView_CLI.QMSAPI.ServerObjectMetaData() { DocumentName = Documentname, Id = Id, OwnerId = Ownerid, Restricted = Restricted, Shared = Shared, SubType = Subtype, Type = Type, UtcModifyTime = Utcmodifytime };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(serverobjectmetadata);
        }
    }
}
