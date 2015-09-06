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
            var result = new UniToken<string>(UniTokenType.Comment, STR_1);

            result.Type.Should().Be(UniTokenType.Comment, "the token type is given in the constructor");
            result.Value.Should().Be(STR_1, "string was given in the constructor");
        }
    }
}
