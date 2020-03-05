using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Notebook
{
    /// <summary>Provides methods for interaction with notebook.</summary>
    public class NoteBookService
    {
        private static readonly NoteBookService Instance = new NoteBookService();
        private readonly NoteBookCollection noteBook = new NoteBookCollection("My Book");

        private NoteBookService()
        {
        }

        /// <summary>Gets the NoteBookService instance.</summary>
        /// <returns>Returns NoteBookService instance.</returns>
        public static NoteBookService GetNoteBookServiceInstance() => Instance;

        /// <summary>Creates new note.</summary>
        /// <param name="title">Title of note.</param>
        /// <param name="content">Content of note.</param>
        public void CreateNote(string title, string content) => this.noteBook.CreateNote(title, content);

        /// <summary>Edits note.</summary>
        /// <param name="number">Number of note.</param>
        /// <param name="title">Title of note.</param>
        /// <param name="content">Content of note.</param>
        /// <exception cref="ArgumentException">Thrown when given number is invalid.</exception>
        /// <exception cref="ArgumentNullException">Thrown when content or title is null.</exception>
        public void EditNote(int number, string title, string content) => this.noteBook.EditNote(number, title, content);

        /// <summary>Removes note.</summary>
        /// <param name="number">Number of note.</param>
        public void RemoveNote(int number) => this.noteBook.RemoveNote(number);

        /// <summary>Gets the note.</summary>
        /// <param name="number">Number of note.</param>
        /// <returns>Returns copy of note.</returns>
        public Note GetNote(int number) => this.noteBook.GetNote(number);

        /// <summary>Gets notes.</summary>
        /// <returns>Returns read-only collection of notes.</returns>
        public ReadOnlyCollection<Note> GetNotes() => this.noteBook.GetNotes();

        /// <summary>Gets the number of notes.</summary>
        /// <returns>Returns number of notes.</returns>
        public int GetStat() => this.noteBook.GetStat();
    }
}
