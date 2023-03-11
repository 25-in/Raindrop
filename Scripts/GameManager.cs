using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI �ؽ�Ʈ �ޱ�(ex.��������)
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject rain;
    public GameObject panel;
    public static GameManager I; //���ӸŴ��� �̱��� ���� (�빮�� ����)

    public Text scoreText;
    public Text timeText;
    int totalScore = 0;
    float limit = 60f;    //�ð�(�⺻�ð� ��������)

    void Awake()
    {
        I = this;   //���ӸŴ��� �̱��� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f);   //makeRain�Լ��� 0.5�ʸ��� ��� �߻���Ų��.
        initGame();
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            Time.timeScale = 0.0f;  //timeScale �Ӽ��� �ð��� ������ ������ ������� ����. ���߰� ������ �������ִ�(0�� ����)
            panel.SetActive(true);
            limit = 0.0f;
        }
        timeText.text = limit.ToString("N2");   //N2 �ɼ��� �Ҽ��� �Ѥ��ڸ����� �߶� ���ڿ��� �ٲ����.

    }

    void makeRain()
    {
        //Debug.Log("�� ������!");

        Instantiate(rain);  //prefab rain ���� ����
    }

    public void addScore(int score)
    {
        totalScore += score;    //score �ջ�
        scoreText.text = totalScore.ToString(); //totalScore(����)�� ToString()�� ����� ���ڷ� �ٲ���?
    }

    public void retry() //�ٽý���. �ǳ� ��ư�� Ŭ���ϸ� ���ӸŴ������� �� �Լ��� �ҷ����� �Ѵ�.
    {
        SceneManager.LoadScene("MainScene");
    }
    //�߿��� ����� ���ӸŴ����� �����س��� ���� �ٸ� ������ ���ӸŴ����� �ִ� �Լ��� �ҷ����� �������� ����Ѵ�.

    void initGame()
    {
        Time.timeScale = 1.0f;  //������� �ð��� ������ �����Ѵ�.
        totalScore = 0;         //���ݱ��� ������ ������ �ʱ�ȭ
        limit = 60.0f;          //limit�� �������
    }
}
