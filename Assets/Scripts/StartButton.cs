using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton;
    void Start() {
        startButton.onClick.AddListener(() => {
            FindObjectOfType<GameManager>().StartGame();
        });
    }
}
