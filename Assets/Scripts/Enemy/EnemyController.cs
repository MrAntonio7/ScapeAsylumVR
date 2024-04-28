using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform jugador; // Referencia al transform del jugador
    public float velocidad = 5f; // Velocidad a la que seguir� el objeto al jugador
    public Animator anim;
    public bool follow;
    public int vida = 20;
    public float tiempoAtaque = 1f; // Tiempo en segundos entre cada ataque
    private bool enemigoMuriendo = true;
    private Rigidbody rb;
    public GameObject ragroll;
    public bool dead;

    //private bool enemigoAtacando = false; // Indica si el enemigo est� atacando actualmente
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        follow = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ragroll.SetActive(false);

    }

    void Update()
    {
        if (follow)
        {
            // Verifica si el jugador est� asignado
            if (jugador != null)
            {
                // Calcula la direcci�n hacia la posici�n del jugador
                Vector3 direccion = jugador.position - transform.position;
                direccion.y = 0; // Ignora la componente Y para mantener la altura del objeto constante
                direccion.Normalize(); // Normaliza la direcci�n para que tenga longitud 1

                // Calcula la rotaci�n para que el objeto mire hacia el jugador
                Quaternion rotacionHaciaJugador = Quaternion.LookRotation(direccion);

                // Aplica la rotaci�n al objeto, solo rotando en el eje Y
                transform.rotation = Quaternion.Euler(0f, rotacionHaciaJugador.eulerAngles.y, 0f);

                // Calcula la posici�n a la que se mover� el objeto en este frame
                Vector3 nuevaPosicion = transform.position + direccion * velocidad * Time.deltaTime;

                // Asigna la nueva posici�n al objeto
                transform.position = nuevaPosicion;
            }
        }
        if (vida <= 0)
        {
            StartCoroutine(ZombieMuerto(2));
        }

        
    }
    public void QuitarVida()
    {
        vida--;
        StartCoroutine("AnimacionDanio", 0.2);

    }

    public IEnumerator AnimacionDanio(int sec)
    {
        anim.SetBool("damage", true);
        yield return new WaitForSeconds(sec);
        anim.SetBool("damage", false);
    }
    public IEnumerator ZombieMuerto(int sec)
    {
        if (enemigoMuriendo)
        {
            anim.SetBool("dead", true);
            FreezeAllPosition();
            enemigoMuriendo = false;
            //anim.SetBool("dead", false);
            yield return new WaitForSeconds(sec);

            Destroy(gameObject);
        }

    }
    // M�todo para congelar todas las posiciones
    void FreezeAllPosition()
    {
        // Asegurarse de que el Rigidbody no sea nulo
        if (rb != null)
        {
            // Obtener las constraints actuales
            RigidbodyConstraints constraints = rb.constraints;

            // Activar el freeze position en todos los ejes
            constraints |= RigidbodyConstraints.FreezePositionX;
            constraints |= RigidbodyConstraints.FreezePositionY;
            constraints |= RigidbodyConstraints.FreezePositionZ;

            // Aplicar las nuevas constraints al Rigidbody
            rb.constraints = constraints;
        }
    }




}
