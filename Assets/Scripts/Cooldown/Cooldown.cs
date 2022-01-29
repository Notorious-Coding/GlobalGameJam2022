using UnityEngine;
[System.Serializable]
public class Cooldown
{

    private float _started = 0f;
    private bool _isStarted;
    [SerializeField]
    private float _cooldown;
    public Cooldown(float seconds)
    {
        _cooldown = seconds;
    }
    public void Start()
    {
        _started = Time.time;
        _isStarted = true;
    }

    public void Stop()
    {
        _isStarted = false;
    }

    public bool isEnded
    {
        get
        {
            if (!_isStarted)
                return true;
            return Time.time > _started + _cooldown;
        }
    }
}
