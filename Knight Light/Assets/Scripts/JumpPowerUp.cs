using System;
using System.Collections;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public IntData playerJumpCount, normalJumpCount, powerUpCount;
    public float waitTime = 2f;

    private void Start()
    {
        playerJumpCount.value = normalJumpCount.value;
    }

    private void OnTriggerExit(Collider other)
    {
        playerJumpCount.value = powerUpCount.value;
        gameObject.SetActive(false);
    }
}