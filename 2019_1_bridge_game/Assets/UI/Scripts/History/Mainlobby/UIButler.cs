﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButler : UIControl
{
    private Touch tempTouchs;
    private int tcount;

    void OnEnable()
    {
        //첫실행여부

        PlayerPrefs.SetInt("Tutorial_Start", PlayerPrefs.GetInt("Tutorial_Start", 0));
        //debug용
       // PlayerPrefs.SetInt("Tutorial_Start", 0);
        //첫실행시 대사 출력
        if (PlayerPrefs.GetInt("Tutorial_Start") == 0)
        {
            Debug.Log("First execution");
            PlayerPrefs.SetInt("Tutorial_Start", 1);

            //대사출력
            GameObject.Find("butler_panel").transform.Find("initialscript_panel").gameObject.SetActive(true);
            PlayerPrefs.Save();
        }
        //나머지 실행
        else if (PlayerPrefs.GetInt("Tutorial_Start") != 0)
        {
            Debug.Log("Extra execution");
            GameObject.Find("butler_panel").transform.Find("IllustrateBook_panel").gameObject.SetActive(true);
            GameObject.Find("butler_panel").transform.Find("butlerscript_panel").gameObject.SetActive(true);
        }
        tcount = 0;
    }
    void Update()
    {
        /*
        //초기화면 실행 후 터치 시
        if (Input.touchCount > 0)
        {
            tempTouchs = Input.GetTouch(0);
            if (tempTouchs.phase == TouchPhase.Ended && tcount == 0)
            {
                Debug.Log("Touched");
                GameObject.Find("butler_panel").transform.Find("initialscript_panel").gameObject.SetActive(false);
                GameObject.Find("butler_panel").transform.Find("IllustrateBook_panel").gameObject.SetActive(true);
                GameObject.Find("butler_panel").transform.Find("butlerscript_panel").gameObject.SetActive(true);
                tcount++;
            }
        }
        */

    }
}
