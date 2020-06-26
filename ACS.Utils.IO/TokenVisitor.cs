namespace ACS.Utils.IO
{
    public interface TokenVisitor
    {
        void Visit(Token token);

        void Visit(ControlToken token);
        void Visit<T>(ValueToken<T> token);

        void Visit(NewLineToken token);
        void Visit(IncreaseIndentToken token);
        void Visit(DecreaseIndentToken token);
    }
}
