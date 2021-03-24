using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    [SerializeField]private float maxVelocity = 2;
    [SerializeField] private float rotationSpeed;
    [SerializeField]private float thrust;
    private float turn;
    [SerializeField] private float topY;

    [SerializeField] private float bottomY;

    [SerializeField] private float rightX;

    [SerializeField] private float leftX;
    
    [SerializeField] private GameObject laser;
    [SerializeField] private float laserspeed;
    [SerializeField] private float destroyLaserTime;




    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        thrust = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");

        SortPlayerOutOfBounds();

        if (Input.GetButtonDown("Fire1"))
        {
            FireLaser();
        }
    }

    private void FixedUpdate() 
    {
        rigidbody.AddRelativeForce(Vector2.up * thrust);

        float newAngle = rigidbody.rotation- (turn * rotationSpeed * Time.deltaTime);
        rigidbody.MoveRotation(newAngle);
    }

    private void FireLaser()
    {
        GameObject newLaser = Instantiate(laser, transform.position, transform.rotation);
        newLaser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * laserspeed);
        Destroy(newLaser, destroyLaserTime);
    }

    private void SortPlayerOutOfBounds()
    {
        Vector2 newLocation = transform.position;
        if (transform.position.y > topY)
        {
            newLocation.y = bottomY;
        }
        if (transform.position.y < bottomY)
        {
            newLocation.y = topY;
        }
        if (transform.position.x > rightX)
        {
            newLocation.x = leftX;
        }
        if (transform.position.x < leftX)
        {
            newLocation.x = rightX;
        }
        rigidbody.position = newLocation;
    }

    
}
