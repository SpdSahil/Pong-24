using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            if (!isPlayerGoal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().CompScored();
            }
        }
    }
}
