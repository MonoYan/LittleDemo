using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI")]
    public Text textLabel;
    //public SpriteRenderer role1;

    [Header("Text file")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;


    [Header("Expression")]
    //public Sprite face01;

    bool textFinished;
    bool cancelTyping;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }
    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    void Update()
    {
        Func();
    }
    void Func() 
    {
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        //if (Input.GetKeyDown(KeyCode.E) && textFinished)
        //{
        //    StartCoroutine(SetTextUI());
        // }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
        {
            textList.Clear();
            index = 0;
            var lineData = file.text.Split('\n');

            foreach (var line in lineData)
            {
                textList.Add(line);
            }
        }

        IEnumerator SetTextUI()
        {
            textFinished = false;
            textLabel.text = "";
            ////表情
            //switch (textList[index])
            //{
            //    case "A\r":
            //        role1.sprite = face01;
            //        index++;
            //        break;
            //}

            //for (int i = 0; i < textList[index].Length; i++)
            //{
            //    textLabel.text += textList[index][i];

            //    yield return new WaitForSeconds(textSpeed);
            //}
            int letter = 0;
            while (!cancelTyping && letter < textList[index].Length - 1)
            {
                textLabel.text += textList[index][letter];
                letter++;
                yield return new WaitForSeconds(textSpeed);
            }
            textLabel.text = textList[index];
            cancelTyping = false;
            textFinished = true;
            index++;
        }
    } 

