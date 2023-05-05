using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public int lastWeight { get; set; }
    public int endingNum { get; set; }
    public static EndingManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public void JudgeEnding()
    {
        lastWeight = GameDataManager.Instance.weight;
        int fatherValue = GameDataManager.Instance.fatherValue;
        int bridgeValue = GameDataManager.Instance.bridgeValue;
        int hikoValue = GameDataManager.Instance.hikoValue;
        //告りに行けるか
        int temp_notConfessProb = 100 - fatherValue*25;
        if(Probability(temp_notConfessProb))
        {
            endingNum = 0;
            Debug.Log(endingNum);
            return;
        }
        //橋が崩れるか
        float bridgeStr = 2.5f*bridgeValue+50;
        if(bridgeValue == 0)
        {
            endingNum = 1;
            Debug.Log(endingNum);
            return;
        }
        else if(lastWeight > bridgeStr)
        {
            endingNum = 1;
            Debug.Log(endingNum);
            return;
        }
        //フラれるかどうか
        int fabRating = hikoValue + lastWeight/10;//好感度と体重
        Debug.Log(fabRating);
        if(fabRating < 40)
        {
            endingNum = 2;
            Debug.Log(endingNum);
            return;
        }
        endingNum = 3;
        Debug.Log(endingNum);
    }
    public static bool Probability(float fPercent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if(fPercent == 100.0f && fProbabilityRate == fPercent)
        {
            return true;
        }
        else if (fProbabilityRate < fPercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
