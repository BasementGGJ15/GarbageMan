using UnityEngine;
using System.Collections;

public class DestroyByCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Area1" && other.tag != "Area2" && other.tag != "Area3" && other.tag != "Area4" && other.tag != "Area5" && other.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Damageable" || other.tag == "Area1Spawner" || other.tag == "Area2Spawner" ||
            other.tag == "Area3Spawner" || other.tag == "Area4Spawner" || other.tag == "Area5Spawner")
        {
            EnemyHealth eh = other.gameObject.GetComponent<EnemyHealth>();
            eh.TakeDamage(1);
        }
    }
}
