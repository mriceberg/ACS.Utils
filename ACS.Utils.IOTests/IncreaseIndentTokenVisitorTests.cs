using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class IncreaseIndentTokenVisitorTests : BaseTokenVisitorTests<IncreaseIndentToken, TestIncreaseIndentToken>
    {
        protected override TestIncreaseIndentToken MakeTestToken() => new TestIncreaseIndentToken();
    }

    public class TestIncreaseIndentToken : IncreaseIndentToken, TestTokenFunctionality
    {
        public bool AcceptCalled { get; private set; }

        public TestIncreaseIndentToken()
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
