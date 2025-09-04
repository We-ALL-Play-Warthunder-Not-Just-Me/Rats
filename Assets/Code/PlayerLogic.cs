using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;

    private CharacterController controller;
    public Vector2 moveVal;
    public float moveSpeed;

  
    void Start()
    {
        //moveAction = InputSystem.actions.FindAction("move");
        //controller = gameObject.AddComponent<CharacterController>();
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
        Debug.Log(moveVal.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);


    }
}
