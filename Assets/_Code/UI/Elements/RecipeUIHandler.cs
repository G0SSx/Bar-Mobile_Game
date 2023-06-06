using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeUIHandler : MonoBehaviour
{
    [SerializeField] private Transform _iconsParent;
    [SerializeField] private TextMeshProUGUI _recipeTitle;

    private List<GameObject> _iconObjects = new();

    public void AddIconObject(GameObject iconObject)
    {
        _iconObjects.Add(iconObject);

        SetParent(iconObject);
    }

    private void SetParent(GameObject iconObject)
    {
        iconObject.transform.SetParent(_iconsParent);
        iconObject.transform.localPosition = Vector3.zero;
        iconObject.transform.localRotation = Quaternion.identity;
    }

    public void SetTitle(string title) => 
        _recipeTitle.text = title;

    public void RecipeDelivered()
    {
        foreach (GameObject iconObject in _iconObjects)
            Destroy(iconObject);
    }
}