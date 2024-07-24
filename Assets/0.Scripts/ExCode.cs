using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCode : MonoBehaviour
{
    public int level = 10;               	//int(정수) Level(변수 이름) 선언하고 10 값을 넣어줌
    public float hp = 100.0f;	            //float(실수) Hp(변수 이름)을 선언하고 100의 값을 넣어줌
    public bool isDead = false;             //bool(참/거짓) isDead(변수 이름)을 선언하고 거짓 값을 넣어줌
    public string playerName = "김장군";    //string(문자열) PlayerName(변수 이름)을 선언하고 이름 값을 넣어줌

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)        //반복문 for(초기 실행; 조건문; 종료시 실행)
        {
            Debug.Log($"{i}번째 반복문입니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//만약에 스페이스바 버튼이 눌렸을 때
        {
            //Debug.Log($"이름 : {playerName}, 레벨 : {level}, HP : {hp}");
            Attack(5);
            if (hp > 0)     //hp가 0보다 클 떄
                Debug.Log($"현재 체력 : {hp}");
            else            //hp가 0보다 작거나 같을 때
            {
                Debug.Log("죽었습니다.");
                isDead = true;  //isDead 값을 true로 변경
            }
        }

        
    }

    void Attack(float damage)   //공격 함수 선언(매개변수)
    {
        hp -= damage;
    }
}