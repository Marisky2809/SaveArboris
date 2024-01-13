using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogo : MonoBehaviour
{

    [SerializeField, TextArea (4,6)] private string[] LineasdeDialogo;

    [SerializeField] private GameObject Panel;

    [SerializeField] private TMP_Text TextodelDialogo;

    [SerializeField] private GameObject MarcadeDialogo;

    private float TypingTime = 0.05f;

    private bool Rangojugador;

    private bool IniciaelDialogo;

    private int LineadeTexto;

    public bool Hablado = false;

    private void Update()
    {
        if (Rangojugador && (Hablado == false || (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (!IniciaelDialogo)
            {
                IniciarDialogo();
            }
            else if (TextodelDialogo.text == LineasdeDialogo[LineadeTexto])
            {
                    SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                TextodelDialogo.text = LineasdeDialogo[LineadeTexto];
                Hablado = true;
            }
        }
    }

    private void IniciarDialogo()
    {
        IniciaelDialogo = true;
        Panel.SetActive(true);
        MarcadeDialogo.SetActive(false);
        LineadeTexto = 0;
        Time.timeScale = 0;
        StartCoroutine(MostrarLinea());
    }


    private void SiguienteLinea()
    {
        LineadeTexto++;
        if (LineadeTexto < LineasdeDialogo.Length)
        {
            StartCoroutine(MostrarLinea());
        }
        else
        {
            IniciaelDialogo = false;
            Panel .SetActive(false);
            MarcadeDialogo.SetActive(true);
            Time.timeScale = 1;
        }
    }


    private IEnumerator MostrarLinea()
    {
        TextodelDialogo.text = string.Empty;
        foreach (char ch in LineasdeDialogo[LineadeTexto]) 
        {
            TextodelDialogo.text += ch;
            yield return new WaitForSecondsRealtime(TypingTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            Rangojugador = true;
            MarcadeDialogo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            Rangojugador = false;
            Debug.Log("Sí funciona");
            MarcadeDialogo.SetActive(false);
            Destroy(gameObject);
        }
    }

}
