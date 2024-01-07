using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
        }
    }
}
