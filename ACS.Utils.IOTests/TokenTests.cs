using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class TokenTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Accept_NullVisitor_Throws()
        {
            Token actualToken = MakeToken();
            actualToken.Accept(null);
        }

        protected abstract Token MakeToken();
    }
}
