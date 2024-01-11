using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elote : MonoBehaviour
{
    public bool posibleBomba = true;

    public Movimiento BaviM;
    public Tomarcosas tomandoCosas;

    Vector3 Disparo;
    public GameObject elote;
    public GameObject Maicito;
    public GameObject Bomba;
    public GameObject Maiz;
    public GameObject Explosion;
    public GameObject ExplosionBomba;

    public bool CocoTomado = false;

    public Animator Coquito;

    public float velocidadCrecimiento = 5.0f;
    public float tama�oMaximo = 150.0f;
    void Start()
    {
        Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
        Coquito = GetComponent<Animator>();
    }


    void Update()
    {

        if (BaviM.Tomando == false)
        {
            CocoTomado = false;
        }
        if (BaviM.Tomando)
        {
            if (tomandoCosas.Elotito)
            {
                Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);

                if (Input.GetKey(KeyCode.W) || (Gamepad.current != null && Gamepad.current.leftStick.up.isPressed))
                {
                    Coquito.SetBool("Arriba", true);

                    Coquito.SetBool("Derecha", false);
                    Coquito.SetBool("Izquierda", false);
                    Coquito.SetBool("Abajo", false);
                }
                else if (Input.GetKey(KeyCode.A) || (Gamepad.current != null && Gamepad.current.leftStick.left.isPressed))
                {
                    Coquito.SetBool("Izquierda", true);
                    Coquito.SetBool("Arriba", false);
                    Coquito.SetBool("Derecha", false);
                    Coquito.SetBool("Abajo", false);
                }
                else if (Input.GetKey(KeyCode.S) || (Gamepad.current != null && Gamepad.current.leftStick.down.isPressed))
                {
                    Coquito.SetBool("Abajo", true);

                    Coquito.SetBool("Arriba", false);
                    Coquito.SetBool("Derecha", false);
                    Coquito.SetBool("Izquierda", false);
                }
                else if (Input.GetKey(KeyCode.D) || (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed))
                {
                    Coquito.SetBool("Derecha", true);

                    Coquito.SetBool("Arriba", false);
                    Coquito.SetBool("Abajo", false);
                    Coquito.SetBool("Izquierda", false);
                }
            }
        }


        if (BaviM.Tomando && posibleBomba)
        {
            Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
        }

        if ((Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) || Input.GetKeyDown(KeyCode.V))
        {
            if (posibleBomba == false)
            {
                if (Bomba != null)
                {
                    Explosion = Instantiate(ExplosionBomba);
                    StartCoroutine(Crecer());
                }
            }
            else if(posibleBomba)
            {
                {
                    Bomba = Instantiate(Maicito);
                    Coquito.SetBool("Disparo", true);
                    StartCoroutine(DesactivarAnimacion());
                    Bomba.transform.position = elote.transform.position - (Disparo / 1.5f);
                    posibleBomba = false;
                }
            }
        }
    }
    IEnumerator Recargar()
    {
        yield return new WaitForSeconds(2f);
        posibleBomba = true;
        Debug.Log("Recarg�");
    }
    IEnumerator Crecer()
    {
        float tiempoTranscurrido = 0f;
        Explosion.transform.position = Bomba.transform.position;

        while (tiempoTranscurrido < 0.5f)
        {
            float nuevoTama�o = Mathf.Lerp(1.0f, tama�oMaximo, tiempoTranscurrido / 2.0f);
            Explosion.transform.localScale = new Vector3(nuevoTama�o * 5, nuevoTama�o * 5, 1.0f);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
        Explosion.transform.localScale = new Vector3(tama�oMaximo, tama�oMaximo, 1.0f);
        StartCoroutine(Recargar());
        Destroy(Bomba);
        Destroy(Explosion);
    }
    IEnumerator DesactivarAnimacion()
    {
        yield return new WaitForSeconds(0.25f);
        Coquito.SetBool("Disparo", false);
    }
}
