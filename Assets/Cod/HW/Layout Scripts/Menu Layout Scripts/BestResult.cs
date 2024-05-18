
using UnityEngine;
using UnityEngine.UI;

public class BestResult : MonoBehaviour
{
    public GameObject Ball;
    
    private Text _record;
    private Active _platformСounter;

    void Start() //Достаём актив из мяча и текст из этого объекта
    {
        AddLinks();
    }

    void Update()
    {
        _recordChecker();
    }

    private void _recordChecker()
    {
        _record.text = $"best: {_platformСounter._maxPassedPlatforms.ToString()}";
    }

    private void AddLinks()
    {
        _platformСounter = Ball.GetComponent<Active>();
        _record = GetComponent<Text>();
    }
}