using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeekingMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public float damage;
    public float pushForce = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(player.transform.position);
        agent.SetDestination(player.position);
    }

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
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);

                PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(damage);
                }
            }
        }
    }
}
