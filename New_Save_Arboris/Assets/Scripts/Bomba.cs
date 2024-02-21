using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public GameObject golpeado;

    public AudioClip GolpeBasura;
    public AudioClip GolpeEnemigo;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Basura"))
        {
            ControladorSonido.Instance.EjecutarSonido(GolpeBasura);
            golpeado = other.gameObject;
            Destroy(golpeado);
            golpeado = GameObject.Find("Vacio");
        }

        if (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("RompePiedra"))
        {
            ControladorSonido.Instance.EjecutarSonido(GolpeEnemigo);
            golpeado = other.gameObject;
            Destroy(golpeado);
            golpeado = GameObject.Find("Vacio");
        }
    }
}
