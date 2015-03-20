using System;
using System.CodeDom;
using System.Reflection;
using eFocus.CodeGeneration.CodeFiles.IO;

namespace eFocus.CodeGeneration.CodeFiles
{
    public abstract class CodeFile<T> : ICodeFile where T : ICodeFileSettings
    {
        #region Properties

        public virtual T Settings { get; set; }


        private string _className;
        public string ClassName
        {
            get { return _className; }
            set
            {
                _className = value;
                TargetClass = null;
            }
        }
        

        private CodeCompileUnit _targetUnit;
        protected CodeCompileUnit TargetUnit
        {
            get { return _targetUnit ?? (_targetUnit = new CodeCompileUnit()); }
            set { _targetUnit = value; }
        }


        private CodeTypeDeclaration _targetClass;
        protected CodeTypeDeclaration TargetClass
        {
            get
            {
                return _targetClass ?? (_targetClass = new CodeTypeDeclaration(ClassName)
                {
                    IsClass = true,
                    TypeAttributes = TypeAttributes.Public,
                });
            }
            set { _targetClass = value; }
        }


        private CodeNamespace _targetNamespace;
        protected CodeNamespace TargetNamespace
        {
            get { return _targetNamespace ?? (_targetNamespace = new CodeNamespace(Settings.BaseNamespace)); }
            set { _targetNamespace = value; }
        }

        #endregion

        #region CodeGeneration methods
        
        public virtual void InitContents()
        {
            TargetNamespace.Types.Add(TargetClass);
            TargetUnit.Namespaces.Add(TargetNamespace);
        }


        public virtual void AddProperties()
        {
        }


        public virtual void AddConstructors()
        {
        }

        public virtual void AddMethods()
        {
        }

        #endregion

        #region Methods

        public bool Create(string fileName)
        {
            InitContents();
            AddProperties();
            AddConstructors();
            AddMethods();

            try
            {
                var writer = new CodeFileWriter(TargetUnit);
                writer.Write(fileName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}