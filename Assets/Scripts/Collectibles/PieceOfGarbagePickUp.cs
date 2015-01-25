using UnityEngine;
using System.Collections;

[System.Serializable]
public class PieceOfGarbagePickUp : PickUp {

    public AudioSource PickupAudioSource;
    public AudioClip PickupClip;
    public GameManager gameManager;

    void Start()
    {
        var gameController = GameObject.FindWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
    }

    public override void Get()
    {
        base.Get();
        gameManager.RemoveGarbage();
        PickupAudioSource.clip = PickupClip;
        PickupAudioSource.Play();
    }
}
