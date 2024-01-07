using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPanel : MonoBehaviour
{
    public GameObject panel; // Referencia al panel que quieres activar/desactivar

    void Update()
    {
        // Verificar si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternar el estado activo/desactivo del panel
            if (panel != null)
            {
                bool menuActive = !panel.activeSelf;
                panel.SetActive(menuActive);

                // Pausar o reanudar el tiempo en el juego según el estado del menú
                Time.timeScale = menuActive ? 0f : 1f;
            }
        }
    }
}
