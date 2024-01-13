using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    public GameObject golpeado;

    public AudioClip GolpeAgua;
    public GameObject aguita;
    public GameObject chorro;

    private void Start()
    {
        aguita = GameObject.Find("AguaCoco");
        chorro = aguita;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            //ControladorSonido.Instance.EjecutarSonido(GolpeAgua);
            golpeado = collision.gameObject;
            Destroy(golpeado);

            golpeado = GameObject.Find("Vacio");

            Object.Destroy(chorro);
        }
    }
}
