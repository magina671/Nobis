using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    //основные настройки
    public float speedMove;
    private Vector3 moveVector;//направение движение персонажа
    private CharacterController player_controller;
    private MobileController mContr;

    private void Start()
    {
        player_controller = GetComponent<CharacterController>();
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    private void Update()
    {
        //if (!isLocalPlayer)
        //    return;

        CharacterMove();
    }

    private void CharacterMove()
    {
        moveVector = Vector3.zero; //обнуление во избежание ошибок
        moveVector.x = mContr.Horizontal() * speedMove;
        moveVector.z = mContr.Vertical() * speedMove;

        //поворот персонажа в сторону направления перемещения
        if (Vector3.Angle(Vector3.forward,moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        player_controller.Move(moveVector * Time.deltaTime); //метод передвижения по направлению
    }
}
