using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject panel; // Asegúrate de asignar tu panel en el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ajusta la etiqueta según tu configuración
        {
            Time.timeScale = 0;
            panel.SetActive(true); // Activa el panel cuando el jugador entra en el trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ajusta la etiqueta según tu configuración
        {
            panel.SetActive(false); // Desactiva el panel cuando el jugador sale del trigger
        }
    }
}
