namespace ACS.Utils.IO
{
    public interface TokenVisitor
    {
        void Visit(Token token);

        void Visit(ControlToken token);
    }
}
