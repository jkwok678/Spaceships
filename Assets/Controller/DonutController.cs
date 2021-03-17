using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float maxForce;
    [SerializeField] private float topY;

    [SerializeField] private float bottomY;

    [SerializeField] private float rightX;

    [SerializeField] private float leftX;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 thrust = new Vector2(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce));
        rigidbody.AddForce(thrust);
        
    }

    // Update is called once per frame
    void Update()
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
        transform.position = newLocation;
    }
}
