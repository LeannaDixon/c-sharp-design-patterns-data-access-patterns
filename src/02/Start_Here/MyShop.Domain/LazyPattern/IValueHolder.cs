using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.LazyPattern
{
    public interface IValueHolder<T>
    {
        T GetValue(object parameter);
    }

    public class ValueHolder<T> : IValueHolder<T>
    {
        private readonly Func<object, T> getValue;
        private T value;

        public ValueHolder(Func<object, T> getValue)
        {
            this.getValue = getValue;
        }

        // ******Exposed to whoever is calling this.
        // Lazily initialised the 'value' field if it is not set already.
        public T GetValue(object parameter)
        {
            if (value == null)
            {
                // ******Value loader that loads the value for the parameter we pass in.
                // Sets the 'value' using a function that takes in a parameter and returns a value, based on the supplied parameter.
                value = getValue(parameter);
            }
            return value;
        }
    }
}
