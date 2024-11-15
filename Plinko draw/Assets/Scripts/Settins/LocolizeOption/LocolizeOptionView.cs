using UnityEngine;
using TMPro;

public class LocolizeOptionView : BaseOptionView<IntDataTransferObject>
{
    [SerializeField] private TMP_Dropdown _dropdown;

    public override IntDataTransferObject State => new IntDataTransferObject(_dropdown.value);

    private void Awake()
    {
        _dropdown.onValueChanged.AddListener(OnChangeDropdown);
    }

    private void OnDestroy()
    {
        _dropdown.onValueChanged.RemoveAllListeners();
    }

    public override void Display(IntDataTransferObject data)
    {
        _dropdown.value = data.Data;
    }

    private void OnChangeDropdown(int value)
    {
        CallChange();
    }
}