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
        public T GetValue(object parameter)
        {
            // ******Value loader that loads the value for the parameter we pass in.
            if (value == null)
            {
                value = getValue(parameter);
            }
            return value;
        }
    }
}
