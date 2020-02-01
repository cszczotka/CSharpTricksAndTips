using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console; //new feature 8

namespace CSharpTricksAndTips
{
    
    public class CSharp8Features
    {
        [Test]
        public void NullableReferenceTest()
        {

            string name = null; //warning CS8600: Converting null literal or possible null value to non-nullable type
            string? name2 = null;
           // WriteLine($"My name is {name2 ?? '?'}");

        }

        [Test]
        public void RangeTest()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var a1 = 2;
            var a2 = ^4;

            var slice = a[a1..a2];

            Assert.That(slice, Is.EqualTo(new int[]{3, 4, 5}));
        }
        
        [Test]
        public void NewTargetTypeExpression()
        {
            Month[] months = { new Month("January", 31), new Month("April", 30) };

            //Month[] months2 = { new ("January", 31), new ("April",30), new ("June",31) };

            

        } 

 
    }

    public class Month
    {
        public Month(String name, int days)
        {

        }
    }
}

