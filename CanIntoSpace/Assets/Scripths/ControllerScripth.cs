using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScripth : MonoBehaviour {

    public float targetSpeed = 0;
    public float maxSpeed = 30;
    public float currentSpeed;
    public float acc = 1f;
    public float speed = 60;
    public GameObject theMap;
    Rigidbody rb;

    void Start () {
        currentSpeed = 0;
        //Debug.Log(currentSpeed);
        rb = GetComponent<Rigidbody>();

    }
	
	void Update () {

        //Get Target Speed
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            if (targetSpeed < maxSpeed)
            {
                targetSpeed += 1;
            }
        }
        else if (d < 0f)
        {
            if (targetSpeed > -maxSpeed)
            {
                targetSpeed -= 1;
            }
        }

        //Accelerating
        if ((currentSpeed+acc) <= targetSpeed) {
            currentSpeed += acc;
        }
        if (currentSpeed > targetSpeed)
        {
            if (targetSpeed == 0)
            {
                currentSpeed *= 0.99f;
            }
            else
            if ((currentSpeed - acc) >= targetSpeed)
            {
                currentSpeed -= (acc);
            }
        }
        //Debug.Log(currentSpeed);

        //Movment
        if (speed < 35)
        {
            speed = 35;
        }

        speed -= transform.forward.y * Time.deltaTime * 25.0f;

        transform.Rotate(-Input.GetAxis("Vertical") * 1.2f, 0.0f, -Input.GetAxis("Horizontal") * 2f);
    }

    void FixedUpdate() {
        rb.velocity = transform.forward * (speed + currentSpeed);
    }

    void OnCollisionEnter(Collision col) {
        Debug.Log("Hit");
    }

    void LateUpdate() {
        //Camera Movment
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);
    }
}
