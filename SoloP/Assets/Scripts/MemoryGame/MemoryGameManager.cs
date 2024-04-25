using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int cardNum; // 클릭한 카드 번호
    int lastNum = 0; //직전의 카드 번호
    int cardCnt;
    int hitCnt = 0;
    static public int stageNum = 1;
    int stageCnt = 6;
    int[]arCards = new int[50];
    float startTime;
    float stageTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = stageTime = Time.time;
        StartCoroutine(MakeStage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeStage()
    {
        float sx = 0;
        float sz = 0;
        SetCardPos(out sx, out sz);
        int n = 1;
        string[]str = StageSet.stage[stageNum -1];
        foreach (string t in str)
        {
            char[]ch = t.Trim().ToCharArray();
            float x = sx;
            foreach(char c in ch)
            {
                switch (c)
                {
                    case '*':
                    GameObject card = Instantiate(Resources.Load("Prefab/Card"))as GameObject;
                    card.transform.position = new Vector3(x,0,sz);
                    card.tag = "card" + n++;
                    x++;
                    break;
                    case'.':
                    x++;
                    break;
                    case'>':
                    x += 0.5f;
                    break;
                    case'^':
                    sz += 0.5f;
                    break;
                }
                if(c == '*')
                {
                     yield return new WaitForSeconds(0.03f);
                }
            }
            sz--;
        }
    }
    void SetCardPos(out float sx, out float sz)
    {
        float x = 0;
    float z = 0; // 여기서 등호를 사용했던 것을 수정
    float maxX = 0;
    cardCnt = 0;
    string[] str = StageSet.stage[stageNum - 1]; // 여기서 등호를 사용했던 것을 수정
    for (int i = 0; i < str.Length; i++)
    {
        string t = str[i].Trim();
        x = 0;
        for (int j = 0; j < t.Length; j++)
        {
            switch (t[j])
            {
                case '.':
                case '*':
                    x++;
                    if (t[j] == '*')
                    {
                        cardCnt++;
                    }
                    break;
                case '>':
                    x += 0.5f;
                    break;
                case '^':
                    z -= 0.5f;
                    break;
            }
        }
        if (x > maxX)
        {
            maxX = x;
        }
        z++;
    }
    sx = -maxX / 2;
    sz = (z - 1) / 2;
    }
}