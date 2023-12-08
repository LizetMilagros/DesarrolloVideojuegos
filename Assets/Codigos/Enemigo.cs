using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float damage;
    
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
}
