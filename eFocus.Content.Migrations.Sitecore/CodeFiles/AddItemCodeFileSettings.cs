using eFocus.CodeGeneration.CodeFiles;

namespace eFocus.Content.Migrations.Sitecore.CodeFiles
{
    public class AddItemCodeFileSettings : CodeFileSettings
    {
        public string Destination { get; set; }

        public string ItemName { get; set; }
        
        public string ItemId { get; set; }

        public string TemplateId { get; set; }
    }
}