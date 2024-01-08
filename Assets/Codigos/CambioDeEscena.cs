using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string nivel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(nivel);
        }
        
    }
}
