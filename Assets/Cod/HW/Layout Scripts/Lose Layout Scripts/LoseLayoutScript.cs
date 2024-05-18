using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseLayoutScript : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Completed;
    public GameObject NewRecord;
    public GameObject ProcessBar;

    private Text _completed;
    private Text _newRecord;
    private Active _active;
    private Slider _slider;

    void Start()//Достаём всё отовсютду
    {
        _active = Ball.GetComponent<Active>();
        _newRecord = NewRecord.GetComponent<Text>();
        _slider = ProcessBar.GetComponent<Slider>();
        _completed = Completed.GetComponent<Text>();
    }

    void Update()
    {
        CompletedProcent();
        NewRecordShow();
    }
    

    private void CompletedProcent() //пройденный процент уровня
    {
        _completed.text = $"{(int)(_slider.value * 100)}% Completed!";
    }

    private void NewRecordShow() //если был новый рекорд, то показывает его,
                                 //если небыло - не показывает
    {
        if (_active._newRecordBool)
        {
            NewRecord.gameObject.SetActive(true);
            _newRecord.text = $"NEW RECORD!\n{_active._maxPassedPlatforms}";
        }
        else
        {
            NewRecord.gameObject.SetActive(false);
        }

    }
}