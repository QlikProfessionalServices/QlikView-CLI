using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributeDynamic")]
    public class NewQVTaskDistributeDynamic : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeDynamic taskdistributedynamic;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskDistributionDestination> Destinations = new List<QlikView_CLI.QMSAPI.TaskDistributionDestination>();
        [Parameter]
        public System.String Fieldname;
        [Parameter]
        public QlikView_CLI.QMSAPI.UserIdentityValueType Identitytype = default(QlikView_CLI.QMSAPI.UserIdentityValueType);
        [Parameter]
        public System.Boolean Validateemails = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributedynamic = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeDynamic() { Destinations = Destinations, FieldName = Fieldname, IdentityType = Identitytype, ValidateEmails = Validateemails };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributedynamic);
        }
    }
}
