using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool tengoQueBajar = false;
    int speed = 10;
    void Update()
    {
        if (transform.position.x >= 9)
        {
            tengoQueBajar = true;
        }
        if (transform.position.x <= -9)
        {
            tengoQueBajar = false;
        }

        if (tengoQueBajar)
        {
            Bajar();
        }
        else
        {
            Subir();
        }

    }
    void Subir()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void Bajar()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
    }

}
