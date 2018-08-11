using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSystem;
using FluentAssert;

namespace NumberSystemTests
{
    [TestClass]
    public class NumberConverterTests
    {
        private const string HexChars = "0123456789ABCDEF";

        [TestMethod]
        public void Hex_ToString()
        {
            var ns = new NumberConverter(HexChars);

            var result = ns.ToString(255);

            result.ShouldNotBeNull();
            result.ShouldBeEqualTo("FF");
        }

        [TestMethod]
        public void Hex_FromString()
        {
            var ns = new NumberConverter(HexChars);

            var result = ns.ToNumber("FF");

            result.ShouldBeEqualTo(255);
        }
    }
}