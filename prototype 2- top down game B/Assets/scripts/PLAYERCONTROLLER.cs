using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed = 15.0f;

    private float vInput;
    private float hInput;
    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

      transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
      transform.Rotate(Vector3.forward, turnspeed * hInput * Time.deltaTime);
    }
}
