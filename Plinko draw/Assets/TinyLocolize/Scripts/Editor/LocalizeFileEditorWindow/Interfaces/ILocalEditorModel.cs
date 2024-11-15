public interface ILocalEditorModel
{
    LocolizeNode[] Nodes { get; }
    int LanguagesCount { get; }
    void Save(LocolizeNode[] nodes);
    void Save(LocolizeNode[] nodes, int languagesCount);
    LocolizeNode FindNodeOfName(string name);
    void IncrementLanguageCount();
    void DecrementLanguageCount();
    LocolizeNode[] Load();
}