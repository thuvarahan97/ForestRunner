using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public bool jump = false;

    public bool slide = false;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (0, 0, 0.1f);

        if (Input.GetKey (KeyCode.Space)) {
            jump = true;
        }
        else {
            jump = false;
        }

        if (Input.GetKey (KeyCode.DownArrow)) {
            slide = true;
        }
        else {
            slide = false;
        }

        if (jump == true) {
            anim.SetBool ("isJump", jump);
        }
        else if (jump == false) {
            anim.SetBool ("isJump", jump);
        }

        if (slide == true) {
            anim.SetBool ("isSlide", slide);
        }
        else if (slide == false) {
            anim.SetBool ("isSlide", slide);
        }
    }
}
