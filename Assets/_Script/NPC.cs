using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPC : MonoBehaviour
{
    public string ChatName;
    private bool canChant = false;
    public bool isAuto = false;
    //Menu自动播放
    private Collider2D others;
    bool menuStarts,menuEnds;


    void Start()
    {
        
    }
    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Menu 对话
        //bool menuStart = GameObject.Find("Flowchart - Start").GetComponent<Flowchart>().GetBooleanVariable("MenuStart");
        //bacon 对话
        

        if (other.tag == "Bacon")
        {
            GameObject.Find("Flowchart - Start").GetComponent<Flowchart>().SetBooleanVariable("MenuStart", true);

            Say();
        }
        canChant = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canChant = false;
    }
    void Update()
    {
        GetDialogBool();
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Say();
        }

        if (isAuto)
        {
            if (menuEnds)
            {
                Say();
            }
        }
    }

    /// <summary>
    /// 对话
    /// </summary>
    void Say() 
    {
        if (canChant)
        {
            //对话
            Flowchart flowchart = GameObject.Find("Flowchart - Start").GetComponent<Flowchart>();
            //对话系统是否存在
            if (flowchart.HasBlock(ChatName))
            {
                //执行对话
                flowchart.ExecuteBlock(ChatName);
            }
        }
    }

    void GetDialogBool() 
    {
        bool firstlaunch = GameObject.Find("ButtonManager").GetComponent<ButtonStart>().firstLaunch;
        if (firstlaunch)
        {
            bool menuEnd = GameObject.Find("Flowchart - Start").GetComponent<Flowchart>().GetBooleanVariable("MenuStart");
            menuEnds = menuEnd;
        }
    }

}
