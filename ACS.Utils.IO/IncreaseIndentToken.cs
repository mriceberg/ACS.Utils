namespace ACS.Utils.IO
{
    public class IncreaseIndentToken : ControlToken
    {
        protected override void DoAccept(TokenVisitor visitor) => visitor.Visit(this);
    }
}
