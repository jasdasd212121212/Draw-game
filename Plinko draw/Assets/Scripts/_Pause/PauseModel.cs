using UnityEngine;

public class PauseModel
{
    public void SetPaused(bool isPaused) => Time.timeScale = isPaused == true ? 0 : 1; 
}