using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public int hp = 3;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip annoyingSound;
    [SerializeField] private GameController gameController;
    AudioSource audioSource;

    public enum State
    {
        Calm,
        Alert,
        Scared
    }
    public State emotionalState;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    

    void Update()
    {
        if(emotionalState == State.Alert)
        {
            audioSource.clip = annoyingSound;
            audioSource.Play();

        }
        if(emotionalState == State.Scared)
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0);
            transform.position += transform.forward * 4 * Time.deltaTime;
            audioSource.clip = hitSound;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            emotionalState = State.Alert;
        }

        if(other.gameObject.tag == "Soap")
        {
            TakeDamage();
            emotionalState = State.Scared;
        }
    }


    void TakeDamage()
    {
        hp--;
        transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
        if(hp <= 0)
        {
            gameController.slimeCount--;
            Destroy(gameObject);
        }
    }

}
