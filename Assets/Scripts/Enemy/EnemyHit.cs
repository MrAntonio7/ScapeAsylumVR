using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject enemy;
    public Animator animator;
    private CapsuleCollider hit;
    public GameObject player;
    public bool pegando;
    public GameObject follow;
    
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<CapsuleCollider>();
        //audioHit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            enemy.GetComponent<FollowNavAgent>().shouldFollow = false;
            enemy.GetComponent<Animator>().SetBool("walking", false);
            //follow.SetActive(false);
            //enemy.GetComponent<EnemyController>().follow = false;
            animator.SetBool("hit", true);
            pegando = true;
            player.GetComponent<PlayerController>().currentHit = pegando;
            StartCoroutine(player.GetComponent<PlayerController>().TakeDamageOverTime());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            
            //follow.SetActive(true);
            enemy.GetComponent<FollowNavAgent>().shouldFollow = true;
            enemy.GetComponent<Animator>().SetBool("walking", true);
            //enemy.GetComponent<EnemyController>().follow = true;
            animator.SetBool("hit", false);
            pegando = false;
            player.GetComponent<PlayerController>().currentHit = pegando;
            StopCoroutine(player.GetComponent<PlayerController>().TakeDamageOverTime());
        }
    }
}
