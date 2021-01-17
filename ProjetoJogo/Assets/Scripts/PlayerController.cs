using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public Animator ninjaAnimatorController;

    private Vector3 moveDirection;
    public float gravityScale;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        //Limitar velocidade diagonal
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection = moveDirection.normalized * (moveSpeed*2);
        }
        else
        {
            moveDirection = moveDirection.normalized * moveSpeed;
        }
        //moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
        PlayerAnimate();
    }

    public void PlayerAnimate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ninjaAnimatorController.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            ninjaAnimatorController.SetBool("Running", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ninjaAnimatorController.SetBool("StrafeLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ninjaAnimatorController.SetBool("StrafeLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ninjaAnimatorController.SetBool("StrafeRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ninjaAnimatorController.SetBool("StrafeRight", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ninjaAnimatorController.SetBool("JogBackwards", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            ninjaAnimatorController.SetBool("JogBackwards", false);
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    ninjaAnimatorController.SetBool("Jump", true);
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    ninjaAnimatorController.SetBool("Jump", false);
        //}
    }

}
