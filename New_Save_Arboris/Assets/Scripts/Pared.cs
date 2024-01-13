using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    public GameObject porton;
    public GameObject accionador;
    public bool Mimosa = false;

    void Start()
    {
        porton.GetComponent<Renderer>().enabled = false;
        porton.GetComponent<Collider2D>().enabled = false;

        Rigidbody2D rigidbodyPorton = porton.GetComponent<Rigidbody2D>();
        if (rigidbodyPorton != null)
        {
            rigidbodyPorton.simulated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bavi"))
        {
            porton.GetComponent<Collider2D>().enabled = true;

            Rigidbody2D rigidbodyPorton = porton.GetComponent<Rigidbody2D>();
            if (rigidbodyPorton != null)
            {
                rigidbodyPorton.simulated = true;
            }
            Mimosa = true;
        }
    }
}