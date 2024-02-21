using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscena : MonoBehaviour
{
    public AudioClip Escena;
    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
        ControladorSonido.Instance.EjecutarSonido(Escena);
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Centro");
        ControladorSonido.Instance.EjecutarSonido(Escena);
    }

    public void EloteNivel()
    {
        SceneManager.LoadScene("EloteNivel");
        ControladorSonido.Instance.EjecutarSonido(Escena);
    }

    public void CocoNivel()
    {
        SceneManager.LoadScene("CocoNivel");
        ControladorSonido.Instance.EjecutarSonido(Escena);
    }
}
