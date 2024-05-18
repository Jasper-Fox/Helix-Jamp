using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
    public Button MenuButton;
    public Material _material;
    private Vector3 _vector3;
    
    void Start()
    {
        _material.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1);

        MenuButton.onClick.AddListener(ColorChager);
    }

    private void ColorChager()
    {
        _material.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1);
    }
}
