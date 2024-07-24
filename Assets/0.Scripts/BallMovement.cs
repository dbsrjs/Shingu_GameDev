using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;    //���� �ӵ�
    public int verticalDirection = 1;   //����
    public int horizontalDirection = 1; //�¿�
    public Rigidbody2D rigid;   //��ü�� ���� ������ ���� Rigidbody2D

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 2); //���� ���� randomNumber�� 0 ~ 1 ������ ���� ���� ����

        if(randomNumber == 0)   //randomNumber�� 0�� ��
        {
            horizontalDirection = 1;        //���� ������ ���������� ����
        }
        else
        {
            horizontalDirection = 0;        //���� ������ �������� ����
        }

        verticalDirection = 1;              //���� ���� ������ �Ʒ��� ����

        //���� �ӵ��� ����
        rigid.velocity = new Vector2(speed * horizontalDirection, speed * verticalDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall") //���� �浹�� ��ü�� tag�� "Wall"�̶��
        {
            verticalDirection *= -1;            //���� ���� ����
        }
        if(collision.transform.tag == "Player") //���� �浹�� ��ü�� tag�� "Player"�̶��
        {
            horizontalDirection *= -1;          //�¿� ���� ȸ��
        }

        //���� �ӵ��� ����
        rigid.velocity = new Vector2(speed * horizontalDirection, speed * verticalDirection);
    }
}
