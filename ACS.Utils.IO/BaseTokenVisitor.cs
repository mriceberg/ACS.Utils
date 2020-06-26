namespace ACS.Utils.IO
{
    public abstract class BaseTokenVisitor : TokenVisitor
    {
        public void Visit(Token token) => token.Accept(this);
        public void Visit(ControlToken token) => token.Accept(this);
        public void Visit<T>(ValueToken<T> token) => token.Accept(this);
        public void Visit(NewLineToken token) => token.Accept(this);
        public void Visit(IncreaseIndentToken token) => token.Accept(this);
        public void Visit(DecreaseIndentToken token) => token.Accept(this);
    }
}
