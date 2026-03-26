

namespace Tunnelnet.Utils.Animations;

public class Timer
{
    protected float _seconds;
    private float _elapsedSeconds;
    public Timer(float seconds)
    {
        _seconds = seconds;
        _elapsedSeconds = 0f;
    }

    public virtual void Update(bool loop = false)
    {
        if(_elapsedSeconds < _seconds)
        {
            _elapsedSeconds+= MainGame.DeltaTime;
        } else if(loop)
        {
            Reset();
        }
    }
    public void Reset()
    {
        _elapsedSeconds = 0f;
    }

    public bool Finished
    {
        get
        {
            return _elapsedSeconds >= _seconds;
        }
    }
    public float Progress
    {
        get
        {
            return _elapsedSeconds / _seconds;
        }
        set
        {
            _elapsedSeconds = _seconds * value;
        }
    }
}