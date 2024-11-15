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

        _target.dataChecnged += Save;

        Load().Forget();
    }

    ~SaverComponent()
    {
        if (_target != null)
        {
            Save();
            _target.dataChecnged -= Save;
        }
    }

    private void Save()
    {
        _system.Save(_saveKey, _target.GetData());
    }

    private async UniTask Load()
    {
        if (await _system.HasKey(_saveKey) == false)
        {
            Save();
            return;
        }

        _target.SetData(await _system.Load<T>(_saveKey));
    }
}