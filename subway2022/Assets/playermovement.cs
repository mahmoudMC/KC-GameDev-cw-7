using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Animator an;
    int currentposition = 2;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentposition == 1)
            {
                currentposition = 2;
                an.Play("fromright");
            }
            else if (currentposition == 2)
            {
                currentposition = 3;
                an.Play("toleft");
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentposition == 3)
            {
                currentposition = 2;
                an.Play("fromleft");
            }
            else if (currentposition == 2)
            {
                currentposition = 1;
                an.Play("toright");
            }
        }
    }
}
