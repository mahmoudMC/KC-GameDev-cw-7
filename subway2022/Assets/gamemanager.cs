using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{

    float timer = 2;
    public GameObject enemy;
    public GameObject coins;
    public float score = 0;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<enemy>().speed = 15;
        StartCoroutine(spawnenemy());
        StartCoroutine(scores());
        StartCoroutine(spawncoin());
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + score;
    }

    IEnumerator spawnenemy()
    {
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            Instantiate(enemy, new Vector3(0, 0.6f, 0), Quaternion.Euler(0, 0, 0));
        }
        else if (random == 2)
        {
            Instantiate(enemy, new Vector3(0, 0.6f, 4), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(enemy, new Vector3(0, 0.6f, -4), Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(timer);
        if (timer >= 0.5f)
        {
            timer -= 0.1f;
            enemy.GetComponent<enemy>().speed++;
        }
        StartCoroutine(spawnenemy());
    }

    IEnumerator spawncoin()
    {
        int randoms = Random.Range(1, 4);
        if (randoms == 1)
        {
            Instantiate(coins, new Vector3(0, 0.6f, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (randoms == 2)
        {
            Instantiate(coins, new Vector3(0, 0.6f, 4), Quaternion.Euler(0, 0, 90));
        }
        else
        {
            Instantiate(coins, new Vector3(0, 0.6f, -4), Quaternion.Euler(0, 0, 90));
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(spawncoin());
    }

    IEnumerator scores()
    {
        yield return new WaitForSeconds(0.5f);
        score++;
        StartCoroutine(scores());
    }
}
