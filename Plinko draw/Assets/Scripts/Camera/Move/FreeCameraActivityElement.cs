using UnityEngine;

public class FreeCameraActivityElement : MonoBehaviour, ILevelElementActiveSettable
{
    [SerializeField] private PlayerFollowCamera _followCamera;
    [SerializeField] private FreeCamera _freeCamera;

    public void SetActive(bool state)
    {
        _followCamera.enabled = !state;
        _freeCamera.enabled = state;
    }
}