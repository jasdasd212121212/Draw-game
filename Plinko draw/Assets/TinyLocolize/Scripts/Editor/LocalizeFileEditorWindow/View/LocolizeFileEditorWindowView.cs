using UnityEditor;

public class LocolizeFileEditorWindowView : EditorWindow, ILocalEditorView
{
    private ILocalEditorPresenter _presenter;

    private FileEditorModesStateMachine _modes;
    private LanguagesHolderScriptableObject _holder;

    public void Construct(ILocalEditorPresenter presenter)
    {
        _presenter = presenter;

        _modes = new FileEditorModesStateMachine
        (
            new BootWindowDrawer(
                    (LanguagesHolderScriptableObject holder) => { _holder = holder; _modes.Switch<SeleclModeDrawer>().SetLanguages(_holder); },
                    (LanguagesHolderScriptableObject holder) => { _holder = holder; _modes.Switch<ImportGoogleSheetDrawer>().SetLanguages(_holder); }
                ),

            new IModeDrawer[]
            {
                new SeleclModeDrawer(_presenter, 
                    (LocolizeNode node) => { _modes.Switch<EditNodeModeDrawer>().SetNode(node, _holder); }, 
                    () => { _modes.Switch(0); },
                    () => { _modes.Switch<AutoTranslaterModeDrawer>(); }),

                new EditNodeModeDrawer(_presenter, () => { _modes.Switch<SeleclModeDrawer>().SetLanguages(_holder); }),
                new ImportGoogleSheetDrawer(_presenter, () => { _modes.Switch(0); }, () => { _modes.Switch(0); }),
                new AutoTranslaterModeDrawer(() => { _modes.Switch(0); }, _presenter.Deserialize().Length - 1, new AutoTranslatePresenter(_presenter), this)
            }
        );
    }

    private void OnGUI()
    {
        _modes.CurrentDrawer.Draw();
    }
}