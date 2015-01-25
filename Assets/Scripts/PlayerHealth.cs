using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public AudioClip damageSound;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    AudioSource playerAudio;
    PlayerMove playerMovement;
    bool isDead;
    bool damaged;


    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMove>();
        currentHealth = startingHealth;
        healthSlider.value = startingHealth;
    }


    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.clip = damageSound;
        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        playerMovement.DieFromHealth();
    }

}
