using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BirdScriptable bird;
    public SpriteRenderer spriteRenderer;
    public float strength = 5f;
    public float gravity = -9.81f;
    private Vector3 direction;
    public float tilt = 5f;
    public AudioSource dieSound;
    public AudioSource scoreSound;
    public AudioSource wingSound;

    private Rigidbody2D _rb;

    // //delegate()
    // public delegate void Scoring();

    // //event
    // public static event Scoring ScoreUp;

    private void OnEnable()
    {
        bird = GameSingleton.instance.getBird();
        Debug.Log(bird.name);
        spriteRenderer.sprite = bird.sprite;
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            wingSound.Play();
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameSingleton.instance.GameOver();
            dieSound.Play();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            GameSingleton.instance.IncreaseScore();
            scoreSound.Play();
            // OnScoring();
        }
    }

    // public void OnScoring()
    // {
    //     ScoreUp();
    // }

    public void ResetPlayer()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
}
