using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Animations : MonoBehaviour
{
    Animator anim;
    PhotonView view;
    public bool shooting;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
    if (!view.IsMine)
    {
        return;
    }
    
    if (view.IsMine)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        anim.SetBool("IsJumping", !isGrounded);
        anim.SetBool("IsMoving", Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
    }
    }
    }
