using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardManager : MonoBehaviour
{

    private List<float> curScoreBuffer = new List<float>();
    private List<float> lastScoreboard = new List<float>();
    private List<float> updatedScoreboard = new List<float>();


    [SerializeField] private List<NumberToImage> scoreTextFields = new List<NumberToImage>();

    private void Start()
    {
        FlyAnimation flyAnimation = GetComponent<FlyAnimation>();
        flyAnimation.PlayIntroAnimation();
        curScoreBuffer = GameManager.Instance.scoreBuffer;
        lastScoreboard = GameManager.Instance.scoreboard;
        foreach (float processedScore in curScoreBuffer)
        {
            if (CheckIfScoreboardHasEmptySlots())
            {
                SortScoreInScoreBoard(processedScore);
            }
            else
            {
                if (CheckIfProcessedScoreIsHigherThanLowestScore(processedScore))
                {
                    DeleteLowestScore();
                    SortScoreInScoreBoard(processedScore);
                }
            }

        }
        updatedScoreboard = lastScoreboard;
        SendUpdatedScoreBoardToGameManagerAndResetCurScore();
        PrintUpdatedScoreBoardToText();
    }

    private bool CheckIfProcessedScoreIsHigherThanLowestScore(float _processedScore)
    {
        lastScoreboard.Sort();
        if (_processedScore > lastScoreboard[0])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SendUpdatedScoreBoardToGameManagerAndResetCurScore()
    {
        GameManager.Instance.scoreBuffer.Clear();
        GameManager.Instance.scoreboard = updatedScoreboard;
    }

    private void PrintUpdatedScoreBoardToText()
    {
        updatedScoreboard.Sort();
        updatedScoreboard.Reverse();
        for (int i = 0; i < updatedScoreboard.Count; i++)
        {
            scoreTextFields[i].ConvertToImage((int)updatedScoreboard[i]);
        }
    }


    private void DeleteLowestScore()
    {
        lastScoreboard.Sort();
        lastScoreboard.RemoveAt(0);
    }

    private void SortScoreInScoreBoard(float _processedScore)
    {
        lastScoreboard.Add(_processedScore);
        lastScoreboard.Sort();
    }

    public bool CheckIfScoreboardHasEmptySlots()
    {
        if (lastScoreboard.Count < 10)
        {
            return true;
        }
        if (lastScoreboard.Count >= 10)
        {
            return false;
        }
        return true;
    }

    public void BackButton()
    {
        FlyAnimation flyAnimation = GetComponent<FlyAnimation>();
        flyAnimation.PlayOutroAnimation(0);
    }
}
