using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    public Vector3Data vData;

    private void OnTriggerEnter(Collider other)
    {
        vData.SetValueFromTransform(transform.position);
    }
}