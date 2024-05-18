using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestResult : MonoBehaviour
{
    public GameObject Ball;
    
    private Text _record;
    private Active _platformСounter;

    void Start() //Достаём актив из мяча и текст из этого объекта
    {
        _platformСounter = Ball.GetComponent<Active>();
        _record = GetComponent<Text>();
    }

    void Update()
    {
        _recordChecker();
    }

    private void _recordChecker()
    {
        _record.text = $"best: {_platformСounter._maxPassedPlatforms.ToString()}";
    }
}