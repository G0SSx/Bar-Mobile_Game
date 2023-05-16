using UnityEngine;

public abstract class BaseCounter : MonoBehaviour
{
    [SerializeField] private GameObject _selectedVisual;

    public abstract KitchenObject Interact(KitchenObject playersObject);

    public void Select() =>
        _selectedVisual.SetActive(true);

    public void Unselect() =>
        _selectedVisual.SetActive(false);
}