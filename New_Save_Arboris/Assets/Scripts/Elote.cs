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
    public GameObject Random;

    public GameObject Paloma;
    public GameObject roseta;

    public bool CocoTomado = false;

    public Animator Coquito;

    public float velocidadCrecimiento = 5.0f;
    public float tamañoMaximo = 150.0f;

    public AudioSource audios;
    public AudioClip estallido;
    void Start()
    {
        Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
        Coquito = GetComponent<Animator>();
        audios = GetComponent<AudioSource>();
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

        if ((Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) || Input.GetKeyDown(KeyCode.J))
        {
            if (posibleBomba == false)
            {
                if (Bomba != null)
                {
                    Explosion = Instantiate(ExplosionBomba);
                    ExplosionBomba.transform.position = Random.transform.position;
                    audios.PlayOneShot(estallido);
                    Paloma = Instantiate(roseta);
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
        yield return new WaitForSeconds(0.5f);
        posibleBomba = true;
        Debug.Log("Recargó");
    }
    IEnumerator Crecer()
    {
        float tiempoTranscurrido = 0f;
        Explosion.transform.position = Bomba.transform.position;
        Paloma.transform.position = Bomba.transform.position;

        while (tiempoTranscurrido < 0.5f)
        {
            float nuevoTamaño = Mathf.Lerp(1.0f, tamañoMaximo, tiempoTranscurrido / 2.0f);
            Explosion.transform.localScale = new Vector3(nuevoTamaño * 5, nuevoTamaño * 5, 1.0f);
            
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
        Explosion.transform.localScale = new Vector3(tamañoMaximo, tamañoMaximo, 1.0f);
        StartCoroutine(Recargar());
        Destroy(Paloma);
        Destroy(Bomba);
        Destroy(Explosion);
    }
    IEnumerator DesactivarAnimacion()
    {
        yield return new WaitForSeconds(0.25f);
        Coquito.SetBool("Disparo", false);
    }
}
