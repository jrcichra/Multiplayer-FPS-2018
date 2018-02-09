using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    public Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camera_rotation = Vector3.zero;

    public void Rotate(Vector3 r)
    {
        rotation = r;
    }

    public void RotateCamera(Vector3 cr)
    {
        camera_rotation = cr;
    }

    public void Move(Vector3 v)
    {
        velocity = v;
    }

    //Perform rotation
    void PerformRotation() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            Debug.Log("here");
            cam.transform.Rotate(camera_rotation);
        }
    }

    //Preform movememnt based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    //Run every physics
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

}
