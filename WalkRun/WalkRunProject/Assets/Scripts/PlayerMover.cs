using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;

    public float jumpForce = 2f, gravity = -5f, rotateSpeed;

    private float rotateAngle;
    
    private Vector3 movement;
    
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
        rotateAngle += Input.GetAxis("Mouse X") * rotateSpeed * -Time.deltaTime;
        player.localRotation = Quaternion.AngleAxis(rotateAngle, Vector3.up);
        
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

        movement.y = yVar;
        controller.Move(movement);
    }
}
