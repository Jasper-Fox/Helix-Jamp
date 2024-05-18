using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class WinLayoutScript : MonoBehaviour
{
    public GameObject Ball;
    public GameObject LevlePassed;

    private Text _levlePassed;
    private Active _active;

    void Start()
    {
        _active = Ball.GetComponent<Active>();
        _levlePassed = LevlePassed.GetComponent<Text>();
    }

    void Update()
    {
        _levlePassed.text = $"Levle {_active._levelNumber} passed";
    }
}