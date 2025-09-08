using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;

    private Transform cam;
    private Rigidbody rb;
    public Vector2 moveVal;
    public Vector2 lookVal;
    public float moveSpeed;
    public float lookSpeed;
    public float maxSpeed;
    


    void Start()
    {
        //moveAction = InputSystem.actions.FindAction("move");
        //controller = gameObject.AddComponent<CharacterController>();
        moveSpeed = 0.02f; lookSpeed = 0.2f; maxSpeed = 2;
        //Confine the mouse cursor into the Game Window so it can't leave
        Cursor.lockState = CursorLockMode.Confined;
        //Locks the mouse cursor so it can't move(like moving the camera mode type deal)
        Cursor.lockState = CursorLockMode.Locked;
        //Basically change between locked and confined for certain actions

    }

    private void Awake()
    {
        // this is bad programming
        cam = this.gameObject.transform.GetChild(0);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>()*moveSpeed;
        Debug.Log(moveVal.ToString());
    }

    void OnLook(InputValue value)
    {
        lookVal = value.Get<Vector2>();
        Debug.Log(lookVal.ToString());
    }

    void VelocityCheck()
    {
        rb.linearDamping = rb.linearVelocity.magnitude / maxSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
        rb.AddRelativeForce(moveVal.x, 0, moveVal.y, ForceMode.VelocityChange);
        VelocityCheck();
        transform.Rotate(new Vector3(0, lookVal.x, 0) * lookSpeed);
        cam.transform.Rotate(new Vector3(-lookVal.y, 0, 0) * lookSpeed);
    }
}
