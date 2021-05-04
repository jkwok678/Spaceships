using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidsController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float maxForce;
    [SerializeField] private float maxSpin;
    [SerializeField] private float topY;

    [SerializeField] private float bottomY;

    [SerializeField] private float rightX;

    [SerializeField] private float leftX;

    public GameObject asteroidSmall1;

    public GameObject asteroidSmall2;

    public int points;

    public static event System.Action<int,bool> ScorePointEvent;
    public static event System.Action ExplosionEvent;

    [SerializeField] private AudioSource explosionSound;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 thrust = new Vector2(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce));
        float spin = Random.Range(-maxSpin, maxSpin);
        rigidbody.AddForce(thrust);
        rigidbody.AddTorque(spin);
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 newLocation = rigidbody.position;
        if (rigidbody.position.y > topY)
        {
            newLocation.y = bottomY;
        }
        if (rigidbody.position.y < bottomY)
        {
            newLocation.y = topY;
        }
        if (rigidbody.position.x > rightX)
        {
            newLocation.x = leftX;
        }
        if (rigidbody.position.x < leftX)
        {
            newLocation.x = rightX;
        }
        rigidbody.position = newLocation;
    }

    void OnTriggerEnter2D(Collider2D anotherItem)
    {
        if (anotherItem.CompareTag("laser"))
        {
            Destroy(anotherItem.gameObject);
            ProgramData.ShotsHit[ProgramData.Id]++;
            if (asteroidSmall1 && asteroidSmall2)
            {
                GameObject asteroid1 = Instantiate(asteroidSmall1, rigidbody.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidSmall2, rigidbody.position, transform.rotation);
                ScorePointEvent?.Invoke(points,true);
                
            }
            else
            {
                ScorePointEvent?.Invoke(points,false);
            }
            ExplosionEvent?.Invoke();
            
            Destroy(gameObject);
            
        }
    }
    
}
