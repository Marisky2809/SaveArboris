using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnearEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject Bichitio;
    [SerializeField] private float tiempodesalida = 7.5f;
    public bool Piedra;

    public GameObject hormiguero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Piedra")) { 
            Piedra = true;
            Debug.Log(Piedra);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Piedra"))
        {
            Piedra = false;
            Debug.Log(Piedra);
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnerEnemigo(tiempodesalida, Bichitio));
        Piedra = true;
    }

    private IEnumerator SpawnerEnemigo(float Intervalo, GameObject Enemigo)
    {
        yield return new WaitForSeconds(Intervalo);
        Debug.Log("Pasó Tiempo");
        if (Piedra == false)
        {
            Vector3 spawnPosition = hormiguero.transform.position;
            GameObject NuevoEnemigo = Instantiate(Enemigo, spawnPosition, Quaternion.identity);
        }
        StartCoroutine(SpawnerEnemigo(Intervalo, Enemigo));
    }
}
