using UnityEngine.UI;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [Header("Шрифты")]
    [SerializeField] Font[] myFonts;
    private Text textFont; // шрифты
    private int fontCounter;

    [Header("Время")]
    float currentTime = 0f;
    float startingTime = 15f;
    [SerializeField] Text countdownText;



    private void Start()
    {
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
        if(currentTime <= 0)
        {
            currentTime = 0;
            Lose();
        }

    }

    void Lose()
    {
        print("You Lose!");
    }

    //void ChangeFont()
    //{
    //    //изменение шрифта
    //    fontCounter++;
    //    if (fontCounter > 1) fontCounter = 0;
    //    textFont.font = myFonts[fontCounter];
    //}
}
