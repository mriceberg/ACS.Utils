using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass()]
    public abstract class ValueTokenTests<T> : TokenTests
    {
        [TestMethod]
        public void Constructor_ValueIsStored_OK()
        {
            T expectedValue = MakeTestValue();
            ValueToken<T> actualToken = MakeValueToken(value: expectedValue);

            T actualValue = actualToken.Value;

            Assert.AreSame(expectedValue, actualValue);
        }
        [TestMethod]
        public void Constructor_FormatterIsStored_OK()
        {
            ValueTokenFormatter<T> expectedFormatter = MakeTestFormatter();
            ValueToken<T> actualToken = MakeValueToken(formatter: expectedFormatter);

            ValueTokenFormatter<T> actualFormatter = actualToken.Formatter;

            Assert.AreSame(expectedFormatter, actualFormatter);
        }
        [TestMethod]
        public void Constructor_FormatterIsUsed_OK()
        {
            ValueTokenFormatter<T> formatter = MakeTestFormatter();
            T value = MakeTestValue();
            ValueToken<T> actualToken = MakeValueToken(value: value, formatter: formatter);

            string expectedText = GetExpectedTestText();
            string actualText = actualToken.ToString();

            Assert.AreEqual(expectedText, actualText);
        }

        protected override Token MakeToken() => MakeValueToken();
        protected abstract ValueToken<T> MakeValueToken(T value = default(T), ValueTokenFormatter<T> formatter = null);

        protected abstract T MakeTestValue();
        protected virtual ValueTokenFormatter<T> MakeTestFormatter() => new ConstantTestValueTokenFormatter<T>();
        protected virtual string GetExpectedTestText() => ConstantTestValueTokenFormatter<T>.DEFAULT_TEXT;
    }
}