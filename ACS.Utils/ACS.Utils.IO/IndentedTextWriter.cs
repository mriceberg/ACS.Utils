using System.Text;

namespace ACS.Utils.IO
{
    public class IndentedTextWriter : TextWriter
    {
        private readonly TextWriter _writer;

        private int indentCount;
        private string indentText;
        private bool isFirstOnLine = true;

        public IndentedTextWriter(TextWriter writer, string indentText = "\t", int indentCount = 0)
        {
            if (String.IsNullOrEmpty(indentText)) throw new ArgumentNullException(nameof(indentText));
            if (indentCount < 0) throw new ArgumentOutOfRangeException();

            this._writer = writer;
            this.indentCount = indentCount;
            this.indentText = indentText;
        }

        public void IncreaseIndent() => indentCount++;
        public void DecreaseIndent()
        {
            if (indentCount == 0)
            {
                throw new InvalidOperationException("Indent is already 0.");
            }

            indentCount--;
        }
        public override Encoding Encoding => _writer.Encoding;
        public override void Write(char value)
        {
            if (((int)value == 13) || ((int)value == 10))
            { 
                isFirstOnLine = true;
            }
            else
            {
                if (isFirstOnLine)
                {
                    for (int i = 0; i < indentCount; i++)
                    {
                        foreach(var c in indentText)
                        {
                            _writer.Write(c);
                        }
                    }
                    isFirstOnLine = false;
                }
            }

            _writer.Write(value);
        }
    }
}