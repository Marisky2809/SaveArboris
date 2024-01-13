using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject porton;
    public GameObject accionador;

    public SpawnearEnemigos Hormiguero1;
    public SpawnearEnemigos Hormiguero2;
    public SpawnearEnemigos Hormiguero3;

    public GameObject Mensaje;
    public GameObject mensajeInstanciado;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bavi"))
        {
            if (Hormiguero1.Piedra && Hormiguero2.Piedra && Hormiguero3.Piedra)
            {
                porton.GetComponent<Renderer>().enabled = false;
                porton.GetComponent<Collider2D>().enabled = false;

                Rigidbody2D rigidbodyPorton = porton.GetComponent<Rigidbody2D>();
                if (rigidbodyPorton != null)
                {
                    rigidbodyPorton.simulated = false;
                }
            }
            else
            {
                mensajeInstanciado = Instantiate(Mensaje);
                mensajeInstanciado.transform.position = transform.position;
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
