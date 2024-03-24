using System;

namespace GameStore.Domain.Model
{
    public class Discount
    {
        public int Value { get; }

        private Discount(int value)
        {
            Value = value;
        }

        public static Discount Create(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Discount must be 0 to 100", nameof(value));
            }

            return new Discount(value);
        }

        internal Money ApplyOn(Money price)
        {
            var newMoneyValue = price.Value * (100 - Value) / 100;
            return Money.Create(newMoneyValue);
        }
    }
}
