using UnityEngine;
using System.Collections;

[System.Serializable]
public class PieceOfGarbagePickUp : PickUp {

    public AudioSource PickupAudioSource;
    public AudioClip PickupClip;
    public GameManager gameManager;

    public override void Get()
    {
        base.Get();
        gameManager.RemoveGarbage();
        PickupAudioSource.clip = PickupClip;
        PickupAudioSource.Play();
    }
}
