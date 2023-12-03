using System.Diagnostics.CodeAnalysis;

namespace VirusStatistics.Domain.Common
{
    public class Result
    {
        #region Properties
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        #endregion
        #region Constructor
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
                throw new ArgumentException("Invalid error", nameof(error));
            IsSuccess = isSuccess;
            Error = error;
        }
        #endregion
        #region Methods
        public static Result Success() => new(true, Error.None);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<TValue> Failure<TValue>(Error error) => new (default, false, error);
        #endregion
    }
    public class Result<TValue> : Result
    {
        public TValue Value { get; }
        public Result(TValue tValue, bool value, Error error) : base(value, error)
        {
            Value = tValue;
        }
    }
}
