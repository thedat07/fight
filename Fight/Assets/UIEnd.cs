using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI txtBtnDead;
    public int timeReset;
    public SnakeController snakeController;
    public GameObject gamePlay;
    public List<Sprite> lstSpriteStar;
    public List<Image> star;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        gamePlay.gameObject.SetActive(false);
        foreach (var i in star)
        {
            i.transform.DOPunchScale(Vector3.one * 0.2f,0.25f);
        }
    }
    void OnDisable()
    {
        gamePlay.gameObject.SetActive(true);
    }
    public void OnClickButtonDead()
    {
        if (timeReset > 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void Star(int _number)
    {
        for(int i =0;i< star.Count; i++)
        {
            if (i < _number)
            {
                star[i].sprite = lstSpriteStar[0];
            }
            else
            {
                star[i].sprite = lstSpriteStar[1];
            }
        }
    }
}
