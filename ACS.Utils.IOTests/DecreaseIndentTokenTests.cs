using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public class DecreaseIndentTokenTests : ControlTokenTests
    {
        protected override ControlToken MakeControlToken() => new DecreaseIndentToken();
    }
}
