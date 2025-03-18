using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class movement : MonoBehaviour
{

    [SerializeField] private float playerspeed = 5f;
    [SerializeField] private float gravitytvalue = -9.81f;

    private CharacterController controller;
    
    
    
    private Vector2 move;
    private Vector2 aim;
    private Vector3 playervelocity;
    
    private Controls playerControls;
    private PlayerInput playerInput;
   

    // this line may not work due to how i named my files, but it hasnt thrown up a error so lets pray

    private void Awake()
    {
        controller = GetComponent<CharacterController>();  
        playerControls = new Controls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    
      private void OnDisable()
    {
        playerControls.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
    }
    
    void HandleInput()
    {
     move = playerControls.KeyboardControls.movement.ReadValue<Vector2>();
     // the vector -->  inputbase --> the action map --> the action
     aim = playerControls.KeyboardControls.aim.ReadValue<Vector2>();
    }
    
    void HandleMovement()
    {
        Vector3 movement = new Vector3(move.x,  0, move.y);
        // movement = name of the vector, not the name of the input
        controller.Move(movement * Time.deltaTime * playerspeed);
        
        playervelocity.y += gravitytvalue * Time.deltaTime;
        controller.Move(playervelocity * Time.deltaTime);
        //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/CharacterController.Move.html
    }
    
    void HandleRotation()
    {
    
    }
}