using System.CodeDom;
using eFocus.CodeGeneration.CodeFiles;
using Sitecore.Data.Items;

namespace eFocus.Content.Migrations.Sitecore.CodeFiles
{
    public class AddItemCodeFile : CodeFile<AddItemCodeFileSettings>
    {
        public override void InitContents()
        {
            ClassName = Settings.ClassName;
            base.InitContents();

            TargetNamespace.Imports.Add(new CodeNamespaceImport("Sitecore.Data.Items"));
        }


        public override void AddMethods()
        {
            base.AddMethods();

            AddUpMethod();
            AddDownMethod();
            AddVerifyMethod();
        }


        private void AddUpMethod()
        {
            var upMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Name = "Up",
                ReturnType = new CodeTypeReference(typeof(Item))
            };

            var factoryObject = new CodePropertyReferenceExpression(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("Factory"), "Configuration"), "Sitecore");
            var masterDatabaseObject = new CodeMethodInvokeExpression(factoryObject, "GetDatabase", new CodePrimitiveExpression("master"));

            upMethod.Statements.Add(new CodeVariableDeclarationStatement("Sitecore.Configuration.Factory", "destination"));
            upMethod.Statements.Add(new CodeAssignStatement(new CodeVariableReferenceExpression("destination"),
                                                            new CodeMethodInvokeExpression(masterDatabaseObject, "GetItem", new CodePrimitiveExpression(Settings.Destination))));

            var dataEngineObject =
                new CodePropertyReferenceExpression(
                    new CodePropertyReferenceExpression(
                        new CodePropertyReferenceExpression(
                            new CodeVariableReferenceExpression("destination"),
                            "Database"),
                        "Engines"),
                    "DataEngine");
            var addFromTemplateInvokeStatement = new CodeMethodInvokeExpression(dataEngineObject, "AddFromTemplate", new CodePrimitiveExpression(Settings.ItemName), new CodePrimitiveExpression(Settings.TemplateId), new CodeVariableReferenceExpression("destination"), new CodePrimitiveExpression("id"));

            var returnStatement = new CodeMethodReturnStatement
            {
                Expression = addFromTemplateInvokeStatement
            };

            upMethod.Statements.Add(returnStatement);
            TargetClass.Members.Add(upMethod);
        }


        private void AddDownMethod()
        {
            
        }
        

        private void AddVerifyMethod()
        {
            
        }
    }
}