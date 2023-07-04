
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class FlashingText : MonoBehaviour
{
    public float flashInterval = 0.5f; // Time interval for text flashing
    public Color flashColor = Color.red; // Color to flash the text


    public TextMeshProUGUI textComponent;
    private Color originalColor;
    private bool isFlashing = false;

    

    private void Start()
    {
     

        // Store the original color of the text
        originalColor = textComponent.color;

        // Start the flashing coroutine
        StartCoroutine(FlashText());
    }

    private System.Collections.IEnumerator FlashText()
    {
        while (true)
        {
            // Toggle between the original color and the flash color
            textComponent.color = isFlashing ? originalColor : flashColor;
            isFlashing = !isFlashing;

            // Wait for the specified interval before flashing again
            yield return new WaitForSeconds(flashInterval);
        }
    }
 
}


