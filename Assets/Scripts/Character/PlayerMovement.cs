using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float gravity;
    //public float moveSpeed;
    //public float jumpForce;
    //public float rotationSpeed;
    //public float gravity;


    private Vector3 lastMoveDirection = Vector3.zero;
    public bool isGrounded;
    public Vector3 velocity;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        CheckTheGround();
        ApplyGravity();
    }

    public void Move(float horizontal, float vertical) 
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f) 
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = (cameraForward * direction.z + cameraRight * direction.y).normalized;
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            lastMoveDirection = moveDirection;
        }
    }

    public void Rotate(float horizontal, float vertical) 
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if(direction.magnitude >= 0.1f) 
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = (cameraForward * direction.z + cameraRight * direction.x).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void Jump() 
    {
        if (isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
    }

    private void CheckTheGround() 
    {
        isGrounded = characterController.isGrounded;

        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
    }

    private void ApplyGravity() 
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity *  Time.deltaTime);
    }
}
