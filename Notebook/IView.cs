using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    /// <summary>Provides functionality to represent notes in various forms.</summary>
    public interface IView
    {
        /// <summary>Render.</summary>
        public void Render();
    }
}
