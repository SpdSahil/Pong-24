using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 7;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
