using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;

    public float jumpForce = 2f, gravity = -5f;

    private Vector3 movement, lookDirection;
    
    private float yVar;
    
    public IntData jumpCount, maxJumpCount;
    
    public FloatData normalMoveSpeed, fastMoveSpeed;
    
    private FloatData moveSpeed;

    public Transform player;
    
    private void Start()
    {
        moveSpeed = normalMoveSpeed;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        //Walking Horrizontally and Vertically
        var hInput = Input.GetAxis("Horizontal") * moveSpeed.value;
        var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        
        movement.Set(hInput, yVar, newZ: vInput);

         //Running when you press down on Shift
       if (Input.GetKeyDown(KeyCode.LeftShift))
       {
           moveSpeed = fastMoveSpeed;
       }

       if (Input.GetKeyUp(KeyCode.LeftShift))
       {
           moveSpeed = normalMoveSpeed;
       }
        
        //setting up Gravity
        yVar += gravity * Time.deltaTime;

        //So Gravity doesnt add onto itself
        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount.value = 0;
        }

        //Jump and Double Jump
        if (Input.GetButtonDown("Jump"))

        {
            if (jumpCount.value < maxJumpCount.value)
            {
                yVar = jumpForce;
                jumpCount.value++;
            }
        }
        
        lookDirection.Set(hInput, 0, vInput);

        if (lookDirection == Vector3.zero)
        {
            lookDirection.Set(0.0001f, 0, 0.0001f);
        }
        
        if (hInput > 0.5f || hInput < -0.5f ||vInput > 0.5f || vInput < -0.5f)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        movement.y = yVar;
        controller.Move(movement);
    }
}
