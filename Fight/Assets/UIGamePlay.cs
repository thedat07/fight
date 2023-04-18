using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Linq;
public class UIGamePlay : MonoBehaviour
{
    public List<UIGamePlayInfo> lisInfo;
    public TextMeshProUGUI textDemo;
    public Transform content;
    private void Update()
    {
       var listsort = lisInfo.OrderByDescending(x => x.SnakeController.BodyParts.Count).ToList();
        for(int i =0;i< listsort.Count; i++)
        {
            listsort[i].text.GetComponent<RectTransform>().anchoredPosition = new Vector3(100,(-16.6f -(-33.2f*(i+1)))*-1,0);
            listsort[i].text.text = string.Format("{0} : {1}", listsort[i].name, listsort[i].SnakeController.BodyParts.Count);
        }
    }
    public void CreateText(string _name, SnakeBase _base)
    {
        var text = Instantiate(textDemo, content);
         UIGamePlayInfo info = new UIGamePlayInfo();
        info.name = _name;
        info.SnakeController = _base;
        info.text = text;
        lisInfo.Add(info);
    }
}
[System.Serializable]
public class UIGamePlayInfo
{
    public string name;
    public SnakeBase SnakeController;
    public TextMeshProUGUI text;
}