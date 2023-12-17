using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    private void FixedUpdate()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetPlayerScore().ToString();
    }
}
