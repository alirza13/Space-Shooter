using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f, rotationAngle = 2f, minZRotation = -25f, maxZRotation = 25f;
    public float minXPosition = -2.5f, maxXPosition = 2.5f, minYPosition = -4.4f, maxYPosition = 4.4f;
    private Rigidbody myRigBody;

    private void Awake()
    {
        myRigBody = GetComponent<Rigidbody>();
        myRigBody.centerOfMass = Vector3.zero;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();  
    }

    private void Update()
    {
        ConstraintZRotation();
        BoundaryDetection();
    }

    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            myRigBody.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -rotationAngle));
            myRigBody.AddForce(new Vector2(moveSpeed, 0));
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myRigBody.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationAngle));
            myRigBody.AddForce(new Vector2(-moveSpeed, 0));
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            myRigBody.AddForce(new Vector2(0, moveSpeed));
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            myRigBody.AddForce(new Vector2(0, -moveSpeed));
        }
    }

    private void ConstraintZRotation()
    {
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        if (eulerAngles.z > 45 && eulerAngles.z < 180)
        {
            transform.rotation = Quaternion.AngleAxis(-315, new Vector3(0, 0, 45));
            //myRigBody.angularVelocity = 0;
            Debug.Log("45");
        }

        if (eulerAngles.z < 315 && eulerAngles.z > 180)
        {
            transform.rotation = Quaternion.AngleAxis(-315, new Vector3(0, 0, -45));
            //myRigBody.angularVelocity = 0;
            Debug.Log("-45");
        }
    }

    private void BoundaryDetection()
    {
        if (transform.position.x > maxXPosition)
        {
            transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
        }

        if (transform.position.x < minXPosition)
        {
            transform.position = new Vector3(minXPosition, transform.position.y, transform.position.z);
        }

        if (transform.position.y > maxYPosition)
        {
            transform.position = new Vector3(transform.position.x, maxYPosition, transform.position.z);
        }
        if (transform.position.y < minYPosition)
        {
            transform.position = new Vector3(transform.position.x, minYPosition, transform.position.z);
        }
    }
}