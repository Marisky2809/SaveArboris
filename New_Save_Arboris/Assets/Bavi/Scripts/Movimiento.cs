using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public Tomarcosas tomar;
    public Piedra piedra;
    public Vidas vidas;
    
    public bool posibleAtaque = true;

    public bool Tomando = false;
    public bool Agarrar = false;
    
    public GameObject Bavi;
    public GameObject RamaGolpeadora;

    private float velocidad = 4.5f;
    
    public Animator animator;

    public GameObject referencia;
    public GameObject mira;
    public GameObject centro;

    public bool triangulo = false;


    public AudioSource audios;
    public AudioClip GolpeAire;
    public AudioClip pisadas;
    public AudioClip soltar;
    public AudioClip sostener;

    private float tiempoAcumulado = 0f;
    public float tiempoEspera = 0.1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        RamaGolpeadora.SetActive(false);
        audios = GetComponent<AudioSource>();
    }

    void Update()
    {
        tiempoAcumulado += Time.deltaTime;

        centro.transform.position = Bavi.transform.position + Vector3.down * .3f;

        if (Input.GetKey(KeyCode.W)|| (Gamepad.current != null && Gamepad.current.leftStick.up.isPressed))
        {
            Bavi.transform.position += Vector3.up * Time.deltaTime * velocidad;
            animator.SetBool("Arriba", true);
            if (velocidad != 0)
            {
                animator.SetBool("Avanzando", true);
            }
            else
            {
                animator.SetBool("Avanzando", false);
            }
            animator.SetBool("Derecha", false);
            animator.SetBool("Izquierda", false);
            animator.SetBool("Abajo", false);

            referencia.transform.position = centro.transform.position + Vector3.up * .5f;
            mira.transform.position = centro.transform.position + Vector3.up * 1f;
            tomar.acercar = false;

            if (tiempoAcumulado >= tiempoEspera)
            {
                audios.PlayOneShot(pisadas);
                tiempoAcumulado = 0f;
            }
        }
        else if (Input.GetKey(KeyCode.A) || (Gamepad.current != null && Gamepad.current.leftStick.left.isPressed))
        {
            Bavi.transform.position += Vector3.left * Time.deltaTime * velocidad;
            animator.SetBool("Izquierda", true);
            if (velocidad != 0)
            {
                animator.SetBool("Avanzando", true);
            }
            else
            {
                animator.SetBool("Avanzando", false);
            }
            animator.SetBool("Derecha", false);
            animator.SetBool("Abajo", false);
            animator.SetBool("Arriba", false);

            referencia.transform.position = centro.transform.position + Vector3.left * .5f;
            mira.transform.position = centro.transform.position + Vector3.left * 1f;
            tomar.acercar = false;

            if (tiempoAcumulado >= tiempoEspera)
            {
                audios.PlayOneShot(pisadas);
                tiempoAcumulado = 0f;
            }
        }
        else if (Input.GetKey(KeyCode.S) || (Gamepad.current != null && Gamepad.current.leftStick.down.isPressed))
        {
            Bavi.transform.position += Vector3.down * Time.deltaTime * velocidad;
            animator.SetBool("Abajo", true);
            if (velocidad != 0)
            {
                animator.SetBool("Avanzando", true);
            }
            else
            {
                animator.SetBool("Avanzando", false);
            }
            animator.SetBool("Izquierda", false);
            animator.SetBool("Arriba", false);
            animator.SetBool("Derecha", false);

            referencia.transform.position = centro.transform.position + Vector3.down * .5f;
            mira.transform.position = centro.transform.position + Vector3.down * 1f;

            tomar.acercar = true;

            if (tiempoAcumulado >= tiempoEspera)
            {
                audios.PlayOneShot(pisadas);
                tiempoAcumulado = 0f;
            }
        }
        else if (Input.GetKey(KeyCode.D) || (Gamepad.current != null && Gamepad.current.leftStick.right.isPressed))
        {
            Bavi.transform.position += Vector3.right * Time.deltaTime * velocidad;
            animator.SetBool("Derecha", true);
            if (velocidad != 0)
            {
                animator.SetBool("Avanzando", true);
            }
            else
            {
                animator.SetBool("Avanzando", false);
            }
            animator.SetBool("Izquierda", false);
            animator.SetBool("Arriba", false);
            animator.SetBool("Abajo", false);

            referencia.transform.position = centro.transform.position + Vector3.right * .5f;
            mira.transform.position = centro.transform.position + Vector3.right * 1f;
            tomar.acercar = false;

            if (tiempoAcumulado >= tiempoEspera)
            {
                audios.PlayOneShot(pisadas);
                tiempoAcumulado = 0f;
            }
        }
        else
        {
            animator.SetBool("Avanzando", false);
        }


        if ((Input.GetKeyDown(KeyCode.L) || (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)) && tomar.Tomable && Tomando == false)
        {
            Agarrar = true;
            audios.PlayOneShot(sostener);
        }
        if ((Input.GetKeyDown(KeyCode.L) || (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)) && Tomando)
        {
            Agarrar = false;
            triangulo = false;
            audios.PlayOneShot(soltar);
        }

        if ((Input.GetKeyDown(KeyCode.K) || (Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame)) && Tomando == false && posibleAtaque)
        {
            animator.SetBool("Ataque", true);
            posibleAtaque = false;
            StartCoroutine(GolpeTime());
        }

        if (Tomando)
        {
            animator.SetBool("Sosteniendo", true);
        }
        else
        {
            animator.SetBool("Sosteniendo", false);
        }
    }
    IEnumerator GolpeTime()
    {
        yield return new WaitForSeconds(0.05f);
        RamaGolpeadora.SetActive(true);
        RamaGolpeadora.transform.position = referencia.transform.position;
        RamaGolpeadora.transform.SetParent(Bavi.transform);
        audios.PlayOneShot(GolpeAire);
        yield return new WaitForSeconds(0.1f);
        RamaGolpeadora.transform.SetParent(null);
        RamaGolpeadora.SetActive(false);
        animator.SetBool("Ataque", false);
        posibleAtaque = true;
    }
}

