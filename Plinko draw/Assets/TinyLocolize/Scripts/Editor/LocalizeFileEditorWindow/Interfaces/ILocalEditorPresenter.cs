using Cysharp.Threading.Tasks;

public interface ILocalEditorPresenter
{
    void Serialize(LocolizeNode[] nodes);
    void ReplaceNode(LocolizeNode oldNode, LocolizeNode newNode);
    void AddNode(string name);
    void RemoveNode(LocolizeNode node);
    void AddLanguage(LanguagesHolderScriptableObject holder); 
    void RemoveLanguage();
    LocolizeNode[] Deserialize();
    LocolizeDataTransferObject DeserializeData();
    UniTask Translate(LocolizeNode node);
    void Undo();
    void Rendo();
}