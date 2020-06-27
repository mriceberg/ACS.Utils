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

        [TestMethod]
        public void Accept_ValidVisitor_OK()
        {
            TestTokenVisitor actualVisitor = MakeTestTokenVisitor();
            Token actualToken = MakeToken();
            actualToken.Accept(actualVisitor);

            bool actualResult = actualVisitor.CorrectMethodWasCalled;

            Assert.IsTrue(actualResult);
        }

        protected abstract Token MakeToken();
        protected virtual Type GetTestedTokenType() => MakeToken().GetType();
        protected virtual TestTokenVisitor MakeTestTokenVisitor(bool throwIfCallIsNotAllowed = false, bool multipleCallsAllowed = false) 
            => new TestTokenVisitor(new Type[] { GetTestedTokenType() }, throwIfCallIsNotAllowed, multipleCallsAllowed);
    }
}
