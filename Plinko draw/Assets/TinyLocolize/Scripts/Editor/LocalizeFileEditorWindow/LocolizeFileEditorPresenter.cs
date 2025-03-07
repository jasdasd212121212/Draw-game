using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocolizeFileEditorPresenter : ILocalEditorPresenter
{
    private ILocalEditorModel _model;
    private LocolizeFileEditorUndoModel _undoModel;

    private GoogleTranslate _translater;
    private LanguagesHolderScriptableObject _languagesHolderScriptableObject;

    public LocolizeFileEditorPresenter(ILocalEditorModel model, LocolizeFileEditorUndoModel undoModel)
    {
        _model = model;
        _undoModel = undoModel;
        
        _translater = new GoogleTranslate();
        _languagesHolderScriptableObject = Resources.Load<LanguagesHolderScriptableObject>(LocolizeEditroConstantsHolder.LANGIAGES_HOLDER_PATH);
    }

    public void Serialize(LocolizeNode[] nodes)
    {
        _model.Save(nodes);
    }

    public void ReplaceNode(LocolizeNode oldNode, LocolizeNode newNode)
    {
        LocolizeNode[] nodes = _model.Nodes;

        if (oldNode.Key != newNode.Key && ContainsKey(newNode.Key, nodes) == true)
        {
            Debug.LogError($"Critical error -> can`t replace <{oldNode.Key}> to <{newNode.Key}> because key: {newNode.Key} early be adden into locolize file");
            return;
        }

        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].Key == oldNode.Key)
            {
                nodes[i] = newNode;

                Serialize(nodes);
                return;
            }
        }
    }

    public void AddNode(string name)
    {
        _undoModel.WriteHistory(new LocolizeDataTransferObject(_model.LanguagesCount, _model.Nodes));

        List<LocolizeNode> nodes = _model.Nodes.ToList();

        nodes.Add(new LocolizeNode(name, new string[_model.LanguagesCount]));

        _model.Save(nodes.ToArray());
    }

    public void RemoveNode(LocolizeNode node)
    {
        _undoModel.WriteHistory(new LocolizeDataTransferObject(_model.LanguagesCount, _model.Nodes));

        List<LocolizeNode> nodes = _model.Nodes.ToList();

        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Key == node.Key)
            {
                nodes.RemoveAt(i);
            }
        }

        _model.Save(nodes.ToArray());
    }

    public void AddLanguage(LanguagesHolderScriptableObject holder)
    {
        if ((_model.LanguagesCount + 1) > holder.Languages.Length)
        {
            Debug.LogWarning($"Your holder defines {holder.Languages.Length} languages. You can`t add new language");
            return;
        }

        _undoModel.WriteHistory(new LocolizeDataTransferObject(_model.LanguagesCount, _model.Nodes));

        foreach (LocolizeNode node in _model.Nodes)
        {
            string[] newLocolizes = new string[node.Locolizes.Length + 1];

            for (int i = 0; i < node.Locolizes.Length; i++)
            {
                newLocolizes[i] = node.Locolizes[i];
            }

            ReplaceNode(node, new LocolizeNode(node.Key, newLocolizes));
        }

        _model.IncrementLanguageCount();
    }

    public void RemoveLanguage()
    {
        _undoModel.WriteHistory(new LocolizeDataTransferObject(_model.LanguagesCount, _model.Nodes));

        if ((_model.LanguagesCount - 1) < 1)
        {
            Debug.LogWarning("Languages count = 1; Can`t remove language");
            return;
        }

        foreach (LocolizeNode node in _model.Nodes)
        {
            string[] newLocolizes = new string[node.Locolizes.Length - 1];

            for (int i = 0; i < newLocolizes.Length; i++)
            {
                newLocolizes[i] = node.Locolizes[i];
            }

            ReplaceNode(node, new LocolizeNode(node.Key, newLocolizes));
        }

        _model.DecrementLanguageCount();
    }

    public LocolizeDataTransferObject DeserializeData()
    {
        LocolizeNode[] nodes = _model.Load();

        return new LocolizeDataTransferObject(_model.LanguagesCount, nodes);
    }

    public LocolizeNode[] Deserialize()
    {
        return _model.Load();
    }

    public async UniTask Translate(LocolizeNode node)
    {
        string sourceLanguage = FindSourceIsoLanguage(node, out string sourceString, out int sourceIndex);

        string[] newLocolizes = new string[node.Locolizes.Length];

        Debug.Log($"Translating: {sourceString}");

        for (int i = 0; i < node.Locolizes.Length; i++)
        {
            if (string.IsNullOrEmpty(sourceString.Trim()))
            {
                continue;
            }

            if (i != sourceIndex)
            {
                newLocolizes[i] = await _translater.Translate(sourceLanguage, _languagesHolderScriptableObject.Languages[i].IsoCode, sourceString);
            }
            else
            {
                newLocolizes[i] = node.Locolizes[i];
            }
        }

        LocolizeNode newNode = new LocolizeNode(node.Key, newLocolizes);
        ReplaceNode(node, newNode);

        Debug.Log($"Translated and saved as: {node.Key}");
    }

    public void Undo()
    {
        LocolizeDataTransferObject data = _undoModel.Undo(out bool hasHistory);

        if (hasHistory == true)
        {
            _model.Save(data.Nodes, data.LanguagesCount);
        }
    }

    public void Rendo()
    {
        LocolizeDataTransferObject data = _undoModel.Redo(out bool hasHistory);

        if (hasHistory == true)
        {
            _model.Save(data.Nodes, data.LanguagesCount);
        }
    }

    private bool ContainsKey(string key, LocolizeNode[] nodes)
    {
        foreach (LocolizeNode node in nodes)
        {
            if (node.Key == key)
            {
                return true;
            }
        }

        return false;
    }

    private string FindSourceIsoLanguage(LocolizeNode node, out string sourceString, out int sourceIndex)
    {
        int languageId = 0;
        sourceIndex = 0;
        sourceString = "";

        for (int i = 0; i < node.Locolizes.Length; i++)
        {
            languageId = i;

            if (string.IsNullOrEmpty(node.Locolizes[i].Trim()) == false)
            {
                sourceString = node.Locolizes[i];
                sourceIndex = i;
                break;
            }
        }

        return _languagesHolderScriptableObject.Languages[languageId].IsoCode;
    }
}