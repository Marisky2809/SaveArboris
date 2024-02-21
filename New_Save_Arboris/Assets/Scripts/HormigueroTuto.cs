using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormigueroTuto : MonoBehaviour
{
    public SpawnearEnemigos hormiguero;
    public SpawnearEnemigos hormiguero2;
    public SpawnearEnemigos hormiguero3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bavi"))
        {
            hormiguero.Piedra = false;
            hormiguero2.Piedra = false;
            hormiguero3.Piedra = false;
        }
    }
}
