using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    Label ScoreText;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        this.ScoreText = root.Q<Label>("ScoreLabel");
        
        this.ScoreText.text = "Score: " + GameManager.Instance.GetPlayerScore().ToString();
    }

    private void FixedUpdate()
    {
        this.ScoreText.text = "Score: " + GameManager.Instance.GetPlayerScore().ToString();
    }
}
