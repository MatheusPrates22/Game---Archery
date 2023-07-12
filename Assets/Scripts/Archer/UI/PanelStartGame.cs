using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelStartGame : MonoBehaviour
{
    
    [SerializeField] private Button startGameButton;
    

    private void OnEnable() {
        startGameButton.onClick.AddListener(startGameButton_OnClick);
    }

    private void startGameButton_OnClick()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Round 01");
    }
}
