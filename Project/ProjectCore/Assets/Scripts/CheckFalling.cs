using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFalling : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float FallingThreshold = -10f;
    public Animator anim;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (myRigidbody.velocity.y < FallingThreshold) {
            anim.Play("Base Layer.Fall");
        }
    }
}
