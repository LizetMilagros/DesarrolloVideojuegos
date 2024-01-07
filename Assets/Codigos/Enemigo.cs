using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float damage;
    public int hp;
    public int dañoPuño;
    public Animator anim;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Calcula la dirección opuesta a la colisión.
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;

                // Aplica una fuerza para empujar al jugador hacia atrás.
                //playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);

                PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(damage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "golpeImpacto"){
            if(anim!= null){
                anim.Play("animacionEnemigo01");
            }
            hp -= dañoPuño;
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
