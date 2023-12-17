using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberToImage : MonoBehaviour
{
    private int ScoreNumber;
    private List<int> SingleDigits = new List<int>();
    [SerializeField] private GameObject NumberImagePrefab;
    
    [SerializeField] private List<Sprite> NumberTextures = new List<Sprite>();

    private void OnEnable()
    {
        SetScoreNumber();
    }

    public void SetScoreNumber()
    {
        this.ScoreNumber = GameManager.Instance.GetPlayerScore();

        FillSingleDigits();
    }
    
    private void FillSingleDigits()
    {
        this.SingleDigits.Clear();
        
        int tempScoreNumber = this.ScoreNumber;
        while (tempScoreNumber > 0)
        {
            this.SingleDigits.Add(tempScoreNumber % 10);
            tempScoreNumber /= 10;
        }
        
        SpawnNumberImages();
    }
    
    private void SpawnNumberImages()
    {
        Vector2 offset = new Vector2(400, -300);
        Vector2 offsetStep = new Vector2(-150, 0);
        
        for (int i = 0; i < this.SingleDigits.Count; i++)
        {
            GameObject numberImage = Instantiate(this.NumberImagePrefab, transform);
            numberImage.transform.localPosition = offset + offsetStep * i;

            if (this.SingleDigits[i] == 0)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[0];
            }
            else if (this.SingleDigits[i] == 1)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[1];
            }
            else if (this.SingleDigits[i] == 2)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[2];
            }
            else if (this.SingleDigits[i] == 3)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[3];
            }
            else if (this.SingleDigits[i] == 4)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[4];
            }
            else if (this.SingleDigits[i] == 5)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[5];
            }
            else if (this.SingleDigits[i] == 6)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[6];
            }
            else if (this.SingleDigits[i] == 7)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[7];
            }
            else if (this.SingleDigits[i] == 8)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[8];
            }
            else if (this.SingleDigits[i] == 9)
            {
                numberImage.GetComponent<UnityEngine.UI.Image>().sprite = this.NumberTextures[9];
            }
        }
    }
    
    
}
