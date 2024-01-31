using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] private GameObject ball;

    [Header("Player")]
    [SerializeField] private GameObject playerHandle;
    [SerializeField] private GameObject playerBoundary;

    [Header("Comp")]
    [SerializeField] private GameObject compHandle;
    [SerializeField] private GameObject compBoundary;

    [Header("Score UI")]
    [SerializeField] private GameObject playerText;
    [SerializeField] private GameObject compText;

    [Header("Win UI")]
    [SerializeField] private GameObject player1WinUI;
    [SerializeField] private GameObject compWinUI;
    [SerializeField] private GameObject player2WinUI;

    private int playerScore;
    private int compScore;

    public void PlayerScored()
    {
        playerScore++;
        playerText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
        checkScore();
    }

    public void CompScored()
    {
        compScore++;
        compText.GetComponent<TextMeshProUGUI>().text = compScore.ToString();
        checkScore();
    }

    private void checkScore()
    {
        if(playerScore >= 24)
        {
            playerWin();
        }
        else if(compScore >= 24)
        {
            compWin();
        }
    }

    private void playerWin()
    {
        ball.SetActive(false);
        compHandle.SetActive(false);
        player1WinUI.SetActive(true);
    }

    private void compWin()
    {
        if (compHandle.GetComponent<CompMovement>().isPlayer2 == true)
        {
            ball.SetActive(false);
            playerHandle.SetActive(false);
            player2WinUI.SetActive(true);
        }
        else
        {
            ball.SetActive(false);
            playerHandle.SetActive(false);
            compWinUI.SetActive(true);
        }
    }
}
