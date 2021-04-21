using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundServices : MonoBehaviour
{
    [SerializeField] private AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        AsteroidsController.ExplosionEvent += PlayExplosion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayExplosion()
    {
        explosionSound.Play();
    }
}
