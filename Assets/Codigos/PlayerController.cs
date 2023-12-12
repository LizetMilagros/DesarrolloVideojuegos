using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove, verticalMove;
    private Vector3 playerInput;
    public CharacterController player;
    public float playerspeed;
    private Vector3 movePlayer;
    public float gravity, fallVelocity, jumpForce;

    //camara
    public Camera mainCamera;
    private Vector3 camForward, camRight;
    //direccion de la camara

    public bool isAirborne = false; // Add this line inside the PlayerController class declaration

    
    void Start(){
        player = GetComponent<CharacterController>();
    }

    // Tema Logico
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove,0,verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);
        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerspeed;
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);

        Debug.Log(player.isGrounded);
    }
    void camDirection() {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;


    }
    public void SetGravity(){
        if (player.isGrounded){
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }else{
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        

    }
    //habilidades
    
    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            isAirborne = true;
        }
        else if (Input.GetButtonDown("Jump") && isAirborne)
        {
            fallVelocity += jumpForce;
            movePlayer.y = fallVelocity;
        }
    }
}
