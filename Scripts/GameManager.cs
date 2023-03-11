using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI 텍스트 받기(ex.점수갱신)
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject rain;
    public GameObject panel;
    public static GameManager I; //게임매니저 싱글톤 설정 (대문자 아이)

    public Text scoreText;
    public Text timeText;
    int totalScore = 0;
    float limit = 60f;    //시간(기본시간 설정해줌)

    void Awake()
    {
        I = this;   //게임매니저 싱글톤 설정
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f);   //makeRain함수를 0.5초마다 계속 발생시킨다.
        initGame();
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            Time.timeScale = 0.0f;  //timeScale 속성은 시간을 빠르게 느리게 원래대로 할지. 멈추게 할지를 지정해주는(0이 멈춤)
            panel.SetActive(true);
            limit = 0.0f;
        }
        timeText.text = limit.ToString("N2");   //N2 옵션은 소수점 둘쨰자리까지 잘라서 문자열로 바꿔줘라.

    }

    void makeRain()
    {
        //Debug.Log("비를 내려라!");

        Instantiate(rain);  //prefab rain 복제 생성
    }

    public void addScore(int score)
    {
        totalScore += score;    //score 합산
        scoreText.text = totalScore.ToString(); //totalScore(숫자)를 ToString()를 사용해 문자로 바꿔줌?
    }

    public void retry() //다시시작. 판넬 버튼을 클릭하면 게임매니저에서 이 함수를 불러오게 한다.
    {
        SceneManager.LoadScene("MainScene");
    }
    //중요한 기능은 게임매니저에 구현해놓고 각자 다른 곳에서 게임매니저에 있는 함수를 불러오는 형식으로 사용한다.

    void initGame()
    {
        Time.timeScale = 1.0f;  //원래대로 시간이 가도록 세팅한다.
        totalScore = 0;         //지금까지 누적된 점수를 초기화
        limit = 60.0f;          //limit을 원래대로
    }
}
