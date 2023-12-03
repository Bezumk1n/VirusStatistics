using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VirusStatistics.Domain.Common
{
    public class Error
    {
        #region Properties
        public string Code { get; }
        public string Description { get; }
        public static readonly Error None = new Error(string.Empty, string.Empty);
        public static readonly Error NullValue = new Error("Error.NullValue", "Null value was provided");
        #endregion
        #region Constructor
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
        #endregion
        #region Methods
        public Result ToResult() => Result.Failure(this);
        public static implicit operator Result(Error error) => Result.Failure(error);
        #endregion

    }
}
