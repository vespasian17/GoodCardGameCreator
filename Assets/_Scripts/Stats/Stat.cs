public class Stat
{
    private int _currentGameValue;
    private int _maxValue;
    private int _defaultValue;

    public int CurrentGameValue => _currentGameValue;
    public int MaxValue => _maxValue;
    public int DefaultValue => _defaultValue;

    public Stat(int defaultValue, int maxValue)
    {
        this._defaultValue = defaultValue;
        this._currentGameValue = defaultValue;
        this._maxValue = maxValue;
    }

    public Stat()
    {
                
    }

    public void ChangeCurrentGameValue(int newValue)
    {
        _currentGameValue = newValue;
    }

    public void ResetValue()
    {
        _currentGameValue = DefaultValue;
    }
}
