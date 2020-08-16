using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    void Update() {
        fpsText.text = string.Format("FPS: {0}", (1f / Time.smoothDeltaTime).ToString("0"));
    }
}
