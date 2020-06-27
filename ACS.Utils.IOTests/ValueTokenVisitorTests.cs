using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class ValueTokenVisitorTests<T> : BaseTokenVisitorTests<ValueToken<T>, TestValueToken<T>>
    {
        protected override TestValueToken<T> MakeTestToken() => new TestValueToken<T>(GetTestTokenValue());

        protected abstract T GetTestTokenValue();
    }

    public class TestValueToken<T> : ValueToken<T>, TestTokenFunctionality
    {
        public bool AcceptCalled { get; private set; }

        public TestValueToken(T value)
            : base(value)
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
