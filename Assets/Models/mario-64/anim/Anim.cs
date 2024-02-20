using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool walkBool = Input.GetAxis("Horizontal")>0;
       

        animator.SetBool("walk",walkBool);
     
    }
}
