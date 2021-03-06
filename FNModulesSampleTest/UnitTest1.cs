using FNModulesSample.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using System.Collections.Generic;

namespace FNModulesSampleTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        private static ClassDeclarationSyntax CreateClass(string name)
        {

            return SyntaxFactory.ClassDeclaration(name).AddModifiers(new SyntaxToken[1] { SyntaxFactory.Token(SyntaxKind.PublicKeyword) });
        }

        [TestCase]
        public void PrintErrorNodeTest()
        {

            var compUnit = SyntaxFactory.CompilationUnit();
            var CLSList = new List<MemberDeclarationSyntax>();
            var NSList = new List<MemberDeclarationSyntax>();
            var USList = new List<UsingDirectiveSyntax>();
            var SCLS = CreateClass("CLS");
            var nsNode = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("NS"));

            var newnode = compUnit;
            var SCLSMethodLists = new List<MemberDeclarationSyntax>();
            USList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System")));
            MethodDeclarationSyntax methodkun = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("int"), SyntaxFactory.Identifier("Metkun"));
            var statements = new List<StatementSyntax>();
            var printM = new PrintErrorNodeModel
            {
                Value=""
            };
            statements.AddRange(printM.CompileSyntax());
            methodkun = methodkun.AddBodyStatements(statements.ToArray());
            SCLSMethodLists.Add(methodkun);
            SCLS = SCLS.AddMembers(SCLSMethodLists.ToArray());
            CLSList.Add(SCLS);
            nsNode = nsNode.AddMembers(CLSList.ToArray());
            NSList.Add(nsNode);
            newnode = newnode.AddUsings(USList.ToArray());
            newnode = newnode.AddMembers(NSList.ToArray());
            Assert.AreEqual("usingSystem;namespaceNS{publicclassCLS{intMetkun(){Console.Error.WriteLine(id_00000000_0000_0000_0000_000000000000_PrintErrcontent);}}}", newnode.ToString());
        }

    }
}