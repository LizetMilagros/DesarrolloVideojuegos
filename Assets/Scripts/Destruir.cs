using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class Destruir : MonoBehaviour
{
    public AudioSource sonido1;
    public AudioSource sonido2;
    public TextMeshProUGUI coinText;
    private int coinsCollected = 0;
    private int coinsToCollect = 3;
    public float rotationSpeed = 50f;
    public int count = 0;
    public float tiempoDeEspera = 5f; // Tiempo de espera en segundos entre cada sonido

    void Start()
    {
        UpdateCoinText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (count == 0){
            transform.position = new Vector3(18.9f, 0.7f, 15.2f);
            count++;
        }else if (count == 1){
            transform.position = new Vector3(67.7f, 0.7f, 2.55f);
            count++;
        }else if (count == 2){
            transform.position = new Vector3(67.7f, -500.0f, 2.55f);
        }
        sonido1.Play();
        coinsCollected++;
        UpdateCoinText();

        if (coinsCollected >= coinsToCollect)
        {
            print("Alcanzadooooo");
            sonido2.Play();
            // Cambiar a la siguiente escena o nivel
            // Aquí puedes cargar la siguiente escena usando SceneManager.LoadScene
            SceneManager.LoadScene("SegundoNivel");
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Monedas: " + coinsCollected + "/" + coinsToCollect;
    }

    void Update()
    {
        // Rotar la moneda gradualmente en el eje Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
