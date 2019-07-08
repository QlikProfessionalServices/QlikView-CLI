using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignment")]
    public class NewQVAssignment : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Assignment assignment;
        [Parameter]
        public System.String Created;
        [Parameter]
        public System.String Excess;
        [Parameter]
        public System.String Id;
        [Parameter]
        public System.String Subject;
        [Parameter]
        public System.String Type;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assignment = new QlikView_CLI.QMSAPI.Assignment() { created = Created, excess = Excess, id = Id, subject = Subject, type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assignment);
        }
    }
}
