using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    Text ScoreText;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        //this.ScoreText = root.Q<Text>("ScoreLabel");
        
        this.ScoreText.text = "Score: " + GameManager.Instance.GetPlayerScore();
    }

    private void FixedUpdate()
    {
        this.ScoreText.text = "Score: " + GameManager.Instance.GetPlayerScore();
    }
}
