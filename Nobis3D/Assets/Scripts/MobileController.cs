using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //события в игре

public class MobileController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private Image joystickBG;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector; //получение координат вектора

    private void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero; //возврат джостика в центр

    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform,
            ped.position,ped.pressEventCamera,out pos)) // сравнение угла отклонения между центром обьекта касания и местом касания
        {
            //изменение по осям относительно задника джостика
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);//получение координат позиции касания на джостик
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.y);//получение координат позиции касания на джостик

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);//установка точных координат из касания
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //движение для джойстика
            //изменение позиции якоря
            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    // обьединение джостика и клавиатуры
    public float Horizontal() 
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}
