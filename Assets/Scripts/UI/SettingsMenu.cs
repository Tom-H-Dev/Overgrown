using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private KeyBinds _keyBinds;

    [SerializeField] private Button inventoryButton, sprintButton, interactButton, pauseButton;
    [SerializeField] private TextMeshProUGUI inventoryText, sprintText, interactText, pauseText;

    private string selectedAction;

    private void OnEnable()
    {
        inventoryText.text = _keyBinds.inventory.ToString(); 
        sprintText.text = _keyBinds.sprint.ToString();
        interactText.text = _keyBinds.interact.ToString();
        pauseText.text = _keyBinds.pause.ToString();

        AddButtonListener(inventoryButton, "inventory");
        AddButtonListener(sprintButton, "sprint");
        AddButtonListener(interactButton, "interact");
        AddButtonListener(pauseButton, "button");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_button"></param> 
    /// <param name="_action"></param>
    private void AddButtonListener(Button _button, string _action)
    {
        if (_button != null)
        {
            _button.onClick.AddListener(() => OnChangeKeyBindClick(_action));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_action"></param>
    private void OnChangeKeyBindClick(string _action) => selectedAction = _action;

    private void Update()
    {
        if (selectedAction != null)
        {
            KeyCode _newKeyCode = GetPressedKey();
            if (_newKeyCode != KeyCode.None)
            {
                InputManager.instance.ChangeKeyBinding(selectedAction, _newKeyCode); 
                UpdateKeyText(selectedAction, _newKeyCode);
                selectedAction = null;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private KeyCode GetPressedKey()
    {
        foreach (KeyCode _keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(_keyCode) && _keyCode != KeyCode.Mouse0 && _keyCode != KeyCode.Mouse1)
            {
                return _keyCode;
            }
        }
        return KeyCode.None;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_action"></param>
    /// <param name="_keyCode"></param>
    private void UpdateKeyText(string _action, KeyCode _keyCode)
    {
        switch (_action)
        {
            case "inventory":
                inventoryText.text = _keyCode.ToString();
                break;
            case "sprint":
                sprintText.text = _keyCode.ToString();
                break;
            case "interact":
                interactText.text = _keyCode.ToString();
                break;
            case "pause":
                pauseText.text = _keyCode.ToString();
                break;
            default:
                break;
        }

    }
}
