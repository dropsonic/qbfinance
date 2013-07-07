using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBfinance_auto
{
    public class Logger : ILogger
    {
        StreamWriter _writer;

        public Logger(string fileName)
        {
            _writer = File.CreateText(fileName);
        }

        public void WriteLine(string line)
        {
            _writer.WriteLine(line);
            _writer.Flush();
        }

        public void Close()
        {
            _writer.Close();
        }
    }
}
