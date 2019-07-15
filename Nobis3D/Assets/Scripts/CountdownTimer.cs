using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public GameObject winMenuUI;

    [Header("Шрифты")]
    [SerializeField] Font[] myFonts;
    private Text textFont; // шрифты
    private int fontCounter;

    [Header("Время")]
    float currentTime = 0f;
    float startingTime = 15f;
    [SerializeField] Text countdownText;

    public float enemySpeed;
    public float stoppingDistance = 1f;
    private Transform target;

    private void Awake()
    {
        winMenuUI.SetActive(false);
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //изменение таймера
        currentTime = startingTime;

        //изменение шрифта
        textFont = GetComponent<Text>();
        fontCounter = 0;
        textFont.font = myFonts[fontCounter];
    }
    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        //изменение цвета при падении таймера меньше опеделенного значения
        if ( currentTime <= 10)
        {
            countdownText.color = Color.red;
            //ChangeFont();
            textFont.font = myFonts[1];
        }

        //не уходить за ноль:
        if (currentTime <= 0)
        {
            currentTime = 0;
            Win();
        }
        //else if (Vector3.Distance(transform.position, target.position) > stoppingDistance) // баг тут надо пофиксить
        //{
        //    Lose();
        //}
    }

  
    void Lose()
    {
        Debug.Log("You Lose!");
    }

    void Win()
    {
        Debug.Log("You Win!");
        winMenuUI.SetActive(true); //активация паузы
    }
    //void ChangeFont()
    //{
    //    //изменение шрифта
    //    fontCounter++;
    //    if (fontCounter > 1) fontCounter = 0;
    //    textFont.font = myFonts[fontCounter];
    //}
}
