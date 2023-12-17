using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTextField;
    void Start()
    {
        //scoreTextField.text = GameManager.Instance.GetPlayerScore().ToString();
        //GameManager.Instance.ResetPlayerScore();
    }

    public void BackButton()
    {
        GameManager.Instance.ResetPlayerScore();
        SceneManager.LoadScene(0);
    }
}
