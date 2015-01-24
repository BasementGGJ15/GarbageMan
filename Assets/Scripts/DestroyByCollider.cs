using UnityEngine;
using System.Collections;

public class DestroyByCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Ground" && other.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Damageable")
        {
            EnemyHealth eh = other.gameObject.GetComponent<EnemyHealth>();
            eh.TakeDamage(1);
        }
    }
}
