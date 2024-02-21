using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarHormiguero : MonoBehaviour
{
    public SpawnearEnemigos hormiguero;
    public SpawnearEnemigos hormiguero2;
    public SpawnearEnemigos hormiguero3;
    public SpawnearEnemigos hormiguero4;
    public SpawnearEnemigos hormiguero5;
    public SpawnearEnemigos hormiguero6;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bavi"))
        {
            hormiguero.Piedra = false;
            hormiguero2.Piedra = false;
            hormiguero3.Piedra = false;
            hormiguero4.Piedra = false;
            hormiguero5.Piedra = false;
        }
    }
}
