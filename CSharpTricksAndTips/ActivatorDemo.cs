using NUnit.Framework;
using SampleProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTricksAndTips
{
    public class ActivatorDemo
    {
        [Test]
        public void PrintAssemblyQualifiedName()
        {
            Console.WriteLine($"Assembly qualified name: {typeof(MyNewTestClass).AssemblyQualifiedName}");
        }
    }


}

namespace SampleProject.Domain
{
    public class MyNewTestClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DoSpecialThing()
        {
            return "My name is MyNewTestClass";
        }
    }
}
