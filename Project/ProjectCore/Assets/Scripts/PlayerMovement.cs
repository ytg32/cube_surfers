using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 1;
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, 2);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        //trail.transform.position = new Vector3(0,0.03f,0);
    }
}
