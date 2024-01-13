using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirObjetivo : MonoBehaviour
{
    public GameObject objetivo;
    Vector3 buscarObjetivo;

    private void Update()
    {
        buscarObjetivo = (transform.position - objetivo.transform.position)/5;
        transform.position += (buscarObjetivo * -1 * 2.5f * Time.deltaTime);
    }
}
