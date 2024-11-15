using Cysharp.Threading.Tasks;

public interface ILocalLoader
{
    UniTask<string> LoadLocal();
    string LoadLocalSync();

    UniTask WriteLocal(string text);
    void WriteLocalSync(string text);
}