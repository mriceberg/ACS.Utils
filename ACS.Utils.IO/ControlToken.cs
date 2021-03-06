namespace ACS.Utils.IO
{
    public abstract class ControlToken : Token
    {
        protected override void DoAccept(TokenVisitor visitor) => visitor.Visit(this);
    }
}
