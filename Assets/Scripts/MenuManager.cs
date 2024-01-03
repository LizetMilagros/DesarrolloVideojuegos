using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject opciones;
    public GameObject niveles;
    // Start is called before the first frame update
    public void BotonStart(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    // Update is called once per frame
    public void BotonQuit()
    {
        Debug.Log("Quitamos la aplicacion");
        Application.Quit();
    }
    public void activarOpciones(){
        menu.SetActive(false);
        opciones.SetActive(true);
    }
    public void activarMenu(){
        menu.SetActive(true);
        opciones.SetActive(false);
    }

    public void activarSeleccionNiveles(){
        menu.SetActive(false);
        niveles.SetActive(true);
    }

    public void volverMenu(){
        menu.SetActive(true);
        niveles.SetActive(false);
    }
}
