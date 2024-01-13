using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImprimirPuntos : MonoBehaviour
{
    public Vidas BaviV;
    private int puntos;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        puntos = BaviV.PETs;
        textMesh.text = puntos.ToString();
    }
}
