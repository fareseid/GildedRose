using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void Should_Print_Result_Over_Thirty_Days()
        {
            StringBuilder ActualOutput = new StringBuilder();
            Console.SetOut(new StringWriter(ActualOutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });

            string ExpectedOutput = BuildExpectedOutput();
            Assert.AreEqual(ExpectedOutput, ActualOutput.ToString());
        }

        private string BuildExpectedOutput()
        {
            return File.ReadAllText("ApprovalTest.ThirtyDays.received.txt");
        }
    }
}
