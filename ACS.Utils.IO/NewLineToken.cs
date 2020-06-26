namespace ACS.Utils.IO
{
    public class NewLineToken : ControlToken
    {
        protected override void DoAccept(TokenVisitor visitor) => visitor.Visit(this);
    }
}
