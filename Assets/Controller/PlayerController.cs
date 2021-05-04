using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    [SerializeField] private float dieForce;

    [SerializeField] private Color normalColour;
    [SerializeField] private Color respawnColour;
    
    public static event System.Action LoseLifeEvent;

    private int lives;
    private int scores;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            lives = TutorialController.GetLives();
        }
        else
        {
            lives = GameplayController.GetLives();
        }
        
       
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.relativeVelocity.magnitude > dieForce)
        {
            Die();
            LoseLifeEvent?.Invoke();
            
            
        }
    }

    private void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            lives = TutorialController.GetLives();
        }
        else
        {
            lives = GameplayController.GetLives();
        }
        if (lives >0)
        {
            Invoke("Respawn",2f);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Respawn()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
        SpriteRenderer spaceship = GetComponent<SpriteRenderer>();
        spaceship.enabled = true;
        spaceship.color = respawnColour;
        Invoke("StartActive",3f);
    }

    private void StartActive()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = normalColour;
    }

    
}
