using System;
using NUnit.Framework;
using Notebook;
using System.Globalization;

namespace Notebook.Tests
{
    public class NoteTests
    {
        Note note = new Note("test", "ToString() tests.");

        [Test]
        public void ToString_InvalidFormat_ThrowFormatException() =>
            Assert.Throws<FormatException>(() => note.ToString("test"));

        [Test]
        public void ToStringTests()
        {
            Assert.AreEqual("марта 05, 2020, test:\nToString() tests.", note.ToString());
            Assert.AreEqual("test.", note.ToString("S", CultureInfo.GetCultureInfo("en-US")));
            Assert.AreEqual("March 05, 2020, test.", note.ToString("E", CultureInfo.GetCultureInfo("en-US")));
            Assert.AreEqual("ToString() tests.", note.ToString("R", CultureInfo.GetCultureInfo("en-US")));
            Assert.AreEqual("March 05, 2020, test:\nToString() tests.", note.ToString("F", CultureInfo.GetCultureInfo("en-US")));
        }
    }
}