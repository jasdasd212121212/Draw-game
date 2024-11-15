using UnityEngine;
using Zenject;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField] private SignatureMarcup_PlinkoBall _ballPrefab;

    [Space]

    [SerializeField] private Vector2 _spred;
    [SerializeField][Min(1)] private int _minBallCount = 1;
    [SerializeField][Min(2)] private int _maxBallCount = 2;

    [Inject] private PlinkoBonusModel _model;

    private MonoFactory<SignatureMarcup_PlinkoBall> _ballsFactory;

    private void OnValidate()
    {
        _minBallCount = Mathf.Clamp(_minBallCount, 1, _maxBallCount);
    }

    private void Awake()
    {
        _ballsFactory = new MonoFactory<SignatureMarcup_PlinkoBall>(_ballPrefab, null);

        int ballsCount = Random.Range(_minBallCount, _maxBallCount);

        for (int i = 0; i < ballsCount; i++)
        {
            _ballsFactory.Create(
                    transform.position + new Vector3(Random.Range(-_spred.x, _spred.x), Random.Range(-_spred.y, _spred.y), 0), 
                    Quaternion.identity
                );
        }

        _model.SetBallsCount(ballsCount);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, _spred);
    }
}