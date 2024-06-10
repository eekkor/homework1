using NUnit.Framework;
using System;

namespace RangeStruct.UnitTests
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void ConstructorTest()
        {
            var range = new Range(1, 10);
            Assert.That(range.A, Is.EqualTo(1));
            Assert.That(range.B, Is.EqualTo(10));
        }

        [TestCase(10, 5)]
        public void BSet_LessThanA_ArgumentException(int a, int b)
        {
            var range = new Range();
            range.A = a;
            Assert.That(() => range.B = b, Throws.ArgumentException);
        }

        [TestCase(1, 10, 9)]
        [TestCase(0, 0, 0)]
        public void CountTest(int a, int b, int expectedCount)
        {
            var range = new Range(a, b);
            Assert.That(range.Count, Is.EqualTo(expectedCount));
        }

        [TestCase(1, 10, 5, true)]
        [TestCase(1, 10, 10, false)]
        [TestCase(1, 10, 0, false)]
        public void IsContainsTest(int a, int b, int value, bool expected)
        {
            var range = new Range(a, b);
            Assert.That(range.IsContains(value), Is.EqualTo(expected));
        }

        [TestCase(1, 10, "[1; 10)")]
        [TestCase(0, 0, "[0; 0)")]
        public void ToStringTest(int a, int b, string expected)
        {
            var range = new Range(a, b);
            Assert.That(range.ToString(), Is.EqualTo(expected));
        }

        [TestCase(1, 10, 1, 10, true)]
        [TestCase(1, 10, 2, 10, false)]
        public void EqualsTest(int a1, int b1, int a2, int b2, bool expected)
        {
            var range1 = new Range(a1, b1);
            var range2 = new Range(a2, b2);
            Assert.That(range1.Equals(range2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var range = new Range();
            var obj = new object();
            Assert.That(() => range.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var range1 = new Range(1, 10);
            var range2 = new Range(1, 10);
            Assert.That(range1.GetHashCode(), Is.EqualTo(range2.GetHashCode()));
        }

        [TestCase(1, 5, 3, 10, 3, 5)]
        [TestCase(1, 5, 5, 10, 0, 0)]
        public void IntersectionTest(int a1, int b1, int a2, int b2, int expectedA, int expectedB)
        {
            var range1 = new Range(a1, b1);
            var range2 = new Range(a2, b2);
            var result = range1 & range2;
            Assert.That(result.A, Is.EqualTo(expectedA));
            Assert.That(result.B, Is.EqualTo(expectedB));
        }

        [TestCase(1, 5, 3, 10, 1, 10)]
        [TestCase(1, 5, 5, 10, 1, 10)]
        public void UnionTest(int a1, int b1, int a2, int b2, int expectedA, int expectedB)
        {
            var range1 = new Range(a1, b1);
            var range2 = new Range(a2, b2);
            var result = range1 | range2;
            Assert.That(result.A, Is.EqualTo(expectedA));
            Assert.That(result.B, Is.EqualTo(expectedB));
        }
    }
}
