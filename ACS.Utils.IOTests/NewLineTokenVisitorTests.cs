using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class NewLineTokenVisitorTests : BaseTokenVisitorTests<NewLineToken, TestNewLineToken>
    {
        protected override TestNewLineToken MakeTestToken() => new TestNewLineToken();
    }

    public class TestNewLineToken : NewLineToken, TestTokenFunctionality
    {
        public bool AcceptCalled { get; private set; }

        public TestNewLineToken()
        {
            this.AcceptCalled = false;
        }

        protected override void DoAccept(TokenVisitor visitor)
        {
            this.AcceptCalled = true;
            base.DoAccept(visitor);
        }
    }
}
