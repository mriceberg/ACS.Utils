namespace ACS.Utils.IO
{
    public abstract class BaseTokenVisitor : TokenVisitor
    {
        public void Visit(Token token) => token.Accept(this);
        public void Visit(ControlToken token) => DoVisit(token);
        public void Visit<T>(ValueToken<T> token) => DoVisit(token);
        public void Visit(NewLineToken token) => DoVisit(token);
        public void Visit(IncreaseIndentToken token) => DoVisit(token);
        public void Visit(DecreaseIndentToken token) => DoVisit(token);

        protected abstract void DoVisit(ControlToken token);
        protected abstract void DoVisit<T>(ValueToken<T> token);
        protected abstract void DoVisit(NewLineToken token);
        protected abstract void DoVisit(IncreaseIndentToken token);
        protected abstract void DoVisit(DecreaseIndentToken token);
    }
}
