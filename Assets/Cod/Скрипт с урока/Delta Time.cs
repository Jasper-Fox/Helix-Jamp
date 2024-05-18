using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeltaTime : MonoBehaviour
{
    public Text TimeText;
    public Text KlickTimesText;
    public Button Button;

    private int _klickTimes;
    private float _secundes;
    private int _minutes;

    private void Start()
    {
        Button.onClick.AddListener(_klickT); //если нажать кнопку то выполнится функция
    }

    void Update()
    {
        _stopwatch();

        _numbOfKlick();
    }

    private void _klickT() //счетчик кликов
    {
        _klickTimes++;
    }

    private void _numbOfKlick() //отображение чиса кликов
    {
        if (_klickTimes == 0)
            KlickTimesText.text = "Tap";
        else
        {
            KlickTimesText.text = _klickTimes.ToString();
        }
    }

    private void _stopwatch() //секундомер
    {
        _secundes = Time.time % 60; //секнды - множество остатков от деления на 60 
        if (_secundes >= 59) //чтобы не показывал 60 секунд
            _secundes = 59;
        _minutes = (int)Time.time / 60; //минута это каждая 60тая секунда

        if (Time.time < 1f) //в самом начале отсчета 2 значения милисекунд
            TimeText.text = _minutes.ToString("F0") + ":" + _secundes.ToString("F2");
        else if (_secundes < 9.9 && Time.time < 59) //вначале отсчета при однозначных секундах 1 значение милисекунд
            TimeText.text = _minutes.ToString("F0") + ":0" + _secundes.ToString("F1");
        else if (_secundes < 9.5) //когда секунды однозначные но уже есть минуты не показываем милисекунды
            TimeText.text = _minutes.ToString("F0") + ":0" + _secundes.ToString("F0");
        else //когда секунды двузначные и не началоотсчета не показываем милисекунды
            TimeText.text = _minutes.ToString("F0") + ":" + _secundes.ToString("F0");
    }
}