using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    //основные параметры
    public float moveSpeed; //скорость движения

    //параметры геймплея
   
    private Vector3 moveVector; //вектор движения персонажа

    //Ссылки на компоненты
    private CharacterController ch_controller;
    private Animator ch_animator;
    private MobileController mContr;

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    private void Update()
    {
        CharacterMove();
    }

    //метод перемещения персонажа
    private void CharacterMove()
    {


            moveVector = Vector3.zero;
            /* moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;
             moveVector.z = Input.GetAxis("Vertical") * moveSpeed;*/
            moveVector.x = mContr.Horizontal() * moveSpeed;
            moveVector.z = mContr.Vertical() * moveSpeed;

            //анимация движения персонажа
            if (moveVector.x != 0 || moveVector.z != 0) ch_animator.SetBool("Move", true);
            else ch_animator.SetBool("Move", false);

            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, moveSpeed, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
       
        ch_controller.Move(moveVector * Time.deltaTime); //метод поредвижения по направлению
    }


}
