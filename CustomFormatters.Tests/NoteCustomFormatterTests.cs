using System;
using NUnit.Framework;
using CustomFormatters;
using System.Globalization;
using Notebook;

namespace CustomFormatters.Tests
{
    public class NoteCustomFormatterTests
    {
        private IFormatProvider customFormatter = new NoteCustomFormatter();
        private Note note = new Note("test", "Custom formatter test.");

        [Test]
        public void Format_InvariantFormat_ThrowsFormatException() =>
            Assert.Throws<FormatException>(() => string.Format(customFormatter, "{0:M}", note));

        [Test]
        [SetCulture("en-US")]
        public void FormatTests()
        {
            Assert.AreEqual("March 07, test: Custom formatter test.", string.Format(customFormatter, "{0:Q}", note));
        }
    }
}