using ACS.Utils.IO;

namespace ACS.Utils.IOTests
{
    public class ConstantTestValueTokenFormatter<T> : ValueTokenFormatter<T>
    {
        public const string DEFAULT_TEXT = "TETS";

        public string ExpectedText { get; private set; }
        
        public ConstantTestValueTokenFormatter(string expectedText = DEFAULT_TEXT)
        {
            this.ExpectedText = expectedText;
        }

        public string Format(T value) => ExpectedText;
    }
}
