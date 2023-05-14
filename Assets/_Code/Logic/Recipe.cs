using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    [SerializeField] private Transform _iconsParent;
    [SerializeField] private TextMeshProUGUI _titleText;

    private List<GameObject> _iconObjects;

    private void Awake()
    {
        _iconObjects = new List<GameObject>();
    }

    public void AddIconToRecipe(GameObject iconObject)
    {
        _iconObjects.Add(iconObject);
        iconObject.transform.SetParent(_iconsParent);
        iconObject.transform.localPosition = Vector3.zero;
    }

    public void SetTitle(string title)
    {
        _titleText.text = title;
    }

    public void RecipeDelivered()
    {
        foreach (GameObject iconObject in _iconObjects)
            Destroy(iconObject);
    }
}