using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHPhysics : MonoBehaviour
{
    public float GRAVITY_PULL = 100f;
    public static float m_GravityRadius = 1f;

    private void Awake()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius;
    }
    private void OnTriggerStay(Collider other)
    {
        //
        if (other.tag == "Player")
        {
            //Vector2 direction = (Vector2)transform.position - collision.GetComponent<Rigidbody2D>().position;
            //direction.Normalize();
            //float rotateAmount = Vector3.Cross(direction, collision.transform.up).z;
            ////collision.GetComponent<Rigidbody>().angularVelocity = -rotateAmount * rotateSpeed;
            //collision.GetComponent<Rigidbody>().velocity = collision.transform.up * draggingSpeed;
            //Debug.Log("Triggered");
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL);
            Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
        }
    }
}
