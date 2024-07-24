using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI�� ���� ���� ���̺귯�� ����
using UnityEngine.SceneManagement;  //�� ��ȯ�� ���� ���̺귯�� ����

public class Manager : MonoBehaviour
{
    public Text timeText;           //Text UI

    public GameObject ballPrefabs;  //�� ������Ʈ�� Prefabs
    public GameObject gameoverUI;   //���� ���� UI

    private bool ballExists = false;//���� ������ ���� �����ϴ��� Ȯ���ϴ� bool ����
    private bool play = false;      //���� ������ ���������� Ȯ���ϴ� bool ����
    private float playTime = 0.0f;  //���� ������ ����� �ð�

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
        if (!ballExists)            //���� ���� �������� ���� ��
        {
            if (Input.anyKeyDown)   //�ƹ� ��ư�̳� ������
            {
                ballExists = true;  //���� �����Ѵٰ� ����
                Instantiate(ballPrefabs, new Vector2(0, 2), Quaternion.identity);   //���� �������� ����
            }
        }

        if (play && ballExists)     //���� �÷��� ���̰�, ���� ������ ��
        {
            playTime += Time.deltaTime; //�÷��� Ÿ�� ����

            timeText.text = "PlayTime : " + playTime.ToString("00:00");
        }

        if(!play)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene("GameScene");    //GameScene �ٽ� �ε�
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  //�ٸ� ��ü�� �浹�� ���
    {
        if (collision.transform.tag == "Ball")  //�浹�� ��ü�� tag�� "Ball"�̶��
        {
            Destroy(collision.gameObject);  //�浹�� ��ü ����
            play = false;                   //play�� false�� ����
            gameoverUI.SetActive(true);     //���ӿ��� UI Ȱ��ȭ
        }
    }
}