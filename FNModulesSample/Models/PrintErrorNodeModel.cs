using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Nodes;

namespace FNModulesSample.Models
{
	/// <summary>
    /// エラー
    /// </summary>
	public class PrintErrorNodeModel: CompileNodeBase
	{
        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        public PrintErrorNodeModel()
		{
		}

        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax()
        {
            List<StatementSyntax> returnstatements = new();


            returnstatements.Add(
                SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("Console.Error"),
                            SyntaxFactory.IdentifierName("WriteLine")
                        ),
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new ArgumentSyntax[1]{SyntaxFactory.Argument(
                                SyntaxFactory.IdentifierName("id_" + UUID.ToString().Replace("-", "_") + "_PrintErrcontent")
                            ) }

                    )
                ))));
            return returnstatements.ToArray(); 

        }
    }
}

