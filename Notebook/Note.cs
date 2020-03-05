using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Notebook
{
    /// <summary>Provides methods and properties for interaction with notes.</summary>
    /// <seealso cref="System.IEquatable{Notebook.Note}" />
    /// <seealso cref="System.IComparable{Notebook.Note}" />
    public class Note : IEquatable<Note>, IComparable<Note>, IComparable
    {
        /// <summary>Initializes a new instance of the <see cref="Note"/> class.</summary>
        /// <param name="content">Content of note.</param>
        /// <param name="title">Title of note.</param>
        /// <exception cref="ArgumentNullException">Thrown when content is null.</exception>
        public Note(string title, string content)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.Title = title;
            this.Content = content;
            this.TimeOfCreation = DateTime.Now;
        }

        /// <summary>Gets or sets the title.</summary>
        /// <value>Title of note.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the content.</summary>
        /// <value>Content of note.</value>
        public string Content { get; set; }

        /// <summary>Gets or sets the time of creation.</summary>
        /// <value>Note creation time.</value>
        public DateTime TimeOfCreation { get; set; }

        /// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var note = obj as Note;
            return this.Equals(note);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <span class="keyword">
        ///     <span class="languageSpecificText">
        ///       <span class="cs">true</span>
        ///       <span class="vb">True</span>
        ///       <span class="cpp">true</span>
        ///     </span>
        ///   </span>
        ///   <span class="nu">
        ///     <span class="keyword">true</span> (<span class="keyword">True</span> in Visual Basic)</span> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <span class="keyword"><span class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> (<span class="keyword">False</span> in Visual Basic)</span>.
        /// </returns>
        public bool Equals(Note other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return this.Title.Equals(other.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="other" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="other" />.
        /// Greater than zero
        /// This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when other is null.</exception>
        public int CompareTo(Note other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return string.Compare(this.Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{this.Title}, {this.TimeOfCreation.ToString(CultureInfo.InvariantCulture)}: {this.Content}";
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="obj" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="obj" />.
        /// Greater than zero
        /// This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when obj isn't Note.</exception>
        /// <exception cref="ArgumentNullException">Thrown when obj is null.</exception>
        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var otherNote = obj as Note;
            return otherNote != null ? this.CompareTo(otherNote) : throw new ArgumentException($"{nameof(obj)} isn't Note.");
        }
    }
}
