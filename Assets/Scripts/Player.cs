using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference shootControl;
    
    private CharacterController controller;

    private Transform cameraMain;
    private Vector3 playerVelocity;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float turnSpeed = 10;
    [SerializeField] private GameObject soap;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMain = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMain.transform.forward * move.z + cameraMain.transform.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        if (shootControl.action.triggered)
        {
            GameObject s = Instantiate(soap, shootPoint);
            s.transform.parent = null;
            s.GetComponent<Soap>().direction = transform.forward;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMain.transform.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        movementControl.action.Enable();
        shootControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        shootControl.action.Disable();
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        
    }
}
