using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BateController : MonoBehaviour
{
    public GameObject enemy;
    private Rigidbody rb;
    public GameObject followEnemy;
    public GameObject hitEnemy;
    public float fuerza;
    //public float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        fuerza = 1.5f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (rb.velocity.magnitude > fuerza)
            {
            Destroy(followEnemy);
            Destroy(hitEnemy);
            enemy.GetComponent<EnemyController>().dead = true;
            enemy.GetComponent<FollowNavAgent>().shouldFollow = false;
            enemy.GetComponent<Animator>().SetBool("walking", false);
            //followEnemy.SetActive(false);
            //enemy.GetComponent<EnemyController>().follow = false;
            enemy.GetComponent<EnemyController>().ragroll.SetActive(true);
            enemy.GetComponent<ActiveRagdoll>().Active(true);
            Debug.Log("Batazo");
            }

        }
    }
}
