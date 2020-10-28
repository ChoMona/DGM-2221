using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class PlayerRespawn : MonoBehaviour
{

    public FloatData playerHealth;
    public GameObject spawnPoint;
    public CharacterController playerMover;

    private void Start()
    {
        playerMover = GetComponent<CharacterController>();
    }
    void Update()
    {
        if ( playerHealth.value <= 0f)
        {
            if(playerHealth.value <= 0f)
            {
                playerMover.enabled = false;
                transform.position = spawnPoint.transform.position;
                playerHealth.value = 1f;
                playerMover.enabled = true;
            }
        }
    }
}