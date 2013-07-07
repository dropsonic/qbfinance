using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBfinance_auto
{
    public interface ILogger
    {
        void WriteLine(string line);
        void Close();
    }
}
