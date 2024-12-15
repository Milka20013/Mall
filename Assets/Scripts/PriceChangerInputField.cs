using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PriceChangerInputField : MonoBehaviour
{
    public static PriceChangerInputField instance;
    [SerializeField] private TMP_InputField inputField;

    private UnityAction<string> onEndEdit;

    private void Awake()
    {
        instance = this;
    }

    public void Open(UnityAction<string> onEndEdit)
    {
        this.onEndEdit = onEndEdit;
        inputField.gameObject.SetActive(true);
        inputField.onEndEdit.AddListener(this.onEndEdit);
        inputField.onEndEdit.AddListener(Close);
    }

    public void Close(string _)
    {
        inputField.gameObject.SetActive(false);
        inputField.onEndEdit.RemoveAllListeners();
    }
}
