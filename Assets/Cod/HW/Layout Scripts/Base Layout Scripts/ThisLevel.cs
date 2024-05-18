
using UnityEngine;
using UnityEngine.UI;


public class ThisLevel : MonoBehaviour
{
    private const int FirstLevelNumber = 1;
    public GameObject Ball;
    public GameObject NextLevel;
    public Button MenuButton;

    private int _levelNumber;
    private Text _textLevelNumber;
    private Text _textNextLevelNumber;
    private Active _active;
    
    void Start()
    {
        AddLinks();
        _levelNumber = FirstLevelNumber;
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

    private void AddLinks()
    {
        _active = Ball.GetComponent<Active>();
        _textLevelNumber = GetComponent<Text>();
        _textNextLevelNumber = NextLevel.GetComponent<Text>();
    }
}
