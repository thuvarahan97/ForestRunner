using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public bool jump = false;

    public bool slide = false;

    public GameObject trigger;

    public Animator anim;

    public CapsuleCollider capsuleCollider;

    private Vector3 capsColCenter;

    private Rigidbody rigidBody;

    void Start()
    {
        anim = GetComponent<Animator> ();

        capsuleCollider = GetComponent<CapsuleCollider> ();
        capsColCenter = capsuleCollider.center;

        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Control Start
        transform.Translate (0, 0, 0.1f);

        if (Input.GetKey (KeyCode.UpArrow)) {
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
            transform.Translate (0, 0.2f, 0.1f);
        }
        else if (jump == false) {
            anim.SetBool ("isJump", jump);
        }

        if (slide == true) {
            anim.SetBool ("isSlide", slide);
            rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            capsuleCollider.height = 1.600143f;
            capsColCenter.y = 0.6350716f;
            capsuleCollider.center = capsColCenter;
            transform.Translate (0, 0, 0.1f);
        }
        else if (slide == false) {
            anim.SetBool ("isSlide", slide);
            rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            capsuleCollider.height = 2.05f;
            capsColCenter.y = 0.86f;
            capsuleCollider.center = capsColCenter;
        }

        //Player Control End

        trigger = GameObject.FindGameObjectWithTag ("Obstacle");
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PlayerTrigger") {
            Destroy (trigger.gameObject);
        }

        if (other.gameObject.tag == "Coin") {
            Destroy (other.gameObject, 0.5f);
        }
    }
}
