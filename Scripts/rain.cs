using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    int type;
    float size; //기준 물방울 크기
    int score;  //몇점을 득하는지

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f); //-2.7 에서 2.7 사이 랜덤값을 부여
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        type = Random.Range(1, 5);  //1에서 5 사이의 값을 받는다

        if (type == 1)//제일 큰 물방울
        {
            size = 1.2f;
            score = 3;
            GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
            //색상 변경. 꼭 255f로 나눠줘야한다. 나눈 값이 소수로 나와야한다.
        }
        else if (type == 2)//중간 물방울
        {
            size = 1.0f;
            score = 2;
            GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
        }
        else if(type == 3)
        {   //가장 작은 물방울
            size = 0.8f;
            score = 1;
            GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 255 / 255f);
        }
        else
        {
            size = 0.8f;
            score = -5;
            GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
        }
        transform.localScale = new Vector3(size, size, 0);
        //사이즈 변경
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //두 콜라이더가 부딪혔을때. 함수에 들어오는 괄호값은 부딪힌 상대방이 들어온다. 그 값이 ground인지 확인.
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            //Debug.Log("땅이다!");
            Destroy(gameObject);    //빗방울 사라지기
        }

        if (coll.gameObject.tag == "rtan")
        {
            GameManager.I.addScore(score);  //게임매니저에서 불러오기.
            Destroy(gameObject);    //빗방울 사라지기
        }

    }

}
