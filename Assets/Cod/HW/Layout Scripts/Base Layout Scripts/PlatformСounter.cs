
using UnityEngine;
using UnityEngine.UI;

public class PlatformСounter : MonoBehaviour
{
    public GameObject Ball;
    
    private Text _passedPlatforms;
    private Active _active;

    void Start() //Достаём актив из мяча и текст из объекта с этим скриптом
    {
        _active = Ball.GetComponent<Active>();
        _passedPlatforms = GetComponent<Text>();
    }

    void Update() //записывапем в текст этого объекта значние из мяча
    {
        _passedPlatforms.text = _active._passedPlatforms.ToString();
    }
}