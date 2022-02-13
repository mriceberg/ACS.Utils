using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACS.Utils.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ACS.Utils.IO.Tests
{
    [TestClass()]
    public class IndentedTextWriterTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_EmptyIndentText_Throws()
        {
            using (var writer = new StringWriter())
            {
                new IndentedTextWriter(writer, String.Empty, 0);
            }
        }
        [TestMethod]
        public void Constructor_ExplicitIndentText_Used()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", 0);
                actualWriter.IncreaseIndent();
                actualWriter.Write("Hello");
                var actualText = writer.ToString();

                Assert.AreEqual("aaaHello", actualText);
            }
        }
        [TestMethod]
        public void Constructor_ExplicitIndentCount_Used()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", 1);
                actualWriter.Write("Hello");
                var actualText = writer.ToString();

                Assert.AreEqual("aaaHello", actualText);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeIndent_Throws()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", -1);
                actualWriter.DecreaseIndent();
            }
        }
        [TestMethod]
        public void IncrementIndent_Standard_IndentIncreases()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", 0);
                actualWriter.IncreaseIndent();
                actualWriter.IncreaseIndent();
                actualWriter.Write("Hello");
                var actualText = writer.ToString();

                Assert.AreEqual("aaaaaaHello", actualText);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DecreaseIndent_FromZero_Throws()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", 0);
                actualWriter.DecreaseIndent();
            }
        }
        [TestMethod]
        public void IncrementIndent_FromNonZero_IndentDecreases()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", 0);
                actualWriter.IncreaseIndent();
                actualWriter.IncreaseIndent();
                actualWriter.DecreaseIndent();
                actualWriter.Write("Hello");
                var actualText = writer.ToString();

                Assert.AreEqual("aaaHello", actualText);
            }
        }
        [TestMethod]
        public void Write_NewLine_StartsWithIndent()
        {
            using (var writer = new StringWriter())
            {
                var actualWriter = new IndentedTextWriter(writer, "aaa", 0);
                actualWriter.IncreaseIndent();
                actualWriter.WriteLine("Hello");
                actualWriter.Write("World");
                var actualText = writer.ToString();

                Assert.AreEqual($"aaaHello{Environment.NewLine}aaaWorld", actualText);
            }
        }
    }
}