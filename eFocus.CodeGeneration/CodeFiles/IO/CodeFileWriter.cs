using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace eFocus.CodeGeneration.CodeFiles.IO
{
    public class CodeFileWriter
    {
        #region Properties

        private CodeCompileUnit TargetUnit { get; set; }


        private CodeDomProvider _provider;
        public CodeDomProvider Provider
        {
            get { return _provider ?? (Provider = CodeDomProvider.CreateProvider("CSharp")); }
            set { _provider = value; }
        }


        private CodeGeneratorOptions _options;
        public CodeGeneratorOptions Options
        {
            get { return _options ?? (Options = new CodeGeneratorOptions {BracingStyle = "C"}); }
            set { _options = value; }
        }

        #endregion

        #region Construction

        public CodeFileWriter(CodeCompileUnit targetUnit)
        {
            if (targetUnit == null) throw new NullReferenceException("'targetUnit' cannot be null.");
            TargetUnit = targetUnit;
        }

        #endregion

        #region Write

        public void Write(string fileName)
        {
            using (var sourceWriter = new StreamWriter(fileName))
            {
                Provider.GenerateCodeFromCompileUnit(TargetUnit, sourceWriter, Options);
            }
        }

        #endregion
    }
}