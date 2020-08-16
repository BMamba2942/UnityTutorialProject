using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public bool gameStarted = false;
    public Canvas scoreCanvas;
    public Canvas gameOverCanvas;
    public Canvas startCanvas;
    public void EndGame() {
        if (!gameHasEnded) {
            gameHasEnded = true;
            scoreCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            var texts = FindObjectsOfType<Text>();
            var scText = GetTextComponentByName(texts, "ScoreCanvasScoreText");
            var goText = GetTextComponentByName(texts, "GameOverCanvasScoreText");
            goText.text = string.Format("Score: {0}", scText.text);
        }
    }

    private Text GetTextComponentByName(Text[] texts, string name) {
        IEnumerable<Text> query = from text in texts where text.name == name select text;
        return query.First();
    }

    public void StartGame() {
        scoreCanvas.enabled = true;
        gameStarted = true;
        startCanvas.enabled = false;
    }

    public void Restart() {
        // gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
