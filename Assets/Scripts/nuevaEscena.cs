using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nuevaEscena : MonoBehaviour
{
    public void nuevo(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
