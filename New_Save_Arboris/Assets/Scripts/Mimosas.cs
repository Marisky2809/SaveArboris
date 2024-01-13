using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimosas : MonoBehaviour
{
    public Pared puerta;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        puerta.Mimosa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (puerta.Mimosa)
        {
            animator.SetBool("Cerrar", true);
        }
    }
}
