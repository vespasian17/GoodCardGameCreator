using System;

[Serializable]
public class Stat
{
    public StatsType type;
    public int currentGameValue;
    public int maxValue;

    public Stat(StatsType type, int currentGameValue, int maxValue)
    {
        this.type = type;
        this.currentGameValue = currentGameValue;
        this.maxValue = maxValue;
    }

    public Stat()
    {
                
    }
}
