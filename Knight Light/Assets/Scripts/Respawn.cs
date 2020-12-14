using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class Respawn : MonoBehaviour
{

    public FloatData playerHealth;
    public CharacterController playerMover;
    public Vector3Data vData;
    private WaitForSeconds wfs;
    public int holdTime = 1;

    private void Start()
    {
        playerMover = GetComponent<CharacterController>();
        wfs = new WaitForSeconds(holdTime);
    }
    void Update()
    {
        if ( playerHealth.value <= 0f)
        {
            if(playerHealth.value <= 0f)
            {
                playerMover.enabled = false;
                transform.position = vData.value;
                playerHealth.value = 1f;
                playerMover.enabled = true;
            }
        }
    }
}