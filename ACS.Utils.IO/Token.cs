using System;

namespace ACS.Utils.IO
{
    public abstract class Token
    {
        public void Accept(TokenVisitor visitor)
        {
            if (visitor != null)
            {
                DoAccept(visitor);
            }
            else
            {
                throw new ArgumentNullException(nameof(visitor));

            }
        }

        protected abstract void DoAccept(TokenVisitor visitor);
    }
}
