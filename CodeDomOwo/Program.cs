using System;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace CodeDomOwo // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private const string outputFileName = "sampleOutput.cs";

        static void Main(string[] args)
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();


            CodeNamespace samples = new CodeNamespace("Samples");
            samples.Imports.Add(new CodeNamespaceImport("System"));


            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
            //Build the class
            CodeEntryPointMethod start = new CodeEntryPointMethod();

            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!"));

            start.Statements.Add(cs1);

            class1.Members.Add(start);

            samples.Types.Add(class1);

            compileUnit.Namespaces.Add(samples);

            //Generate the code
            CSharpCodeProvider provider = new CSharpCodeProvider();

            //provider.GenerateCodeFromCompileUnit(compileUnit, Console.Out, new CodeGeneratorOptions());

            //Build out the path
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), outputFileName);

            //Run the code
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, sw, new CodeGeneratorOptions());
            }
        }
    }
}