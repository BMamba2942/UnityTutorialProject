using UnityEngine;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
   public Button tryAgainButton;

   void Start() {
       tryAgainButton.onClick.AddListener(() => {
           FindObjectOfType<GameManager>().Restart();
       });
   }
}