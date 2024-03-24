using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarRama : MonoBehaviour
{

    public Movimiento BaviM;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            BaviM.posibleAtaque = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            BaviM.posibleAtaque = true;
        }
    }
}
