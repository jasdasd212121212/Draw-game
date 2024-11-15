using UnityEngine;

[CreateAssetMenu(fileName = "SkinShopSettings", menuName = "Game design/Skins")]
public class SkinShopSettings : ScriptableObject
{
    [SerializeField] private SkinShopSettingsDataNode[] _nodes;

    [Space]

    [SerializeField] private SkinShopSettingsDataNode _defaultSkin;

    public SkinShopSettingsDataNode[] Nodes => _nodes;
    public SkinShopSettingsDataNode DefaultSkin => _defaultSkin;

    public int IndexOf(SkinShopSettingsDataNode node)
    {
        for (int i = 0; i < _nodes.Length; i++)
        {
            if (_nodes[i] == node)
            {
                return i;
            }
        }

        Debug.LogError($"Critical error -> skin: {node} (Name: {node?.Name}) are not exist in holder: {name}");

        return -1;
    }
}