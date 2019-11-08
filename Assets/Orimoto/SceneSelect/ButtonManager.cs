﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Animator skyButton;
    [SerializeField] Animator rageButton;
    [SerializeField] Animator uniButton;
    [SerializeField] SceneChange sceneChange;

    bool inputed = false;
    float inputNum = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GameObject.Find("SceneManager").GetComponent<SceneChange>();
        Sound.LoadBGM("select", "select");
        Sound.LoadSE("click", "click");
        Sound.LoadSE("idou", "cursoridou");
        Sound.PlayBGM("select");
    }

    // Update is called once per frame
    void Update()
    {
        if(inputed)
        {
            if(Input.GetAxis("Horizontal2") > -0.3 && Input.GetAxis("Horizontal2") < 0.3)
            {
                inputed = false;
            }
            else
            {
                return;
            }
        }

        if(skyButton.GetBool("select"))
        {
            SkyButton();
        }
        else if(rageButton.GetBool("select"))
        {
            RageButton();
        }
        else if(uniButton.GetBool("select"))
        {
            UniButton();
        }
    }

    void SkyButton()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            skyButton.SetTrigger("play");
            sceneChange.ChangeSceneFade(SceneChange.FadeName.FADE_IN_DOWN, "ScenarioScene");
            rageButton.SetTrigger("notPlay");
            uniButton.SetTrigger("notPlay");
            Sound.PlaySE("click");
            Sound.StopBGM();
        }
        if(Input.GetAxis("Horizontal2") <= -inputNum)
        {
            skyButton.SetBool("select",false);
            uniButton.SetBool("select",true);
            inputed = true;
            Sound.PlaySE("idou");
        }
        else if(Input.GetAxis("Horizontal2") >= inputNum)
        {
            skyButton.SetBool("select", false);
            rageButton.SetBool("select", true);
            inputed = true;
            Sound.PlaySE("idou");
        }
    }

    void RageButton()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            rageButton.SetTrigger("play");
            sceneChange.ChangeSceneFade(SceneChange.FadeName.FADE_IN_DOWN, "RoughWeatherStage");
            skyButton.SetTrigger("notPlay");
            uniButton.SetTrigger("notPlay");
            Sound.PlaySE("click");
            Sound.StopBGM();
        }
        if (Input.GetAxis("Horizontal2") < -inputNum)
        {
            rageButton.SetBool("select", false);
            skyButton.SetBool("select", true);
            inputed = true;
            Sound.PlaySE("idou");

        }
        else if (Input.GetAxis("Horizontal2") > inputNum)
        {
            rageButton.SetBool("select", false);
            uniButton.SetBool("select", true);
            inputed = true;
            Sound.PlaySE("idou");

        }
    }

    void UniButton()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            uniButton.SetTrigger("play");
            sceneChange.ChangeSceneFade(SceneChange.FadeName.FADE_IN_DOWN, "UniverseStage");
            skyButton.SetTrigger("notPlay");
            rageButton.SetTrigger("notPlay");
            Sound.PlaySE("click");
            Sound.StopBGM();
        }
        if (Input.GetAxis("Horizontal2") < -inputNum)
        {
            uniButton.SetBool("select", false);
            rageButton.SetBool("select", true);
            inputed = true;
            Sound.PlaySE("idou");

        }
        else if (Input.GetAxis("Horizontal2") > inputNum)
        {
            uniButton.SetBool("select", false);
            skyButton.SetBool("select", true);
            inputed = true;
            Sound.PlaySE("idou");
        }
    }
    
}
