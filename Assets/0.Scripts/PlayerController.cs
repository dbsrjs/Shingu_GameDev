using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 3.6)
        {
            transform.position = new Vector2(transform.position.x, 3);
        }

        if (transform.position.y <= -1.6)
        {
            transform.position = new Vector2(transform.position.x, -1);
        }

        if (Input.GetKey(KeyCode.UpArrow))   //���� ȭ��ǥ�� ������ ���� ��
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);//������Ʈ�� ��ġ�� ���� ��ġ���� �� �������� speed ��ŭ �̵���.
        }

        if (Input.GetKey(KeyCode.DownArrow))   //�Ʒ��� ȭ��ǥ�� ������ ���� ��
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);//������Ʈ�� ��ġ�� ���� ��ġ���� �Ʒ� �������� speed ��ŭ �̵���.
        }
    }
}
