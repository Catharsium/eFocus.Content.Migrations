namespace eFocus.CodeGeneration.CodeFiles
{
    public interface ICodeFile
    {
        #region Properties

        string ClassName { get; set; }

        #endregion

        #region Methods

        bool Create(string fileName);

        #endregion
    }
}