using UnityEngine;

public abstract class SelectableCounter : MonoBehaviour
{
    [SerializeField] private GameObject _selectedVisual;

    public void Select() => 
        _selectedVisual.SetActive(true);

    public void Unselect() => 
        _selectedVisual.SetActive(false);
}