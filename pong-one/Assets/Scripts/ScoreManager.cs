using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    public int scorePlayer1 = 0; // Score for Player 1
    public int scorePlayer2 = 0; // Score for Player 2
    public int winningScore = 11; // Score required to win the game

    public TMP_Text leftScoreText;
    public TMP_Text rightScoreText;
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    // Call this function when player 1 scores
    public void ScorePointPlayer1()
    {
        scorePlayer1++;
        leftScoreText.text = "" + scorePlayer1;
        
        Debug.Log("Player 1 scored! Current score: " + scorePlayer1);
        
        PostScore();
    }

    // Call this function when player 2 scores
    public void ScorePointPlayer2()
    {
        scorePlayer2++;
        rightScoreText.text = "" + scorePlayer2;

        Debug.Log("Player 2 scored! Current score: " + scorePlayer2);
        
        PostScore();
    }

    private void PostScore()
    {
        GameManager.Instance.ResetBall();
        CheckWinCondition();

    }

    // Check if either player has reached the winning score
    private void CheckWinCondition()
    {
        if (scorePlayer1 >= winningScore)
        {
            Debug.Log("Player 1 wins!");
            // TODO: Implement what happens when Player 1 wins
        }

        if (scorePlayer2 >= winningScore)
        {
            Debug.Log("Player 2 wins!");
            // TODO: Implement what happens when Player 2 wins
        }
    }
}