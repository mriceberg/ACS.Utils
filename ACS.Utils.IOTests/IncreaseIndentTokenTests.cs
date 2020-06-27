using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public class IncreaseIndentTokenTests : ControlTokenTests
    {
        protected override ControlToken MakeControlToken() => new IncreaseIndentToken();
    }
}
