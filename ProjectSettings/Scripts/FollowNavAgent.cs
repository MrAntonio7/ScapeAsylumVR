using UnityEngine;
using UnityEngine.AI;

public class FollowNavAgent : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    private NavMeshAgent agent;
    public GameObject enemy;
    public bool shouldFollow = false; // Bandera para controlar si debe seguir al jugador
    public AudioSource audioWalk;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el NavMeshAgent del NPC
    }

    void Update()
    {
        if (shouldFollow && player != null)
        {
            agent.SetDestination(player.position); // Establece el destino como la posición del jugador
            enemy.GetComponent<Animator>().SetBool("walking", true);
            // Reproducir audio solo si no está ya reproduciéndose
            if (!audioWalk.isPlaying)
            {
                audioWalk.Play();
            }
        }
        else
        {
            agent.SetDestination(transform.position); // Mantén la posición actual para detener el movimiento
            enemy.GetComponent<Animator>().SetBool("walking", false);
            // Detener el audio solo si está reproduciéndose
            if (audioWalk.isPlaying)
            {
                audioWalk.Stop();
            }
        }
    }

    public void StopFollowing()
    {
        shouldFollow = false; // Deja de seguir al jugador
    }

    public void StartFollowing()
    {
        shouldFollow = true; // Comienza a seguir al jugador
    }
}