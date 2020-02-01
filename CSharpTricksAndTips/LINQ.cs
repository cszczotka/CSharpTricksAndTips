using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Xml.Linq;
using System.Diagnostics;

namespace CSharpTricksAndTips
{
    public class LINQ
    {
        [Test]
        public void LINQWithArrayTest()
        {
            string[] instructors = { "Aaron", "Fritz", "Keith", "Scott" };

            IEnumerable<string> query = from n in instructors
                                        where n.Length == 5
                                        orderby n descending
                                        select n;

            CollectionAssert.AreEqual( new string[]{ "Scott", "Keith", "Fritz", "Aaron"}, query);

        }

        [Test]
        public void LINQWithXMLTest()
        {
            XElement instructors = XElement.Parse(
               @"<instructors>
                   <instructor>Aaron</instructor>
                   <instructor>Fritz</instructor>
                   <instructor>Keith</instructor>
                   <instructor>Scott</instructor>
                 </instructors>"
            );

            IEnumerable<string> query = from n in instructors.Elements("instructor")
                                        where n.Value.Length == 5
                                        orderby n.Value descending
                                        select n.Value;

            CollectionAssert.AreEqual(new string[] { "Scott", "Keith", "Fritz", "Aaron" }, query);

        }

        [Test]
        public void LINQWithObjectsTest()
        {
            List<Process> processList = new List<Process>(Process.GetProcesses());

            processList =processList.FindAll(delegate (Process p) {
                    return String.Equals(p.ProcessName, "svchost");
            });

            processList.Sort(delegate (Process p1, Process p2)
            {
                return p2.WorkingSet64.CompareTo(p1.WorkingSet64);
            });


            IEnumerable<Process> processList2 = from p in Process.GetProcesses() where String.Equals(p.ProcessName, "svchost") orderby p.WorkingSet64 descending select p;

            Assert.AreEqual(processList.Count(), processList2.Count());
        }

    }

}
