using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemDump
{
    public class ProblemInput
    {
        private static StringReader _stringReader;

        public ProblemInput(StringBuilder stringWriter)
        {
            _stringReader = new StringReader(stringWriter.ToString());
        }

        public bool InputRemaining()
        {
            return _stringReader.Peek() != -1;
        }

        public string GetInputLine()
        {
            return _stringReader.ReadLine();
        }
    }
}
