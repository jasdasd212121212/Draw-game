public class DisablingView : BoosterViewBase
{
    protected override void OnEnter()
    {
        gameObject.SetActive(false);
    }
}