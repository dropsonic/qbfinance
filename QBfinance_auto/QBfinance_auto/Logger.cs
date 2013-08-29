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
        string _fileName;
        StreamWriter _writer;
        bool _opened = false;

        public Logger(string fileName)
        {
            _fileName = fileName;
            _writer = File.CreateText(_fileName);
            _opened = true;
        }

        public void WriteLine(string line)
        {
            if (!_opened)
            {
                _writer = new StreamWriter(_fileName, true);
                _opened = true;
            }
            _writer.WriteLine(line);
            _writer.Flush();
        }

        public void Close()
        {
            _writer.Close();
            _opened = false;
        }
    }
}
