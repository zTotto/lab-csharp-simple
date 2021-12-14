using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        public Complex Value { get; set; }
        public char? _operation = null; 
        private Complex temp = null;

        private bool PendingOperation() => temp != null;

        public char? Operation
        {
            get => _operation;
            set
            {
            if (PendingOperation())
            {
                ComputeResult();
            }
            _operation = value;
            temp = Value;
            Value = null;
            }
        }

        public void Reset()
        {
            _operation = null;
            temp = null;
            Value = null;
        }

        public void ComputeResult()
        {
            switch (_operation)
            {
                case OperationPlus:
                    Value = temp.Plus(Value);
                    break;
                case OperationMinus:
                    Value = temp.Minus(Value);
                    break;
                default:
                    break;
            }
            temp = null;
            _operation = null;
        }

        public override string ToString()
        {
            return (Value == null ? "null" : Value.ToString()) + 
                   " / " + (Operation == null ? "null" : $"{Operation}");
        }
    }
}