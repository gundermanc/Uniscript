using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniscript.Tokens;

namespace Uniscript.Unittest.Tokens
{
    /// <summary>
    /// Token class unittests.
    /// </summary>
    [TestClass]
    public class UniTokenTests
    {
        private const string STR_1 = "string 1";

        /// <summary>
        /// Checks that values are stored and can be accessed appropriately.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniToken")]
        public void Constructor_ValuesGiven_AreStored()
        {
            var result = new UniToken(UniTokenType.Comment, STR_1);

            result.Type.Should().Be(UniTokenType.Comment, "the token type is given in the constructor");
            result.GetValue<string>().Should().Be(STR_1, "string was given in the constructor");
        }

        /// <summary>
        /// Checks for an exception when value is different type than requested.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("UniToken")]
        public void GetValue_InvalidType_ExceptionThrown()
        {
            var result = new UniToken(UniTokenType.Comment, STR_1);

            Action action = () =>
            {
                result.GetValue<int>();
            };

            action.ShouldThrow<UniInvalidTokenTypeException>("Requested GetValue type is int but value is string");
        }
    }
}
