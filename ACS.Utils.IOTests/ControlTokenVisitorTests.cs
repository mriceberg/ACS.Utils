using ACS.Utils.IO;

namespace ACS.Utils.IOTests
{
    public abstract class ControlTokenVisitorTests : BaseTokenVisitorTests<ControlToken, TestControlToken>
    {
        protected override TestControlToken MakeTestToken() => new TestControlToken();
    }

    public class TestControlToken : ControlToken, TestTokenFunctionality
    {
        public bool AcceptCalled { get; private set; }

        public TestControlToken()
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
