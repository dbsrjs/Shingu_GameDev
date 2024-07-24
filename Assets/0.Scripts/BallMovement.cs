using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;    //공의 속도
    public int verticalDirection = 1;   //상하
    public int horizontalDirection = 1; //좌우
    public Rigidbody2D rigid;   //물체의 물리 적용을 위한 Rigidbody2D

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 2); //지역 변수 randomNumber에 0 ~ 1 까지의 랜덤 정수 지정

        if(randomNumber == 0)   //randomNumber가 0일 때
        {
            horizontalDirection = 1;        //공의 방향을 오른쪽으로 변경
        }
        else
        {
            horizontalDirection = 0;        //공의 방향을 왼쪽으로 변경
        }

        verticalDirection = 1;              //공의 상하 방향을 아랠로 설정

        //공의 속도를 변경
        rigid.velocity = new Vector2(speed * horizontalDirection, speed * verticalDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall") //내가 충돌한 물체의 tag가 "Wall"이라면
        {
            verticalDirection *= -1;            //상하 방향 반전
        }
        if(collision.transform.tag == "Player") //내가 충돌한 물체의 tag가 "Player"이라면
        {
            horizontalDirection *= -1;          //좌우 방향 회전
        }

        //공의 속도를 변경
        rigid.velocity = new Vector2(speed * horizontalDirection, speed * verticalDirection);
    }
}
