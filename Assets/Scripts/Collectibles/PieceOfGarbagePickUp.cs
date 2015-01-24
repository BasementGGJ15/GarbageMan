using UnityEngine;
using System.Collections;

[System.Serializable]
public class PieceOfGarbagePickUp : PickUp {

    public AudioSource PickupAudioSource;
    public AudioClip PickupClip;

    public override void Get()
    {
        base.Get();
        PickupAudioSource.clip = PickupClip;
        PickupAudioSource.Play();
    }
}
