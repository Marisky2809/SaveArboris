
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarAlElote : MonoBehaviour
{
    public AudioClip Escena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            SceneManager.LoadScene("EloteNivel");
            ControladorSonido.Instance.EjecutarSonido(Escena);
        }
    }
}
