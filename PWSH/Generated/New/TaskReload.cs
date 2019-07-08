using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReload")]
    public class NewQVTaskReload : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskReload taskreload;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskReloadMode Mode = default(QlikView_CLI.QMSAPI.TaskReloadMode);
        [Parameter]
        public System.String Scriptparametername;
        [Parameter]
        public System.String Scriptparametervalue;
        [Parameter]
        public System.String Scriptparametervaluefield1;
        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSectionAccessMode Sectionaccessmode = default(QlikView_CLI.QMSAPI.QDSSectionAccessMode);
        [Parameter]
        public System.String Sectionaccesspassword;
        [Parameter]
        public System.String Sectionaccessusername;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreload = new QlikView_CLI.QMSAPI.DocumentTask.TaskReload() { Mode = Mode, ScriptParameterName = Scriptparametername, ScriptParameterValue = Scriptparametervalue, ScriptParameterValueField1 = Scriptparametervaluefield1, SectionAccessMode = Sectionaccessmode, SectionAccessPassword = Sectionaccesspassword, SectionAccessUserName = Sectionaccessusername };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreload);
        }
    }
}
