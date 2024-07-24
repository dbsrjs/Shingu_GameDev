using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI를 쓰기 위한 라이브러리 선언
using UnityEngine.SceneManagement;  //씬 전환을 위한 라이브러리 선언

public class Manager : MonoBehaviour
{
    public Text timeText;           //Text UI

    public GameObject ballPrefabs;  //공 오브젝트의 Prefabs
    public GameObject gameoverUI;   //게임 종료 UI

    private bool ballExists = false;//현재 씬에서 공이 존재하는지 확인하는 bool 변수
    private bool play = false;      //현재 게임이 진행중인지 확인하는 bool 변수
    private float playTime = 0.0f;  //현재 게임이 진행된 시간

    // Start is called before the first frame update
    void Start()
    {
        play = true;
        ballExists = false;
        playTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballExists)            //현재 공이 존재하지 않을 때
        {
            if (Input.anyKeyDown)   //아무 버튼이나 누르면
            {
                ballExists = true;  //공이 존재한다고 변경
                Instantiate(ballPrefabs, new Vector2(0, 2), Quaternion.identity);   //공을 동적으로 생성
            }
        }

        if (play && ballExists)     //현재 플레이 중이고, 공이 존재할 때
        {
            playTime += Time.deltaTime; //플레이 타임 갱신

            timeText.text = "PlayTime : " + playTime.ToString("00:00");
        }

        if(!play)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene("GameScene");    //GameScene 다시 로드
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  //다른 물체와 충돌할 경우
    {
        if (collision.transform.tag == "Ball")  //충돌한 물체의 tag가 "Ball"이라면
        {
            Destroy(collision.gameObject);  //충돌한 물체 삭제
            play = false;                   //play를 false로 변경
            gameoverUI.SetActive(true);     //게임오버 UI 활성화
        }
    }
}