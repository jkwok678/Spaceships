using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Serializable;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    [Serializable] private float maxVelocity = 2;
    [Serializable] private float rotationSpeed = 2;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        Thrust(yAxis);
        Rotate(transform, xAxis * rotationSpeed);
    }

    private void Thrust(float power)
    {
        Vector2 force = transform.up *power;
        rigidbody.AddForce(force);
    }

    private void Rotate(Transform transform, float amount)
    {
        transform.Rotate(0,0,amount);
    }
}
