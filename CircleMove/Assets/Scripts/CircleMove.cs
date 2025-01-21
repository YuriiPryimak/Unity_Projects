using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// В данному проєкті відбувається переміщення об'єкту через кліки мишки по екрану,
/// а також присутній слайдер для регулювання швидкості.
/// </summary>
public class CircleMove : MonoBehaviour
{

    public Slider _speedSlider;

    private Queue<Vector3> _position = new Queue<Vector3>();

    private Vector3 _currentPosition;

    private bool isMoving = false;


    /// <summary>
    /// Метод Update постійно оновлює рух об'єкта відносно слайдера
    /// також додає нові позиції
    /// </summary>
    void Update()
    {

        /* Оновлює + встановлює поточне значення(швидкість) слайдера */
        float speed = _speedSlider.value;


        /* Умова на додання нової цілі */
        if (Input.GetMouseButtonDown(0))
        {
            AddNewPosition();
        }

        /* Викликається метод руху до цілі */
        if (isMoving)
        {
            Movement(speed);
        }

        /* Якщо рух не відбувається, перевіряємо чи є нові цілі */
        else if (_position.Count > 0)
        {
            SetNextPosition();
        }
    }

    /// <summary>
    /// Додавання нової позицію до черги
    /// </summary>
    void AddNewPosition()
    {
        Vector3 _newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _newPosition.z = transform.position.z;
        _position.Enqueue(_newPosition);
    }

    /// <summary>
    /// Встановлення наступної цілі, як поточної
    /// </summary>
    void SetNextPosition()
    {
        if (_position.Count > 0)
        {
            _currentPosition = _position.Dequeue();
            isMoving = true; 
        }
    }

    void Movement(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPosition,
                                                 speed * Time.deltaTime);

        /* При досягнені цілі, рух зупиняється*/
        if(Vector3.Distance(transform.position, _currentPosition) < 0.01f)
        { 
            isMoving = false;

        }
    }
}
