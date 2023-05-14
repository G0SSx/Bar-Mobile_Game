using UnityEngine;

public abstract class SelectableCounter : InteractWithSoundsCounter
{
    [Header("Normal stuff"), SerializeField] private GameObject _selectedVisual;

    public void Select() => 
        _selectedVisual.SetActive(true);

    public void Unselect() => 
        _selectedVisual.SetActive(false);
}