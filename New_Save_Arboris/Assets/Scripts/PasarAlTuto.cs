
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarAlTuto : MonoBehaviour
{
    public AudioClip Escena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            SceneManager.LoadScene("SampleScene");
            ControladorSonido.Instance.EjecutarSonido(Escena);
        }
    }
}
