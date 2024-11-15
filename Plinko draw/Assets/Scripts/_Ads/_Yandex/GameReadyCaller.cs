using UnityEngine;

public class GameReadyCaller : MonoBehaviour
{
    private void Start()
    {
        Application.ExternalCall("GameReady");
    }
}