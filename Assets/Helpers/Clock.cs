public class Clock{

    private float maxValue;
    private float value;

    public float Value{
        get { return value;}
    }

    public Clock(float max){
        maxValue = max;
        value = 0;
    }

    public bool tick(float inc)
    {
        value += inc;
        if (value >= maxValue)
        {
            value = 0;
            return true;
        }
        return false;
    }
}
