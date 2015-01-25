using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    public float speed = 6f;
    public float range = 100f;
    
    Vector3 movement;
    Vector3 aim;
    LineRenderer gunLine;
    Animator anim;
    Rigidbody playerRigidbody;
    public LayerMask layerToIgnore;

    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;

    private float atan2;

    private bool isDead = false;

    AudioSource audioSource;
    public AudioClip deathByMeter;
    public AudioClip shoot;
    public AudioClip deathByHealth;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        GameObject gunLineObj = GameObject.FindGameObjectWithTag("GunLine");
        gunLine = gunLineObj.GetComponent<LineRenderer>();
        gunLine.sortingLayerName = "OnGround";
    }


    void FixedUpdate()
    {
        if (!isDead)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            float aimH = Input.GetAxisRaw("Horizontal2");
            float aimV = Input.GetAxisRaw("Vertical2");

            Move(h, v);
            Aiming(aimH, aimV);
            Animating(h, v);
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position + movement);
        //playerRigidbody.angularVelocity = 0;
    }

    void Aiming(float h, float v)
    {
        if (h == 0 && v == 0)
        {
            gunLine.enabled = false;
        }
        else
        {
            //			Debug.Log("h: " + h + "  v: " + v);
            aim.Set(h, 0, v);
            gunLine.enabled = true;

            RaycastHit2D hit = Physics2D.Raycast(playerRigidbody.position, aim, Mathf.Infinity, ~layerToIgnore);
            gunLine.SetPosition(0, playerRigidbody.position);
            if (hit.collider == null)
            {
                //				Debug.Log("NoHit!");
                gunLine.SetPosition(1, playerRigidbody.position + aim.normalized * range);
            }
            else
            {
                //				Debug.Log ("Hit!" + hit.collider.name);
                gunLine.SetPosition(1, playerRigidbody.position + aim.normalized * hit.distance);
            }

            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                audioSource.clip = shoot;
                nextFire = Time.time + fireRate;
                atan2 = Mathf.Atan2(aim.x, aim.z);
                Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(90f, atan2 * Mathf.Rad2Deg, 0f));
                audioSource.Play();
            }
        }
    }

    void Animating(float h, float v)
    {
        if (!(h == 0 && v == 0))
        {
            if (Mathf.Abs(h) > Mathf.Abs(v))
            {
                //horizontal
                if (h > 0)
                {
                    anim.SetTrigger("MovingRight");
                }
                else
                {
                    anim.SetTrigger("MovingLeft");
                }
            }
            else
            {
                //vertical
                if (v > 0)
                {
                    anim.SetTrigger("MovingBack");
                }
                else
                {
                    anim.SetTrigger("MovingForward");
                }
            }
        }
    }

    public void DieFromMeter()
    {
        isDead = true;
        collider.enabled = false;
        anim.SetTrigger("DieFromMeter");
    }

    public void DieFromHealth()
    {
        isDead = true;
        collider.enabled = false;
        PlayDeathSound();
        anim.SetTrigger("DieFromHealth");      
    }

    public void PlayDeathSound()
    {
        audioSource.clip = deathByMeter;
        audioSource.Play();
    }
}
