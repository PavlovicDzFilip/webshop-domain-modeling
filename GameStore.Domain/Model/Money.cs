using System;

namespace GameStore.Domain.Model
{
    public class Money
    {
        public double Value { get; }
        private Money(double value)
        {
            Value = value;
        }

        public static Money Create(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money must not be negative", nameof(value));
            }

            return new Money(value);
        }
    }
}
