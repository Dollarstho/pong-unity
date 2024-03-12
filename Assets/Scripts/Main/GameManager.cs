using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform player1Paddle;
    public Transform player2Paddle;

    public BallController ballController;

    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshProUGUI textPointPlayer1;
    public TextMeshProUGUI textPointPlayer2;

    public int winPoints = 5;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;


    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        player1Paddle.position = new Vector3(-7f, 0f, 0f);
        player2Paddle.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        player1Score = 0;
        player2Score = 0;

        textPointPlayer2.text = player2Score.ToString();
        textPointPlayer1.text = player1Score.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer1()
    {
        player1Score++;
        textPointPlayer1.text = player1Score.ToString();
        CheckWin();
    }

    public void ScorePlayer2()
    {
        player2Score++;
        textPointPlayer2.text = player2Score.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (player2Score >= winPoints || player1Score >= winPoints)
        {
             int finalPlayer1Score = player1Score;
             int finalPlayer2Score = player2Score;
            ResetGame();
            EndGame(finalPlayer1Score, finalPlayer2Score);
        }
    }

    public void EndGame(int player1Score, int player2Score)
    {
        screenEndGame.SetActive(true);
        PlayerWin(player1Score, player2Score);
        string winner = SaveController.Instance.GetName(player1Score > player2Score);
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void PlayerWin(int player1Score, int player2Score)
    {
         if (player1Score > player2Score)
        {
            textEndGame.text = "Vitória do Jogador: " + SaveController.Instance.GetName(true);
        }
        else
        {
            textEndGame.text = "Vitória do Jogador: " + SaveController.Instance.GetName(false);
        }
    }


}
