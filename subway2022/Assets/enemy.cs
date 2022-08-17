using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    AudioSource aud;
    Rigidbody rb;
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            aud.Play();
            StartCoroutine(restart());
        }
        if (collision.gameObject.name == "wall")
        {
            Destroy(gameObject, 1.5f);
        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
