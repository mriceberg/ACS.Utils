namespace ACS.Utils.IO
{
    public abstract class BaseTokenVisitor : TokenVisitor
    {
        public void Visit(Token token) => token.Accept(this);
        public void Visit(ControlToken token) => token.Accept(this);
    }
}
