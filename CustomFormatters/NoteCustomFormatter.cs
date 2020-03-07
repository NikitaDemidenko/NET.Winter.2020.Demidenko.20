using System;
using System.Threading;
using Notebook;

namespace CustomFormatters
{
    /// <summary>Provides custom formatter for <see cref="Note"/> class.</summary>
    /// <seealso cref="IFormatProvider" />
    /// <seealso cref="ICustomFormatter" />
    public class NoteCustomFormatter : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider parent;

        /// <summary>Initializes a new instance of the <see cref="NoteCustomFormatter"/> class.</summary>
        public NoteCustomFormatter()
            : this(Thread.CurrentThread.CurrentCulture)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NoteCustomFormatter"/> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <exception cref="ArgumentNullException">Thrown when parent is null.</exception>
        public NoteCustomFormatter(IFormatProvider parent)
        {
            this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.</summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>The string representation of the value of <paramref name="arg" />, formatted as specified by <paramref name="format" /> and <paramref name="formatProvider" />.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is null || !(arg is Note) || !(format == "Q" || format == "q"))
            {
                return string.Format(this.parent, "{0:" + format + "}", arg);
            }

            var note = arg as Note;
            return $"{note.TimeOfCreation.ToString("MMMM dd", formatProvider)}, {note.Title.ToString(formatProvider)}: {note.Content.ToString(formatProvider)}";
        }

        /// <summary>Returns an object that provides formatting services for the specified type.</summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType" />, if the <see cref="IFormatProvider"/> implementation can supply that type of object; otherwise, <span class="keyword"><span class="languageSpecificText"><span class="cs">null</span><span class="vb">Nothing</span><span class="cpp">nullptr</span></span></span><span class="nu">a null reference (<span class="keyword">Nothing</span> in Visual Basic)</span>.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }
    }
}
