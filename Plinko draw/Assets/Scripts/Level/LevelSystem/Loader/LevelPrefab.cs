using UnityEngine;

public class LevelPrefab : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private float _additionalDeepenesOfLevel;
    [SerializeField][Min(2)] private int _drawAmount = 10;

    public Finish Finish => _finish;
    public float Deepenes => GetLowerPositionOfLevelObject().y + _additionalDeepenesOfLevel;
    public int DrawAmount => _drawAmount;

    private Vector3 GetLowerPositionOfLevelObject()
    {
        Transform[] objects = GetComponentsInChildren<Transform>();

        if (objects == null || objects.Length == 0)
        {
            return Vector3.zero;
        }

        int minimalIndex = 0;
        float minimalY = float.MaxValue;

        for (int i = 0; i < objects.Length; i++)
        {
            float currentPosition = objects[i].position.y;

            if (currentPosition < minimalY)
            {
                minimalY = currentPosition;
                minimalIndex = i;
            }
        }

        return objects[minimalIndex].position;
    }
}