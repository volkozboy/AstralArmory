using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.TextCore.Text;

namespace Play
{
public class Support : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;
    public float gravity = -9.81f;
    public bool doubleJump = false;
    public int Jumps = 1;
    public bool Dashing;
    
    
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    PhotonView view;
    public Camera playerCam;

    
    void Start()
    {
        view = GetComponent<PhotonView>();
        
        if(!view.IsMine){
            Destroy(GetComponentInChildren<Camera>());
        }
        if(view.IsMine){
            FindObjectOfType<Health>().Support = true;
        }
    }

    // Update is called once per frame
    void Update()

    {
        if(!view.IsMine){
            return;
        }
        if(view.IsMine){
    
        // WASD Movement
        playerCam = Camera.main;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
    
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //Jumping/DoubleJumping
        if(Input.GetButtonDown("Jump") && Jumps == 1){
            velocity.y = Mathf.Sqrt(2f * -60f * -5);
            
        }
            if(Input.GetButtonDown("Jump") && isGrounded == false && Jumps == 1){
                gravity = -80f;
                velocity.y = Mathf.Sqrt(7f * -3.5f * gravity);
                Jumps --;
                speed = 15;
            }
        if(isGrounded){
            Jumps = 1;
            gravity = -40;
            speed = 25;
            
        }
        if(!isGrounded && Dashing){
            speed = 75;
            
        }


         //Dashing
         if(Input.GetKeyDown(KeyCode.LeftShift)){
            Dashing = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            Dashing = false;
        }

            if(Input.GetAxisRaw("Horizontal") > 0.1f && Dashing){
                speed = 50;
                StartCoroutine(Dash());
            }
                if(Input.GetAxisRaw("Horizontal") > -0.1f && Dashing){
                    speed = 50;
                    StartCoroutine(Dash());
                }
                    if(Input.GetAxisRaw("Vertical") > 0.1f && Dashing){
                        speed = 50;
                        StartCoroutine(Dash());
                    }
                        if(Input.GetAxisRaw("Vertical") > -0.1f && Dashing){
                            speed = 50;
                            StartCoroutine(Dash());
                        }

    
        IEnumerator Dash(){
            yield return new WaitForSeconds(0.25f); 
            Dashing = false;
            speed = 25;
        }
        }
    }
}
}   