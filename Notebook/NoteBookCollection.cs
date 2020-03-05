using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Notebook
{
    /// <summary>Storage of notes.</summary>
    public class NoteBookCollection
    {
        /// <summary>Initializes a new instance of the <see cref="NoteBookCollection"/> class.</summary>
        /// <param name="noteBookOwner">Owner of the notebook.</param>
        /// <exception cref="ArgumentNullException">Thrown when noteBookOwner is null.</exception>
        public NoteBookCollection(string noteBookOwner)
        {
            this.NoteBookOwner = noteBookOwner ?? throw new ArgumentNullException(nameof(noteBookOwner));
            this.Notes = new Dictionary<int, Note>();
        }

        /// <summary>Gets or sets notebook owner.</summary>
        /// <value>Notebook owner.</value>
        public string NoteBookOwner { get; set; }

        /// <summary>Gets dictionary of notes.</summary>
        /// <value>Notes.</value>
        public Dictionary<int, Note> Notes { get; }

        /// <summary>Creates new note.</summary>
        /// <param name="title">Title of note.</param>
        /// <param name="content">Content of note.</param>
        /// <exception cref="ArgumentNullException">Thrown when content or title is null.</exception>
        internal void CreateNote(string title, string content)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var note = new Note(title, content);
            this.Notes.Add(this.GetStat() + 1, note);
        }

        /// <summary>Edits note.</summary>
        /// <param name="number">Number of note.</param>
        /// <param name="title">Title of note.</param>
        /// <param name="content">Content of note.</param>
        /// <exception cref="ArgumentException">Thrown when given number is invalid.</exception>
        /// <exception cref="ArgumentNullException">Thrown when content or title is null.</exception>
        internal void EditNote(int number, string title, string content)
        {
            if (number < 1 || number > this.GetStat())
            {
                throw new ArgumentException("Note with this number doesn't exist.");
            }

            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.Notes[number].Title = title;
            this.Notes[number].Content = content;
            this.Notes[number].TimeOfCreation = DateTime.Now;
        }

        /// <summary>Removes note.</summary>
        /// <param name="number">Number of note.</param>
        /// <exception cref="ArgumentException">Thrown when given number is invalid.</exception>
        internal void RemoveNote(int number)
        {
            if (number < 1 || number > this.GetStat())
            {
                throw new ArgumentException("Note with this number doesn't exist.");
            }

            this.Notes.Remove(number);
        }

        /// <summary>Gets the number of notes.</summary>
        /// <returns>Returns number of notes.</returns>
        internal int GetStat() => this.Notes.Count;

        /// <summary>Gets the note.</summary>
        /// <param name="number">Number of note.</param>
        /// <returns>Returns copy of note.</returns>
        /// <exception cref="System.ArgumentException">Thrown when number doesn't exist.</exception>
        internal Note GetNote(int number)
        {
            if (number < 1 || number > this.GetStat())
            {
                throw new ArgumentException("Note with this number doesn't exist.");
            }

            return new Note(this.Notes[number].Title, this.Notes[number].Content)
            {
                TimeOfCreation = this.Notes[number].TimeOfCreation,
            };
        }

        /// <summary>Gets notes.</summary>
        /// <returns>Returns read-only collection of notes.</returns>
        internal ReadOnlyCollection<Note> GetNotes()
        {
            var result = new Note[this.Notes.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.Notes[i + 1];
            }

            return new ReadOnlyCollection<Note>(result);
        }
    }
}
