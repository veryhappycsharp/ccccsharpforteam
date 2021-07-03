using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    bool textFinished;

    [Header("头像")]
    public Sprite face01,face02,face03,face04;
    List<string> textList=new List<string>();
    void  Awake() 
    {
        GetTextFormFile(textFile);
       
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&index==textList.Count){
            gameObject.SetActive(false);
            index=0;
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)&&textFinished){
           // textLabel.text=textList[index];
           // index++;
           StartCoroutine(SetTextUI());
        }
        
    }
    private void OnEnable(){
       // textLabel.text=textList[index];
       // index++;
       textFinished=true;
       //协程
        StartCoroutine(SetTextUI());
    }

    void GetTextFormFile(TextAsset file){
        textList.Clear();
        index=0;
        
        var lineDate=file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textList.Add(line);

            
        }
    }
    //实现字符跳动出现,协程
    IEnumerator SetTextUI(){
        textFinished=false;
        textLabel.text="";
        switch (textList[index])
        {
            case "A" :
            faceImage.sprite=face01;
            index++;
            break;
            case "B" :
            faceImage.sprite=face02;
            index++;
             break;
            //爱丽
            case "C" :
            faceImage.sprite=face03;
            index++;
             break;
            //勇者
            case "D" :
            faceImage.sprite=face04;
            index++;
            break;
        }
        for(int i=0;i<textList[index].Length;i++){
            textLabel.text+=textList[index][i];
            　yield return new WaitForSeconds(0.1f);
        }
        textFinished=true;
        index++;
    }
}
