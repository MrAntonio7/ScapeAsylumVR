using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    private Rigidbody rb;
    public int life = 5;
    public int currentHealth; // Vida actual del jugador
    public int damagePerSecond = 1; // Cantidad de daño por segundo
    public TextMeshProUGUI textoVida;
    public AudioSource audioHitEnemy;

    private AudioSource source;
    public bool currentHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Al inicio, la vida actual del jugador es igual a la vida máxima
        currentHealth = life;
        //stamineSlider = FindAnyObjectByType<StamineBar>();
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.text = currentHealth.ToString();
        //if (GameManager.instance.muerto)   
        //{
        //    return;
        //}



    }

    void FixedUpdate()
    {
        float maxFallingSpeed = 50f; // Define tu límite de velocidad
        if (rb.velocity.magnitude > maxFallingSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxFallingSpeed;
        }
    }
    // Corutina para restar vida al jugador cada segundo
    public IEnumerator TakeDamageOverTime()
    {
        
        // Repetir el proceso mientras la vida del jugador sea mayor que cero
        while (currentHealth > 0 && currentHit)
        {
            // Restar vida al jugador
            TakeDamage(damagePerSecond);

            // Esperar un segundo antes de restar más vida
            yield return new WaitForSeconds(1.7f);
        }
    }

    // Método para restar vida al jugador
    public void TakeDamage(int amount)
    {
        
        // Restar la cantidad de daño recibida a la vida actual del jugador
        currentHealth -= amount;
        audioHitEnemy.Play();
        // Asegurarse de que la vida actual del jugador no sea menor que cero
        currentHealth = Mathf.Max(currentHealth, 0);

        // Aquí podrías agregar cualquier lógica adicional que desees al recibir daño
        Debug.Log("¡El jugador ha recibido " + amount + " puntos de daño! Vida actual: " + currentHealth);

        // Verificar si la vida del jugador ha llegado a cero
        if (currentHealth <= 0)
        {
            // Aquí podrías ejecutar alguna lógica cuando el jugador muera
            Debug.Log("¡El jugador ha muerto!");
            SceneManager.LoadScene("DerrotaScene");
        }
    }
}
