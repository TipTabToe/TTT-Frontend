using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Shows the scores after game
public class ScoreSceneScript : MonoBehaviour {

    public TMP_Text heading;
    public TMP_Text points;
    public TMP_Text opponentPoints;
    public TMP_Text category;
    public Image icon;
    public Sprite winnerIcon;
    public Sprite loserIcon;
    public int playerScore;
    public int opponentScore;
    
    // Checks  who won and changes texts accordingly
    void Start() {
        showCategory();
        computerPoints();
        playerScore = GlobalClass.lastRoundPoints;
        if (playerScore > opponentScore) {
            heading.SetText("You won!");
            icon.sprite = winnerIcon;
        }
        else if (playerScore == opponentScore) {
            heading.SetText("It's a tie!");
            icon.sprite = winnerIcon;
        }
        else {
            heading.SetText("You lost!");
            icon.sprite = loserIcon;
        }
        
        points.SetText(playerScore.ToString());
        opponentPoints.SetText(opponentScore.ToString());
    }

    // Shows which category was played
    public void showCategory() {
        int categoryId = GlobalClass.category;

        if (categoryId == 1) {
            category.SetText("Consumption");
        } else if (categoryId == 2) {
            category.SetText("Transportation");
        } else if (categoryId == 3) {
            category.SetText("Food");
        } else if (categoryId == 4) {
            category.SetText("Waste");
        }
    }

    // Starts new game
    public void PlayAgain() {
        SceneLoader.Load(SceneLoader.Scene.CreateGame);
    }
    
    // Goes back to MainMenu
    public void BackToMainMenu() {
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }

    // Randomizes points for computer
    public void computerPoints() {
        for (int i = 0; i < 5; i++) {
            float random = Random.value;
            if (random < 0.5) {
                opponentScore++;
            }
        }
    }
}