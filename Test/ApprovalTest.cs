using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace csharpTest.ApprovalTest
{
    [TestClass]
    public class ApprovalTest
    {
        [TestMethod]
        public void Should_Print_Result_Over_Thirty_Days()
        {
            StringBuilder ActualOutput = new StringBuilder();
            Console.SetOut(new StringWriter(ActualOutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });

            string ExpectedOutput = BuildExpectedOutput();
            AreEqual(ExpectedOutput, ActualOutput.ToString());
        }

        private string BuildExpectedOutput()
        {  
            return File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ApprovalTest.ThirtyDays.received.txt"));
        }
    }
}