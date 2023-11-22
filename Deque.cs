

public class Deque<T>
{
    public Deque()
    {
        _Train = new();
    }
    public void Push(T value)
    {
        _Train.Add(value);
    }

    public T Pop()
    {
        var value = _Train[^1];

        _Train.Remove(value);

        return value;
    }

    public void Unshift(T value)
    {
        _Train.Insert(0, value);
    }

    public T Shift()
    {
        var value = _Train[0];

        _Train.Remove(value);

        return value;
    }

    private List<T> _Train;
}