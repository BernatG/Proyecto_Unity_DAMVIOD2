using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;

    [Tooltip("Escala del tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    public Text myText;
    private float tiempoDelFrameConTimeScale = -0f;
    private float TiempoAMostrarEnSegundos = 0f;
    private float escalaDeTiempoAlPausar, escalaDeTiempoInicial;
    private bool estaPausado = false;

    // Start is called before the first frame update
    void Start()
    {
        escalaDeTiempoInicial = escalaDeTiempo;

        TiempoAMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;

        TiempoAMostrarEnSegundos -= tiempoDelFrameConTimeScale;
        ActualizarReloj(TiempoAMostrarEnSegundos);
    }

    public void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("") + ":" + segundos.ToString("00");

        myText.text = textoDelReloj;
    }
}
