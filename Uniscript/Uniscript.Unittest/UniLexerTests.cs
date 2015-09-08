using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniscript;
using Uniscript.Tokens;

namespace Uniscript.Unittest
{
    /// <summary>
    /// Lexer unit tests.
    /// </summary>
    [TestClass]
    public class UniLexerTests
    {
        private const string Whitespace = "   \t\v";
        private UniLexer lexer;

        /// <summary>
        /// Initialize test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.lexer = new UniLexer();
        }

        /// <summary>
        /// Checks for exception if input string is null.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_NullString_ExceptionThrown()
        {
            Action action = () =>
            {
                this.lexer.Tokenize(null);
            };

            action.ShouldThrow<ArgumentNullException>("input string is null");
        }

        /// <summary>
        /// Ensures no errors on empty string.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_EmptyString_EmptyTokensEmptyErrors()
        {
            var result = this.lexer.Tokenize(string.Empty);

            result.Item1.Count().Should().Be(0, "no tokens in input string");
            result.Item2.Count().Should().Be(0, "no errors occurred");
        }

        /// <summary>
        /// Ensures no errors on whitespace string.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_Whitespace_EmptyTokensEmptyErrors()
        {
            var result = this.lexer.Tokenize(Whitespace);

            result.Item1.Count().Should().Be(0, "no tokens in input string");
            result.Item2.Count().Should().Be(0, "no errors occurred");
        }

        /// <summary>
        /// Checks for proper handling of single line comment.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_SingleComment_CorrectOutput()
        {
            var result = this.lexer.Tokenize("# Basic comment");

            result.Item1.Single().Type.Should().Be(UniTokenType.Comment, "only token is a comment, all whitespace is removed");
            result.Item1.Single().GetValue<string>().Should().Be("Basic comment");
            result.Item2.Count().Should().Be(0, "no errors in code");
        }

        /// <summary>
        /// Checks handling of comment with whitespace.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_SingleCommentWithWhitespace_CorrectOutput()
        {
            var result = this.lexer.Tokenize(" \r\n     #Basic comment        \r\n");

            result.Item1.Single().Type.Should().Be(UniTokenType.Comment, "only token is a comment, all whitespace is removed");
            result.Item1.Single().GetValue<string>().Should().Be("Basic comment");
            result.Item2.Count().Should().Be(0, "no errors in code");
        }

        /// <summary>
        /// Checks handling of comment with embedded comment char.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_SingleCommentWithEmbeddedCommentChar_CorrectOutput()
        {
            var result = this.lexer.Tokenize("#Basic #comment#");

            result.Item1.Single().Type.Should().Be(UniTokenType.Comment, "only token is a comment, all whitespace is removed");
            result.Item1.Single().GetValue<string>().Should().Be("Basic #comment#");
            result.Item2.Count().Should().Be(0, "no errors in code");
        }

        /// <summary>
        /// Checks handling of comment with embedded comment char.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_EmptyComment_CorrectOutput()
        {
            var result = this.lexer.Tokenize("\r\n#");

            result.Item1.Single().Type.Should().Be(UniTokenType.Comment, "only token is a comment, all whitespace is removed");
            result.Item1.Single().GetValue<string>().Should().Be(string.Empty);
            result.Item2.Count().Should().Be(0, "no errors in code");
        }

        /// <summary>
        /// Checks handling of comment with embedded comment char.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_WhitespaceComment_CorrectOutput()
        {
            var result = this.lexer.Tokenize("\r\n#   \t\v\r\n");

            result.Item1.Single().Type.Should().Be(UniTokenType.Comment, "only token is a comment, all whitespace is removed");
            result.Item1.Single().GetValue<string>().Should().Be(string.Empty);
            result.Item2.Count().Should().Be(0, "no errors in code");
        }

        /// <summary>
        /// Checks handling of comment with embedded comment char.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniLexer")]
        public void Tokenize_MultipleComments_CorrectOutput()
        {
            var result = this.lexer.Tokenize("\r\n#First  \r\n#  Second  ");

            result.Item1.Count().Should().Be(2, "there are two comments only in input");

            result.Item1.First().Type.Should().Be(UniTokenType.Comment);
            result.Item1.First().GetValue<string>().Should().Be("First");

            result.Item1.Last().Type.Should().Be(UniTokenType.Comment);
            result.Item1.Last().GetValue<string>().Should().Be("Second");

            result.Item1.Single().GetValue<string>().Should().Be(string.Empty);
            result.Item2.Count().Should().Be(0, "no errors in code");
        }
    }
}
