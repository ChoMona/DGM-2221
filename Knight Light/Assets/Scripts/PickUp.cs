using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform lampDest;
    public GameObject item;
    private IEnumerator coroutine;
    IEnumerator dimLight;


    private void Start()
    {
        coroutine = dimLight;
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = lampDest.position;
            this.transform.parent = GameObject.Find("LampHold").transform;
        }
        
        IEnumerator coroutine(float dimLight)
        {
            yield return new WaitForSeconds(dimLight);
            print("Coroutine ended: " + Time.time + " seconds");
        }
    }
}
