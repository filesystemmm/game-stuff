using UnityEndgine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.MovementSpeed =
            ((Vector3.right * horizontal + Vector3.forward * Vertical) * Time.deltaTime);
        
        // gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.MovementSpeed = (new Vector3(0, velocity, 0));
        }
    }
}

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalRotationSpeed = 1f;
    // vertical rotation speed
    public float verticalRotationSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;

    void Start()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalRotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalRotationSpeed;

        yRotation += mouseX;
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        
        camera.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}