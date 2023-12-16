using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathMenuManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTextField;
    void Start()
    {
        scoreTextField.text = GameManager.Instance.GetPlayerScore().ToString();
        GameManager.Instance.ResetPlayerScore();
    }
}
