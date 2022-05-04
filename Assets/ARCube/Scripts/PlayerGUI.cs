using System;
using ARCubeBlock;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private BlockSpawner blockSpawner;

    [SerializeField] private PlayerInventory playerInventory;

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            blockSpawner.StartFillField();
            playerInventory.Init(0.1f);
            PlayerInventory.OnScoreUpdate += UpdateScoreText;
            startButton.gameObject.SetActive(false);
        });

        restartButton.onClick.AddListener(() =>
        {
            blockSpawner.ResetFillField();
            playerInventory.ResetData();
        });
    }

    private void UpdateScoreText(int value)
    {
        scoreText.text = value.ToString();
    }
}