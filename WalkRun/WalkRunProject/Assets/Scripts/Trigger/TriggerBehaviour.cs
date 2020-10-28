using System.Collections;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class TriggerBehaviour : MonoBehaviour
{
    public Color newColor;
    public Color defaultColor;
    private MeshRenderer meshR;
    private WaitForSeconds wfs;
    public int holdTime = 10;

    void Start()
    {
        meshR = GetComponent<MeshRenderer>();
        meshR.material.color = defaultColor;
        wfs = new WaitForSeconds(holdTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        newColor.a = 0.5f;
        meshR.material.color = newColor;
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return wfs;
        meshR.material.color = defaultColor;
    }
}