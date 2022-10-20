using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSound : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField]
    private AudioClip auw;
    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
        audio = GetComponent<AudioSource>();
        audio.clip = auw;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            if (collision.gameObject.CompareTag("environment") || collision.gameObject.CompareTag("bullet"))
            {
                Debug.Log("Collided with environment");
            }
            else
            {
                audio.Play();
                hasCollided = true;
            }
        }
    }

        // Update is called once per frame
        void Update(){

    }
}
