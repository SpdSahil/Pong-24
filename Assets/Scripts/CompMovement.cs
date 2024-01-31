using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    [SerializeField] private float compSpeed = 5;
    [SerializeField] private float compRunSpeed = 9;
    [SerializeField] private GameObject ball;
    private Vector2 movePosition;
    public bool isPlayer2 = false;

    private Vector2 top = new Vector2(-7.5f, 3.41f);
    private Vector2 bottom = new Vector2(-7.5f, -3.41f);

    public void IsPlayer()
    {
        isPlayer2 = true;
    }

    public void IsComp()
    {
        isPlayer2 = false;
    }

    private void Update()
    {
        if (!isPlayer2)
        {
            if (ball.transform.position.x <= 0)
            {
                if(ball.transform.position.x < -7.6)
                {
                    if (ball.transform.position.y > 0)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, bottom, compSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = Vector2.MoveTowards(transform.position, top, compSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    movePosition = new Vector2(transform.position.x, ball.transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, movePosition, compSpeed * Time.deltaTime);
                }
                
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
        
    }
}
