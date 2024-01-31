using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isPlaying = false;
    [SerializeField] private AudioSource SFXPlayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private AudioClip paddleHit;
    [SerializeField] private AudioClip wallHit;
    private Vector2 minSpeed = new Vector2 (3, 3);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //InitiateBall();
    }

    private void Update()
    {
        if (rb.velocity == minSpeed)
        {
            rb.velocity = Vector2.zero;
            InitiateBall();
        }
        if(rb.velocity == Vector2.zero && isPlaying)
        {
            rb.velocity = Vector2.zero;
            InitiateBall();
        }
    }

    public void InitiateBall()
    {
        StartCoroutine(Delay());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PlayerHandle" || collision.gameObject.name == "CompHandle")
        {
            SFXPlayer.PlayOneShot(paddleHit);
        }
        else
        {
            SFXPlayer.PlayOneShot(wallHit);
        }
    }

    IEnumerator Delay()
    {
        int seconds = 2;
        yield return new WaitForSeconds(seconds);
        

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(speed * x, speed * y);
        isPlaying = true;
    }
}
