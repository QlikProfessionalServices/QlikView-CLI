using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentMetaDataLicensing")]
    public class NewQVDocumentMetaDataLicensing : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataLicensing documentmetadatalicensing;
        [Parameter]
        public System.Boolean Allowdynamiccalassignment = new System.Boolean();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedNamedCAL> Assignedcals = new List<QlikView_CLI.QMSAPI.AssignedNamedCAL>();
        [Parameter]
        public System.Int32 Calsallocated = new System.Int32();
        [Parameter]
        public System.Int32 Calsembedded = new System.Int32();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedNamedCAL> Removedassignedcals = new List<QlikView_CLI.QMSAPI.AssignedNamedCAL>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentmetadatalicensing = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataLicensing() { AllowDynamicCALAssignment = Allowdynamiccalassignment, AssignedCALs = Assignedcals, CALsAllocated = Calsallocated, CALsEmbedded = Calsembedded, RemovedAssignedCALs = Removedassignedcals };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentmetadatalicensing);
        }
    }
}
