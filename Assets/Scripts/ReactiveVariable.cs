using System;


public class ReactiveVariable<T> where T : IEquatable<T>
{
    public event Action<T, T> Changed;

    private T _value;

    public ReactiveVariable () => _value = default(T);

    public ReactiveVariable (T value) => _value = value;

    public T Value
    {
        get => _value;
        set
        {
            T previousValue = _value;

            _value = value;

            if (_value.Equals(previousValue) == false)
            {
                Changed?.Invoke(previousValue, _value);
            }
        }
    }
}
