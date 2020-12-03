using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneScript : MonoBehaviour {

    public TMP_Text heading;
    public TMP_Text points;
    public TMP_Text opponentPoints;
    public Image icon;
    public Sprite winnerIcon;
    public Sprite loserIcon;
    public int playerScore;
    public int opponentScore;
    
    void Start() {
        computerPoints();
        playerScore = GlobalClass.player.points;
        if (playerScore > opponentScore) {
            heading.SetText("You won!");
            icon.sprite = winnerIcon;
        }
        else {
            heading.SetText("You lost!");
            icon.sprite = loserIcon;
        }
        
        points.SetText(playerScore.ToString());
        opponentPoints.SetText(opponentScore.ToString());
    }

    public void ContinueClicked() {
        SceneLoader.Load(SceneLoader.Scene.PlayMenu);
    }

    public void computerPoints() {
        for (int i = 0; i < 5; i++) {
            float random = Random.value;
            if (random < 0.5) {
                opponentScore++;
            }
        }
    }
}