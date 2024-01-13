using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoMeDejes : MonoBehaviour
{
    public GameObject porton;
    public GameObject accionador;

    public Tomarcosas Agarrar;
    public Flor florecita;

    public GameObject Mensaje;
    public GameObject mensajeInstanciado;
    void Start()
    {
        /*porton.GetComponent<Renderer>().enabled = true;
        porton.GetComponent<Collider2D>().enabled = true;*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bavi"))
        {
            if (Agarrar.Maceta && florecita.flor)
            {
                porton.GetComponent<Renderer>().enabled = false;
                porton.GetComponent<Collider2D>().enabled = false;

                Rigidbody2D rigidbodyPorton = porton.GetComponent<Rigidbody2D>();
                if (rigidbodyPorton != null)
                {
                    rigidbodyPorton.simulated = false;
                }
                Debug.Log(Agarrar.Maceta);
            }
            else
            {
                mensajeInstanciado = Instantiate(Mensaje);
                mensajeInstanciado.transform.position = transform.position;
                Debug.Log(Agarrar.Maceta);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bavi"))
        {
            Destroy(mensajeInstanciado);
        }        
    }
}
