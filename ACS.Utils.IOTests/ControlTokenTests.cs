using ACS.Utils.IO;

namespace ACS.Utils.IOTests
{
    public abstract class ControlTokenTests : TokenTests
    {
        protected override Token MakeToken() => MakeControlToken();
        protected abstract ControlToken MakeControlToken();

    }
}
