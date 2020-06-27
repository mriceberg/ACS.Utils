using ACS.Utils.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACS.Utils.IOTests
{
    [TestClass]
    public abstract class BaseTokenVisitorTests<TokenType, TestTokenType>
        where TokenType: Token
        where TestTokenType: TokenType, TestTokenFunctionality
    {
        protected virtual bool AcceptShoudBeCalled => false;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Visit_NullToken_Throws()
        {
            TokenVisitor actualVisitor = MakeTokenVisitor();
            actualVisitor.Visit(null as TokenType);

            Assert.Fail("An exception should have been thrown.");
        }
        [TestMethod]
        public void VisitToken_ValidTokenAcceptIsCalled_OK()
        {
            TokenVisitor actualVisitor = MakeTokenVisitor();
            TestTokenType actualToken = MakeTestToken();

            actualVisitor.Visit(actualToken as TokenType);

            bool actualValue = actualToken.AcceptCalled;

            if (AcceptShoudBeCalled)
            {
                Assert.IsTrue(actualValue);
            }
            else
            {
                Assert.IsFalse(actualValue);
            }
        }

        protected abstract TokenVisitor MakeTokenVisitor();
        protected abstract TestTokenType MakeTestToken();
    }
}
