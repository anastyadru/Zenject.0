using UnityEngine;
using Zenject;

public class TimeController : MonoBehaviour
{
    public void SetPauseOn()
    {
        Time.timeScale = 0;
    }
    
    public void SetPauseOff()
    {
        Time.timeScale = 1;
    }
}