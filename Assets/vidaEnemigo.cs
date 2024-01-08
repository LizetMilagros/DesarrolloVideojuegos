using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public int hp;
    public int dañoPuño;
    public Animator anim;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "golpeImpacto"){
            if(anim!= null){
                anim.Play("pruebaEnemigo");
            }
            hp -= dañoPuño;
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
