using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionTutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rightX;
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddRelativeForce(Vector2.up * 150);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.position.x > rightX)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
