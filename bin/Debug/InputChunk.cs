using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traverse
{
    class InputChunk
    {
        public string RawText { get; set; }
        public bool InQuotes { get; set; }
        public bool InBrackets { get; set; }

        public InputChunk(IOHandler parent, string text, bool inQuotes = false, bool inBrackets = false)
        {
            RawText = text;
            InQuotes = inQuotes;
            InBrackets = inBrackets;
        }
    }
}
