using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThisLevel : MonoBehaviour
{
    public GameObject Ball;
    public GameObject NextLevel;
    public Button MenuButton;

    private int _levelNumber;
    private Text _textLevelNumber;
    private Text _textNextLevelNumber;
    private Active _active;
    
    void Start()
    {
        _active = Ball.GetComponent<Active>();
        _textLevelNumber = GetComponent<Text>();
        _textNextLevelNumber = NextLevel.GetComponent<Text>();
        _levelNumber = 1;
        
        MenuButton.onClick.AddListener(_klickMenuButton);  
    }

    void Update()
    {
        _textLevelNumber.text = _levelNumber.ToString();
        _textNextLevelNumber.text = (_levelNumber + 1).ToString();
    }

    private void _klickMenuButton()
    {
        if (_active._wasFinish)
        {
            _levelNumber++;
            _active._wasFinish = false;    
        }
    }
}
