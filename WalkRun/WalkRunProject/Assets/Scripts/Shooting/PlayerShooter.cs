using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public int ammoCount = 10;
    public GameObject prefab;
    public Transform instancer;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            Instantiate(prefab, instancer.position, instancer.rotation);
        }
    }
}
