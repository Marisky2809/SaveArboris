
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarAlCoco : MonoBehaviour
{
    public AudioClip Escena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            SceneManager.LoadScene("CocoNivel");
            ControladorSonido.Instance.EjecutarSonido(Escena);
        }
    }
}
