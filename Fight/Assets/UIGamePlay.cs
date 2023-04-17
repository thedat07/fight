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
}
