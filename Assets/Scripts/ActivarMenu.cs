using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarMenu : MonoBehaviour
{
    public GameObject opciones;
    public void BotonScena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
    public void activarOpciones(){
        opciones.SetActive(true);
    }
}
