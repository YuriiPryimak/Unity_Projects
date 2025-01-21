using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// � ������� ����� ���������� ���������� ��'���� ����� ���� ����� �� ������,
/// � ����� �������� ������� ��� ����������� ��������.
/// </summary>
public class CircleMove : MonoBehaviour
{

    public Slider _speedSlider;

    private Queue<Vector3> _position = new Queue<Vector3>();

    private Vector3 _currentPosition;

    private bool isMoving = false;


    /// <summary>
    /// ����� Update ������� ������� ��� ��'���� ������� ��������
    /// ����� ���� ��� �������
    /// </summary>
    void Update()
    {

        /* ������� + ���������� ������� ��������(��������) �������� */
        float speed = _speedSlider.value;


        /* ����� �� ������� ���� ��� */
        if (Input.GetMouseButtonDown(0))
        {
            AddNewPosition();
        }

        /* ����������� ����� ���� �� ��� */
        if (isMoving)
        {
            Movement(speed);
        }

        /* ���� ��� �� ����������, ���������� �� � ��� ��� */
        else if (_position.Count > 0)
        {
            SetNextPosition();
        }
    }

    /// <summary>
    /// ��������� ���� ������� �� �����
    /// </summary>
    void AddNewPosition()
    {
        Vector3 _newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _newPosition.z = transform.position.z;
        _position.Enqueue(_newPosition);
    }

    /// <summary>
    /// ������������ �������� ���, �� �������
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

        /* ��� �������� ���, ��� �����������*/
        if(Vector3.Distance(transform.position, _currentPosition) < 0.01f)
        { 
            isMoving = false;

        }
    }
}
