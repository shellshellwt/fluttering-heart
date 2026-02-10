using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public CanvasScaler scaler;
    // Start is called before the first frame update
    void Start()
    {
        AdjustScale();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustScale();
    }

    void AdjustScale()
    {
        float baseWidth = 1080f;
        float currentWidth = Screen.width;
        float scale = currentWidth / baseWidth;
        scaler.scaleFactor = scale;
    }
}
