using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class TokenVisitorTests : BaseTokenVisitorTests<Token, TestToken>
    {
        protected override bool AcceptShoudBeCalled => true;

        protected override TestToken MakeTestToken() => new TestToken();
    }
    public class TestToken : Token, TestTokenFunctionality
    {
        public bool AcceptCalled { get; private set; }

        public TestToken()
        {
            this.AcceptCalled = false;
        }

        protected override void DoAccept(TokenVisitor visitor)
        {
            this.AcceptCalled = true;
        }
    }
}
