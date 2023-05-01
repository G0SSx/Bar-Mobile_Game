using System;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public Action HasBeenTaken;

    public void SetParent(Transform parent)
    {
        transform.position = parent.transform.position;
        transform.rotation = parent.transform.rotation;
        transform.SetParent(parent);
    }
}