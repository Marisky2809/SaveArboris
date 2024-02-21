using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    public GameObject golpeado;

    public AudioClip GolpeAgua;
    public AudioClip Fuego;

    public GameObject aguita;
    public GameObject chorro;

    private void Start()
    {
        aguita = GameObject.Find("AguaCoco");
        chorro = aguita;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            golpeado = collision.gameObject;
            Destroy(golpeado);
            ControladorSonido.Instance.EjecutarSonido(GolpeAgua);
            golpeado = GameObject.Find("Vacio");
        }
        if (collision.gameObject.CompareTag("Amenaza"))
        {
            golpeado = collision.gameObject;
            Destroy(golpeado);
            ControladorSonido.Instance.EjecutarSonido(Fuego);
            golpeado = GameObject.Find("Vacio");
        }
    }
}
