using UnityEngine;

public class GameReadyCaller : MonoBehaviour
{
    [SerializeField][Min(0.1f)] private float _callDellay = 0.1f;

    private void Start()
    {
        Invoke(nameof(CallAPI), _callDellay);
    }

    private void CallAPI()
    {
        Application.ExternalCall("GameReady");
    }
}