using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    CharacterController player;
    private float horizontalMove;
    private float verticalMove;
    public float playerSpeed = 4;
    private Vector3 playerImputs;


    private Vector3 movePlayer;
    //movimiento respecto a la camara

    public Camera maincamara;
    private Vector3 camForward;
    private Vector3 camRight;


    private float gravity = 9.8f;
    public float fallVelocity = 1;

    //caida pendiente

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity = 7;
    public float sloprForceDown = -4;


    public float jumpForce = 5;

    public Animator playerAnimator;


    void Start()
    {

        player = GetComponent<CharacterController>(); 

        playerAnimator = GetComponent<Animator>();

    }

   
    void Update()
    {
        MoverPlayer();
    }

    private void MoverPlayer()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerImputs = new Vector3(horizontalMove,0, verticalMove);

        playerImputs = Vector3.ClampMagnitude(playerImputs, 1); // para que no se sumen las fuerzas cuando vas en diagonal capa el imput a 1

        // player.Move(playerImputs * playerSpeed);

        playerAnimator.SetFloat("velocity", playerImputs.magnitude * playerSpeed);
        //movimiento respecto a la camara
        CamDirection();

        movePlayer = playerImputs.y * camRight + playerImputs.z * camForward;
        movePlayer = movePlayer * playerSpeed;
        player.transform.LookAt(player.transform.position + movePlayer);


        SetGravedad();
        Saltar();

        player.Move(movePlayer);

    }

    private void Saltar()
    {
        if (Input.GetButtonDown("Jump") && player.isGrounded)
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;

            playerAnimator.SetTrigger("playerjump");
        }
    }

    private void SetGravedad()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity *Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            playerAnimator.SetFloat("velocidad vertical", player.velocity.y);
        }

        playerAnimator.SetBool("ground", player.isGrounded);
        SlideDown();
    }

    private void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;

        if (isOnSlope)
        {
            movePlayer.x += ((1f -hitNormal.y) * hitNormal.x)*slideVelocity;
            movePlayer.z += ((1f -hitNormal.y) * hitNormal.z)*slideVelocity;

            movePlayer.y += sloprForceDown;
        }
    }

    private void CamDirection()
    {
        camForward = maincamara.transform.forward;
        camRight = maincamara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
}
