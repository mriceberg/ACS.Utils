using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class DecreaseIndentTokenVisitorTests : BaseTokenVisitorTests<DecreaseIndentToken, TestDecreaseIndentToken>
    {
        protected override TestDecreaseIndentToken MakeTestToken() => new TestDecreaseIndentToken();
    }

    public class TestDecreaseIndentToken : DecreaseIndentToken, TestTokenFunctionality
    {
        public bool AcceptCalled { get; private set; }

        public TestDecreaseIndentToken()
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
