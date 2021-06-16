using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCategory")]
    public class NewQVCategory : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Category category;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            category = new QlikView_CLI.QMSAPI.Category() { ID = ID, Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(category);
        }
    }
}
