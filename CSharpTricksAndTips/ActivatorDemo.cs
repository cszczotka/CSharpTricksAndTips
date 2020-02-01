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

        [Test]
        public void CreateInstance()
        {            
           const string objectToInstantiate = "SampleProject.Domain.MyNewTestClass, CSharpTricksAndTips";
           var objectType = Type.GetType(objectToInstantiate);
           var instantiatedObject = Activator.CreateInstance(objectType);
           //var instantiatedObject = Activator.CreateInstance(typeof(MyNewTestClass));
           Assert.That(instantiatedObject.GetType().Name, Is.EqualTo("MyNewTestClass"));
        }

        [Test]
        public void CreateDynamicInstance()
        {
            const string objectToInstantiate = "SampleProject.Domain.MyNewTestClass, CSharpTricksAndTips";
            var objectType = Type.GetType(objectToInstantiate);
            dynamic instantiatedObject = Activator.CreateInstance(objectType) as ITestClass;
            
            Assert.That(instantiatedObject.DoSpecialThing(), Is.EqualTo("aaa !"));
        }

        [Test]
        public void CreateOtherInstance()
        {
            const string objectToInstantiate = "SampleProject.Domain.DifferentTestClass, CSharpTricksAndTips";

            var objectType = Type.GetType(objectToInstantiate);

            var instantiatedObject = Activator.CreateInstance(objectType) as ITestClass;

            // set a property value
            instantiatedObject.Name = "Other Test Name";
            // get a property value
            string name = instantiatedObject.Name;
            
            Assert.That(instantiatedObject.DoSpecialThing(), Is.EqualTo("bbb !"));
        }
    }


}

namespace SampleProject.Domain
{
    public class MyNewTestClass : ITestClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DoSpecialThing()
        {
            return "aaa !";
        }
    }

    public class DifferentTestClass : ITestClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DoSpecialThing()
        {
            return "bbb !";
        }
    }

    public interface ITestClass
    {
        int Id { get; set; }
        string Name { get; set; }
        string DoSpecialThing();
    }
}
