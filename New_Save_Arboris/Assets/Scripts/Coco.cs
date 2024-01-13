using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class Coco : MonoBehaviour
{
    public bool posibleDisparo = true;

    public Movimiento BaviM;
    public Tomarcosas tomandoCosas;

    Vector3 Disparo;
    public GameObject coco;
    public GameObject agua;
    public GameObject chorro;

    public bool CocoTomado = false;

    public Animator Coquito;

    public bool solito = false;
    void Start()
    {
        Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
        Coquito = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BaviM.Tomando == false)
        {
            CocoTomado = false;
        }
        if (BaviM.Tomando && posibleDisparo && tomandoCosas.Coco)
        {
            if (tomandoCosas.Coco)
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
        if ((Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) || Input.GetKey(KeyCode.J) && posibleDisparo)
        {   
            chorro = Instantiate(agua);
            chorro.transform.position = coco.transform.position - (Disparo/1.5f);
            Coquito.SetBool("Disparo", true);
            StartCoroutine(DesactivarAnimacion());
            StartCoroutine(Disparando());
        }
        if (posibleDisparo == false)
        {
            chorro.transform.position += Disparo * Time.deltaTime * -9.0f;
        }

        if (solito && posibleDisparo)
        {
            StartCoroutine(DisparoSolito());
        }
    }
    IEnumerator Disparando()
    {
        posibleDisparo = false;
        yield return new WaitForSeconds(0.35f);
        chorro.SetActive(false);
        posibleDisparo = true;
    }
    IEnumerator DisparoSolito()
    {
        posibleDisparo = false;
        chorro = Instantiate(agua);
        chorro.transform.position = coco.transform.position - (Disparo / 1.5f);
        StartCoroutine(Disparando());
        chorro.transform.position += Disparo * Time.deltaTime * -9.0f;
        yield return new WaitForSeconds(1);
        posibleDisparo = true;
    }

    IEnumerator DesactivarAnimacion()
    {
        yield return new WaitForSeconds(0.25f);
        Coquito.SetBool("Disparo", false);
    }
}