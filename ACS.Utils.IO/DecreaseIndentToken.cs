namespace ACS.Utils.IO
{
    public class DecreaseIndentToken : ControlToken
    {
        protected override void DoAccept(TokenVisitor visitor) => visitor.Visit(this);
    }
}
