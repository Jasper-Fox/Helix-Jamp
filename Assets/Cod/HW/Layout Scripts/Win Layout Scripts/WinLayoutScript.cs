
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
        AddLinks();
    }

    void Update()
    {
        _levlePassed.text = $"Level {_active._levelNumber} passed";
    }

    private void AddLinks()
    {
        _active = Ball.GetComponent<Active>();
        _levlePassed = LevlePassed.GetComponent<Text>();
    }
}