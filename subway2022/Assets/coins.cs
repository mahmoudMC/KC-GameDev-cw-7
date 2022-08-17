using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    AudioSource aud;
    Rigidbody rb;
    public float speed = 15;
    gamemanager manager;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        aud = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            manager.score += 10;
            Destroy(gameObject);
            aud.PlayOneShot(sound);
        }
        if (other.gameObject.name == "wall")
        {
            Destroy(gameObject);
        }
    }
}
