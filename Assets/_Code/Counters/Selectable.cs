using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    public void Select()
    {
        Debug.Log("Selected: " + transform.name);
    }
}