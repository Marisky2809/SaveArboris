using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCentro3 : MonoBehaviour
{
    public AudioClip Escena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            SceneManager.LoadScene("Centro3");
            ControladorSonido.Instance.EjecutarSonido(Escena);
        }
    }
}
