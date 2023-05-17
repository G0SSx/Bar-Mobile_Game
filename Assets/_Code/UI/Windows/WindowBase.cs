using UnityEngine;
using UnityEngine.UI;

public abstract class WindowBase : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() => Destroy(gameObject));
        OnAwake();
    }

    private void OnDestroy()
    {
        CleanUp();
    }

    protected virtual void OnAwake() { }

    protected virtual void CleanUp() { }
}