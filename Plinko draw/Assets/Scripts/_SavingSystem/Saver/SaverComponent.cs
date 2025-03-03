using Cysharp.Threading.Tasks;

public class SaverComponent<T>
{
    private ISaveble<T> _target;
    private ISavingSystem _system;

    private string _saveKey;

    public SaverComponent(string saveKey, ISaveble<T> target, ISavingSystem savingSystem)
    {
        _target = target;
        _system = savingSystem;
        _saveKey = saveKey;

        _target.dataChecnged += OnDataChanged;

        Load().Forget();
    }

    ~SaverComponent()
    {
        if (_target != null)
        {
            Save(false).Forget();
            _target.dataChecnged -= OnDataChanged;
        }
    }

    private void OnDataChanged()
    {
        Save(false).Forget();
    }

    private async UniTask Save(bool isFirstSave)
    {
        T data = await _target.GetData(isFirstSave);

        await _system.Save(_saveKey, data);
    }

    private async UniTask Load()
    {
        if (await _system.HasKey(_saveKey) == false)
        {
            await Save(true);
            return;
        } 

        _target.SetData(await _system.Load<T>(_saveKey));
        await Save(false);
    }
}