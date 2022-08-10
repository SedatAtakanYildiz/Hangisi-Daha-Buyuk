#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Algorithm : MonoBehaviour
{
    public Text  Side1txt,Side2txt, ScoreTxt, LevelTxt, TimerTxt, FinishTxt;
    public GameObject FinishPanel, Side1, Side2,Side3;
    string islem1, islem2, islem3;
    int counter = 0, level = 1, Islem1, Islem2, Islem3, answerSide =0, score = 0;
    float zmn = 60;
    void Start()
    {
        Application.targetFrameRate = 60;
        TimerTxt.text = "" + (int)zmn;
        NewQuestion();
    }
    void Update()
    {
        if (zmn > 0) { zmn -= Time.deltaTime; TimerTxt.text = "" + (int)zmn; }
        if (zmn == 0)
        {
            zmn = 0;
            FinishPanel.SetActive(true);
            Side1.SetActive(false);
            Side2.SetActive(false);
            Side3.SetActive(false);
            FinishTxt.text = "Game Over! \n Score:" + score.ToString() + "\n Level:" + level.ToString();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            side1();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            side2();
        }
    }
    public void side1()
    {
        if (answerSide == 1)
        {
            score += 100 * level;
            counter++;
            ScoreTxt.text = score.ToString();
            NewQuestion();
        }
        else
        {
            zmn = 0;
            FinishPanel.SetActive(true);
            Side1.SetActive(false);
            Side2.SetActive(false);
            Side3.SetActive(false);
            FinishTxt.text = "Game Over! \n Score:" + score.ToString() + "\n Level:" + level.ToString();
        }
    }
    public void side2()
    {
        if (answerSide == 2)
        {
            score += 100 * level;
            counter++;
            ScoreTxt.text = score.ToString();
            NewQuestion();
        }
        else
        {
            zmn = 0;
            FinishPanel.SetActive(true);
            Side1.SetActive(false);
            Side2.SetActive(false);
            Side3.SetActive(false);
            FinishTxt.text = "Game Over! \n Score:" + score.ToString() + "\n Level:" + level.ToString();
        }
    }
    public void sideDraw()
    {
        if (answerSide == 3)
        {
            score += 100 * level;
            counter++;
            ScoreTxt.text = score.ToString();
            NewQuestion();
        }
        else
        {
            zmn = 0;
            FinishPanel.SetActive(true);
            Side1.SetActive(false);
            Side2.SetActive(false);
            Side3.SetActive(false);
            FinishTxt.text = "Game Over! \n Score:" + score.ToString() + "\n Level:" + level.ToString();
        }
    }
    //soru getirme
    void NewQuestion()
    {
        if (counter == 5) { level++; counter = 0; LevelTxt.text = level.ToString(); zmn += 10; }
        if (level == 1)
        {
            level1();
        }
        else if (level == 2)
        {
            Level2();

        }
        else if (level == 3)
        {
            level3();
        }
        else if (level == 4)
        {
            leveltwin();
        }
        else
        {
            int rnd = Random.Range(1, 3);
            if (rnd == 1) { leveltwin(); }
            else if (rnd == 2) { finalLevel(); }
        }


    }
    //levels
    void level1()
    {
        int Num1 = Random.Range(1, 100);
        int Num2 = Random.Range(1, 100);
        Side1txt.text = Num1.ToString();
        Side2txt.text = Num2.ToString();
        if (Num1 < Num2) { answerSide = 2; }
        else if (Num1 > Num2) { answerSide = 1; }
        else if (Num1 == Num2) { answerSide = 3; }
    }
    void Level2()
    {
        IslemIsaretleri1();
        int cvp = 0;
        Islem1 = Random.Range(1, 4);
        IslemIsaretleri1();
        int Num1 = Random.Range(1, 100);
        int Num2 = Random.Range(1, 100);
        int Num3 = Random.Range(1, 100);
        Side1txt.text = Num1.ToString()+" "+islem1+" "+Num2.ToString();
        Side2txt.text = Num3.ToString();
        cvp=ikiliIslem(Num1, Num2,Islem1);
        if (cvp > Num3) { answerSide = 1; }
        else if (cvp < Num3) { answerSide = 2; }
        else if (cvp == Num3) { answerSide = 3; }
    }
    void level3()
    {
        int rnd = Random.Range(1, 3);
        if (rnd == 1)
        {
            Level2();
        }
        else if (rnd == 2)
        {
            leveltwin();
        }
    }
    void leveltwin()
    {
        int cvp1 = 0, cvp2 = 0;
        Islem1 = Random.Range(1, 4);
        Islem2 = Random.Range(1, 4);
        int Num1 = Random.Range(1, 100);
        int Num2 = Random.Range(1, 100);
        int Num3 = Random.Range(1, 100);
        int Num4 = Random.Range(1, 100);
        IslemIsaretleri1();
        IslemIsaretleri2();
        Side1txt.text = Num1.ToString() + " " + islem1 + " " + Num2.ToString();
        Side2txt.text = Num3.ToString() + " " + islem2 + " " + Num4.ToString();
        cvp1 = ikiliIslem(Num1,Num2, Islem1);
        cvp2 = ikiliIslem(Num3, Num4,Islem2);
        if (cvp1 > cvp2) { answerSide = 1; }
        else if (cvp2 > cvp1) { answerSide = 2; }
        else if (cvp1 == cvp2) { answerSide = 3; }
    }
    void finalLevel()
    {
        int cvp1 = 0, cvp2 = 0;
        Islem1 = Random.Range(1, 4);
        Islem2 = Random.Range(1, 4);
        Islem3 = Random.Range(1, 4);
        int Num1 = Random.Range(1, 100);
        int Num2 = Random.Range(1, 100);
        int Num3 = Random.Range(1, 100);
        int Num4 = Random.Range(1, 100);
        int Num5 = Random.Range(1, 100);
        IslemIsaretleri1();
        IslemIsaretleri2();
        IslemIsaretleri3();
        Side1txt.text = Num1.ToString() + " " + islem1 + " " + Num2.ToString()+" "+islem2+" "+Num3.ToString();
        Side2txt.text = Num4.ToString() + " " + islem3 + " " + Num5.ToString();
        cvp1 = ucluislem(Num1, Num2, Num3, Islem1, Islem2);
        cvp2 = ikiliIslem(Num4, Num5, Islem3);
        if (cvp1 > cvp2) { answerSide = 1; }
        else if (cvp2 > cvp1) { answerSide = 2; }
        else if (cvp1 == cvp2) { answerSide = 3; }
    }
    //islemler burada 2li veya 3 lü iþlemler yapýlmakta
    int ucluislem(int Num1,int Num2,int Num3,int Islem1,int Islem2)
    {
        int cvp = 0;
        if (Islem2 != 3) { 
            cvp=ikiliIslem(Num1, Num2, Islem1);
            cvp= ikiliIslem(cvp, Num3, Islem2);
        }
        else if (Islem2 == 3) {
            cvp = Num2 * Num3;
            cvp = ikiliIslem(Num1, cvp, Islem1);
               }
        return cvp;
    }
    int  ikiliIslem(int Num1,int Num2,int Islem)
    {
       
        int cvp = 0;
        if (Islem == 1)
        {
            cvp = Num1 + Num2;
        }
        else if (Islem == 2)
        {
            cvp = Num1 - Num2;
        }
        else if (Islem == 3)
        {
            cvp = Num1 * Num2;
        }
        return cvp;
    }
    //islem iþaretleri string ifadeye çevriliyor
    void IslemIsaretleri1()
    {
        if (Islem1 == 1) { islem1 = "+"; }
        else if (Islem1 == 2) { islem1 = "-"; }
        else if (Islem1 == 3) { islem1 = "*"; }
    }
    void IslemIsaretleri2()
    {
        if (Islem2 == 1) { islem2 = "+"; }
        else if (Islem2 == 2) { islem2 = "-"; }
        else if (Islem2 == 3) { islem2 = "*"; }
    }
    void IslemIsaretleri3()
    {
        if (Islem3 == 1) { islem3 = "+"; }
        else if (Islem3 == 2) { islem3 = "-"; }
        else if (Islem3 == 3) { islem3 = "*"; }
    }
}
#endif