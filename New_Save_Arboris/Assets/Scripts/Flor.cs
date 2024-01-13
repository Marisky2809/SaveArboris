using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    public GameObject florecita;
    public GameObject macetita;

    public GameObject mensaje;
    public GameObject InMensaje;
    public bool flor = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisionó tiene el tag "Maceta"
        if (collision.collider.CompareTag("Maceta"))
        {
            macetita = collision.gameObject;
            florecita.transform.position = macetita.transform.position + Vector3.up * 0.85f;
            florecita.transform.SetParent(null);
            florecita.transform.SetParent(macetita.transform);
            Collider2D florecitaCollider = florecita.GetComponent<Collider2D>();
            if (florecitaCollider != null)
            {
                florecitaCollider.enabled = false;
            }
            InMensaje = Instantiate(mensaje);
            flor = true;
            InMensaje.transform.position = transform.position;
        }
    }
}
