using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusStatistics.Domain.Common
{
    public static class Ensure
    {
        public static void NotNullOrEmpty(string? value, string? paramName = default)
        { 
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }
    }
}
