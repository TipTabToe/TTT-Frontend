using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSceneScript : MonoBehaviour {

    public TMP_Text heading;
    public TMP_Text points;
    public TMP_Text opponentPoints;
    public int playerScore;
    public int opponentScore;
    
    void Start() {
        computerPoints();
        if (playerScore > opponentScore) {
            heading.SetText("You won!");
        }
        else {
            heading.SetText("You lost!");
        }
        
        // points.SetText(playerScore.ToString() + " points");
        points.SetText(GlobalClass.player.points.ToString() + " points");
        opponentPoints.SetText(opponentScore.ToString() + " points");
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