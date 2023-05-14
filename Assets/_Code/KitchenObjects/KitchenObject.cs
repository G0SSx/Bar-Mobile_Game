using System;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public Action HasBeenTaken;
    public Action DeleteObject;
    
    public KitchenObjectType Type { get; private set; }
    public bool IsCuttable { get; private set; }
    public bool IsCooked { get; private set; }

    public void Init(bool isCattbale, KitchenObjectType type, bool isCooked)
    {
        Type = type;
        IsCuttable = isCattbale;
        IsCooked = isCooked;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
        transform.rotation = parent.transform.rotation;
        transform.localPosition = Vector3.zero;
    }
}