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

    private Animator anim;

    //private bool isAttacking = false;
    private int _ataqueTrigger = 0;
    private int _horizontalAxisHash = 0;
    private int _verticalAxisHash = 0;
    
    void Start(){
        anim = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        _ataqueTrigger = Animator.StringToHash("AtaqueTrigger");
        _horizontalAxisHash = Animator.StringToHash("Horizontal");
        _verticalAxisHash = Animator.StringToHash("Vertical");
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
        anim.SetFloat("VelX", horizontalMove);
        anim.SetFloat("VelY", verticalMove);

        //Debug.Log(player.isGrounded);

        /*if (Input.GetKeyDown(KeyCode.X) && !isAttacking) // Cambia "Fire1" por el nombre de tu tecla 'X' en el Input Manager
        {
            StartCoroutine(AttackAnimation());
        }*/
        if (Input.GetKeyDown(KeyCode.X)){
            anim.SetTrigger(_ataqueTrigger);
        }
        /*else{
            anim.SetFloat(_horizontalAxisHash, horizontalMove, 1.10f, Time.deltaTime);
            anim.SetFloat(_verticalAxisHash, verticalMove, 1.0f, Time.deltaTime);
        }*/
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

    /*IEnumerator AttackAnimation()
    {
        isAttacking = true;
        anim.SetTrigger("punch"); // Cambia "Attack" por el nombre del parámetro de la animación de golpear

        // Agrega un tiempo de espera para que la animación se reproduzca completamente
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        isAttacking = false;
    }*/
}
