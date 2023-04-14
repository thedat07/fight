using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIGamePlay : MonoBehaviour
{
    public GameObject gamePlay;
    public int gold;
    public TextMeshProUGUI txtGold;
    public RectTransform m_ImageGold;
    public List<Sprite> lstStart;
    public Image img_Strat;
    public TextMeshProUGUI m_TextInfo;
    void OnEnable()
    {
        gamePlay.gameObject.SetActive(true);
    }
    void OnDisable()
    {
        gamePlay.gameObject.SetActive(false);
    }
    public void UpdateGold(int number)
    {
        gold += number;
        txtGold.text = gold.ToString();
        m_ImageGold.DORewind();
        m_ImageGold.DOPunchScale(Vector3.one * 0.2f, 0.25f);
    }
    public void UpdateStart(int _point, int _pointMax)
    {
        m_TextInfo.text = string.Format("{0}/{1}", _point, _pointMax);
        if(_point< _pointMax / 3)
        {
            img_Strat.sprite = lstStart[0];
        }else if (_point < _pointMax / 2)
        {
            img_Strat.sprite = lstStart[1];
        }
        else
        {
            img_Strat.sprite = lstStart[2];
        }
    }
}
