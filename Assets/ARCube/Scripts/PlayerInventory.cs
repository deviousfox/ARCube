using System;
using ARCubeBlock;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static Action<int> OnScoreUpdate;
    private int currentScore;


    public void ResetData()
    {
        currentScore = 0;
        OnScoreUpdate?.Invoke(currentScore);
    }

    public void Init(float delay)
    {
        Invoke(nameof(Init), delay);
    }

    public void Init()
    {
        BlockComponent.OnCubeCollect += AddScore;
        currentScore = 0;
        OnScoreUpdate?.Invoke(currentScore);
    }

    public void AddScore(int amount)
    {
        currentScore += Mathf.Abs(amount);
        OnScoreUpdate?.Invoke(currentScore);
    }
}