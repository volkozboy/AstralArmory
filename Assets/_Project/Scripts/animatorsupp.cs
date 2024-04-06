using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play;
public class animatorsupp : MonoBehaviour
{
    Animator anim;
    public bool isMoving;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if(isMoving){
            anim.Play("SupportWalk");
        }
            if(!isMoving){
                anim.Play("SupportIdle");
            }
    }
}
