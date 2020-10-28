using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{

    public Vector3 value;
    
    public void SetValueFromTransform(Vector3 obj)
    {
        value = obj;

    }

    public void SetValueFromRotation(Transform obj)
    {
        value = obj.eulerAngles;
    }

    public void SetValueFromMousePosition(Camera cam)
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            value = hit.point;
        }
    }
}