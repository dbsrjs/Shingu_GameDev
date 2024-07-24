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

        if (Input.GetKey(KeyCode.UpArrow))   //위쪽 화살표를 누르고 있을 때
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);//오브젝트의 위치를 현재 위치에서 위 방향으로 speed 만큼 이동함.
        }

        if (Input.GetKey(KeyCode.DownArrow))   //아래쪽 화살표를 누르고 있을 때
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);//오브젝트의 위치를 현재 위치에서 아래 방향으로 speed 만큼 이동함.
        }
    }
}
