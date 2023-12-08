using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float healthAmount=10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.aumentarVida(healthAmount);
                Destroy(gameObject); // Destruye el ítem de salud después de recogerlo.
            }
        }
    }
}
