using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moviment : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;

    private Vector3 playerInput;

    public float resistance;
    private float resistanceMax;
    public Slider sliderResistence;

    public float velocidad;
    public float velocidadMax;
    public float acceleracion;

    public float playerSpeed;
    private float playerSpeedInit;
    
    private Vector3 movePlayer;

    public float gravity = 9.8f;
    public float fallVelocity;

    private CharacterController player;

    public Camera mainCamera;
    private Animator animator;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerSpeedInit = playerSpeed;
        resistanceMax = resistance;
        SetSlifer(sliderResistence, resistance, resistanceMax);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
   

        CamDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        SetSlifer(sliderResistence, resistance, resistanceMax);

        player.Move(movePlayer * playerSpeed * Time.deltaTime);

        if (horizontalMove < 0 || verticalMove < 0 || horizontalMove > 0 || verticalMove > 0)
        {
            animator.SetBool("Andar", true);
            animator.SetBool("Correr", false);

            Run();

            AumResistance(0.2f);
        }
        else
        {
            animator.SetBool("Andar", false);
            animator.SetBool("Correr", false);

            AumResistance(0.3f);
        }
        
    }

    void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    void SetSlifer(Slider slider, float value, float valueMax)
    {
        slider.value = value / valueMax;
    }

    void AumResistance(float resistencia)
    {
        if(resistance <= resistanceMax)
        {
            resistance += resistencia;
        }
    }

    void Run()
    {
        if (resistance > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Andar", false);
                animator.SetBool("Correr", true);

                if (playerSpeed <= velocidadMax)
                    playerSpeed *= 1.5f;

                if (resistance > 0)
                    resistance -= 0.5f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("Andar", true);
                animator.SetBool("Correr", false);

                playerSpeed = playerSpeedInit;
            }
        }
        else
        {
            playerSpeed = playerSpeedInit;
        }
    }
}
