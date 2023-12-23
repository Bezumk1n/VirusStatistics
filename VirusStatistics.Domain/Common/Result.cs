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
        public static Result Success() => new Result(true, Error.None);
        public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);
        public static Result Failure(Error error) => new Result(false, error);
        public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default, false, error);
        #endregion
    }
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;
        public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure can't be accessed");
        protected internal Result(TValue? tValue, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = tValue;
        }
        public static implicit operator Result<TValue>(TValue? value) => value is not null ? Success<TValue>(value) : Failure<TValue>(Error.NullValue);
    }
}
