using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour
{
    public readonly Color O_range = new(1, 0.522145f, 0);
    public readonly Color G_ray = new(0.4f, 0.4f, 0.4f);

    public GameObject MenuLayout;
    public GameObject WinLayout;
    public GameObject LoseLayout;
    public GameObject Ball;
    public Slider ProcessBar;
    public Button MenuButton;
    public Button PlayButton;
    public Image NextLavelColor;

    private Active _active;
    private Vector3 _startPosition;

    void Start()
    {
        AddLinks();
        _active.ChangedKinematic(true); //делаем его статичным

        _startPosition = _active._startPosition; //запоминаем начальную позицию мячика

        OnClickFunctions();

        DisablingLayouts();

        NextLavelColor.color = G_ray; //устанавливаем кружечек левелбара в серый
    }

    private void Update()
    {
        _eventWin();
        _eventLose();
        _porcessBarValue();
    }

    private void _klickMenuButton() //само нажатие переводящее в меню
    {
        WinLayout.gameObject.SetActive(false);
        LoseLayout.gameObject.SetActive(false);

        NextLavelColor.color = G_ray;

        MenuLayout.gameObject.SetActive(true);
        Ball.transform.position = _startPosition;

        ProcessBar.value = 0;

        _active._passedPlatforms = 0;
        _active._newRecordBool = false;

        _active._wasFinish = false;

        MenuButton.gameObject.SetActive(false);
    }

    private void _klickPlayButton() //нажатие для начала игры
    {
        MenuLayout.gameObject.SetActive(false);

        _active.ChangedKinematic(false);
    }

    private void _eventWin() //если произошло касание финиша 
    {
        if (_active._finish)
        {
            WinLayout.gameObject.SetActive(true);
            MenuButton.gameObject.SetActive(true);

            NextLavelColor.color = O_range;

            _active._levelNumber++;

            _active._maxPassedPlatforms = 0;

            _active._finish = false;

            _active.ChangedKinematic(true);
        }
    }

    private void _eventLose() //соответственно с киллзоной
    {
        if (_active._lose)
        {
            LoseLayout.gameObject.SetActive(true);
            MenuButton.gameObject.SetActive(true);

            _active._lose = false;

            _active.ChangedKinematic(true);
        }
    }

    private void _porcessBarValue()//значение полосочки сверху
    {
        float LastProcessBarValue = ProcessBar.value; //Сложности для того, чтобы когла шарик скачет,
                                                      //полосочка не скакала вместе с ним
        float Value = 1 - Ball.transform.position.y / _startPosition.y;;
        if (LastProcessBarValue <= Value)
            ProcessBar.value =  Value; 
    }

    private void AddLinks()
    {
        _active = Ball.GetComponent<Active>(); //верём ссылку на компонент актив у мячика
    }

    private void OnClickFunctions()
    {
        MenuButton.onClick.AddListener(_klickMenuButton); //некий синтаксис для нажатия по меню
        PlayButton.onClick.AddListener(_klickPlayButton); //некий синтаксис для нажатия по кнопке плей
    }

    private void DisablingLayouts()
    {
        WinLayout.gameObject.SetActive(false); //отключаем все лэйауты
        LoseLayout.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);
    }
}