using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerMovement.Move(horizontal, vertical);
        playerMovement.Rotate(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerMovement.Jump();
        }
    }
}
