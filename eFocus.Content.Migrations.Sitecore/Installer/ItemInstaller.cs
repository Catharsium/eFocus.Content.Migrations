using Sitecore.Data;
using Sitecore.Data.Items;

namespace SitecoreContentMigrations.Source.Installer
{
    public class ItemInstaller
    {
        public Item CreateItem(string name, ID templateId, Item destination, string path, ID id)
        {
            return destination.Database.Engines.DataEngine.AddFromTemplate(name, templateId, destination, id);
        }
    }
}