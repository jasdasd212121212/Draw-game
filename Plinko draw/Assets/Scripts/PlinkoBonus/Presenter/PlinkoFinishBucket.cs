using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider2D))]
public class PlinkoFinishBucket : MonoBehaviour
{
    [SerializeField][Min(1)] private int _seflBonus = 1;

    [Inject] private PlinkoBonusModel _bonusModel;

    public int SeflBonus => _seflBonus;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SignatureMarcup_PlinkoBall>() != null)
        {
            _bonusModel.EvaluateBonus(_seflBonus);
        }
    }
}