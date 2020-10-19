using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    private int level;
    private int totalScore;
    private int totalCountBox;
    private int totalCountCrash;
    private int totalMinusReputation;

    public int Level { get => level; set => level = value; }
    public int TotalScore { get => totalScore; set => totalScore = value; }
    public int TotalCountBox { get => totalCountBox; set => totalCountBox = value; }
    public int TotalCountCrash { get => totalCountCrash; set => totalCountCrash = value; }
    public int TotalMinusReputation { get => totalMinusReputation; set => totalMinusReputation = value; }

    void Start()
    {
        DontDestroyOnLoad(this);
        level = 1;
    }

    public int CalcScore()
    {
        TotalScore = (TotalCountBox * 10) - (TotalCountCrash * 5) + (600 + TotalMinusReputation);
        return TotalScore;
    }
    // Update is called once per frame
    public void LevelUp()
    {
        level+=1;
    }

}
