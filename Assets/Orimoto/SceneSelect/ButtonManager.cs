using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Animator skyButton;
    [SerializeField] Animator rageButton;
    [SerializeField] Animator uniButton;

    bool inputed = false;
    float inputNum = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(Input.GetAxis("Horizontal2") < -inputNum)
        {
            skyButton.SetBool("select",false);
            uniButton.SetBool("select",true);
            inputed = true;
        }
        else if(Input.GetAxis("Horizontal2") > inputNum)
        {
            skyButton.SetBool("select", false);
            rageButton.SetBool("select", true);
            inputed = true;
        }
    }

    void RageButton()
    {
        if (Input.GetAxis("Horizontal2") < -inputNum)
        {
            rageButton.SetBool("select", false);
            skyButton.SetBool("select", true);
            inputed = true;

        }
        else if (Input.GetAxis("Horizontal2") > inputNum)
        {
            rageButton.SetBool("select", false);
            uniButton.SetBool("select", true);
            inputed = true;

        }
    }

    void UniButton()
    {
        if (Input.GetAxis("Horizontal2") < -inputNum)
        {
            uniButton.SetBool("select", false);
            rageButton.SetBool("select", true);
            inputed = true;

        }
        else if (Input.GetAxis("Horizontal2") > inputNum)
        {
            uniButton.SetBool("select", false);
            skyButton.SetBool("select", true);
            inputed = true;
        }
    }
    
}
