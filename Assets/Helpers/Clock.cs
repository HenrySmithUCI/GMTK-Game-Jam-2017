public class Clock{

    private float maxValue;
    private float value;
    public bool paused;

    public float Value{
        get { return value;}
        set { this.value = value;}
    }

    public float MaxValue{
        get { return maxValue; }
    }

    public Clock(float max){
        maxValue = max;
        value = 0;
    }

    public bool tick(float inc)
    {
        if (paused)
            return false;
        value += inc * TimeManager.TimeScale;
        if (value >= maxValue)
        {
            value = 0;
            return true;
        }
        return false;
    }

    public void reset()
    {
        value = 0;
    }

    public void maxOut()
    {
        value = maxValue;
    }
}
