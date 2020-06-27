using ACS.Utils.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.Utils.IOTests
{
    public class TestTokenVisitor : BaseTokenVisitor
    {
        public bool CorrectMethodWasCalled { get; private set; }
        public bool ThrowIfCallIsNotAllowed { get; private set; }
        public bool MultipleCallsAllowed { get; private set; }
        public IEnumerable<Type> AllowedTokenTypeCalls { get; private set; }

        public TestTokenVisitor(IEnumerable<Type> allowedTokenTypes, bool throwIfCallIsNotAllowed = false, bool multipleCallsAllowed = false)
        {
            this.AllowedTokenTypeCalls = allowedTokenTypes;
            this.CorrectMethodWasCalled = false;
            this.ThrowIfCallIsNotAllowed = throwIfCallIsNotAllowed;
            this.MultipleCallsAllowed = multipleCallsAllowed;
        }

        protected override void DoVisit(ControlToken token) => HandleCall(typeof(ControlToken));
        protected override void DoVisit<T>(ValueToken<T> token) => HandleCall(typeof(ValueToken<T>));
        protected override void DoVisit(NewLineToken token) => HandleCall(typeof(NewLineToken));
        protected override void DoVisit(DecreaseIndentToken token) => HandleCall(typeof(DecreaseIndentToken));
        protected override void DoVisit(IncreaseIndentToken token) => HandleCall(typeof(IncreaseIndentToken));

        private bool IsCallAllowed(Type tokenType) => AllowedTokenTypeCalls.Contains(tokenType);
        private void HandleCall(Type tokenType)
        {
            if (!IsCallAllowed(tokenType))
            {
                if (ThrowIfCallIsNotAllowed)
                {
                    throw new InvalidOperationException("Calling this method is not allowed.");
                }
            }
            else
            {
                if (CorrectMethodWasCalled && !MultipleCallsAllowed)
                {
                    throw new InvalidOperationException("Only one call is allowed.");
                }
                CorrectMethodWasCalled = true;
            }
        }
    }
}
