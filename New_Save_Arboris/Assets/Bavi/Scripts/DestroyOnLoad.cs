using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLoad : MonoBehaviour
{
    public static DestroyOnLoad instancia;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
