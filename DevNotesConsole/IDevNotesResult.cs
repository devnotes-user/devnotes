using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDevNotesResult
    {
        string Result { get; }

        bool Success { get; }
    }
}
