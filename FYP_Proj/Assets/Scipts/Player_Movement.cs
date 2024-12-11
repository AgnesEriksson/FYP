using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public int speed = 5;
    public Rigidbody rb;

    float hozInput;
    public float hozMultiplier;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 constantmove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 hMove = transform.right * hozInput * speed * Time.fixedDeltaTime * hozMultiplier;
        rb.MovePosition(rb.position + constantmove + hMove);
    }

    void Update()
    {
        hozInput = Input.GetAxis("Horizontal");
        Debug.Log(hozInput);
    }
}
