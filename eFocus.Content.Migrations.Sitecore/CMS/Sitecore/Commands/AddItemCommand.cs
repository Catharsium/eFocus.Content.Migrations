using System.Collections.Specialized;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace eFocus.Content.Migrations.Sitecore.CMS.Sitecore.Commands
{
    public class AddItemCommand : Command
    {
        public override void Execute(CommandContext context)
        {
            Error.AssertObject(context, "context");
            if (context.Items.Length != 1) return;

            var contextItem = context.Items[0];
            var parameters = new NameValueCollection();
            parameters["id"] = contextItem.ID.ToString();
            parameters["language"] = contextItem.Language.ToString();
            parameters["version"] = contextItem.Version.ToString();
            Context.ClientPage.Start(this, "Run", parameters);
        }


        protected void Run(ClientPipelineArgs args)
        {
            var parameters = new UrlString();
            parameters.Add("id", args.Parameters["id"]);
            parameters.Add("language", args.Parameters["language"]);
            parameters.Add("version", args.Parameters["version"]);
        }
    }
}