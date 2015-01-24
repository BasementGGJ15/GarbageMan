using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    //public AudioClip deathClip;


    //Animator anim;
    //AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    //Collider collider;
    bool isDead;
    //bool isSinking;


    void Awake()
    {
        //anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        //collider = GetComponent<Collider>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        //if (isSinking)
        //{
        //    transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        //}
    }


    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        //enemyAudio.Play();

        currentHealth -= amount;

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //collider.isTrigger = true;

        //anim.SetTrigger("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }


    //public void StartSinking()
    //{
    //    GetComponent<NavMeshAgent>().enabled = false;
    //    GetComponent<Rigidbody>().isKinematic = true;
    //    isSinking = true;
    //    ScoreManager.score += scoreValue;
    //    Destroy(gameObject, 2f);
    //}
}
