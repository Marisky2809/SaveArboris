using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarAlCentro2 : MonoBehaviour
{
    public AudioClip Escena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            SceneManager.LoadScene("Centro2");
            ControladorSonido.Instance.EjecutarSonido(Escena);
        }
    }
}
