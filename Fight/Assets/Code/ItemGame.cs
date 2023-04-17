using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemGame : MonoBehaviour
{
    // Start is called before the first frame update
    Collider m_Collider;
    private float m_CountDownTime;
    public int gold;
    UIGamePlay m_UIGamePlay;
    public float m_TimeHide;
    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
        m_UIGamePlay = FindObjectOfType<UIGamePlay>();
    }

    void OnEnable()
    {
        transform.DOScale(Vector3.one, 0.25f).From(Vector3.zero)
            .OnStart(() => { m_Collider.enabled = false; })
            .OnComplete(() => { m_Collider.enabled = true; });
        m_CountDownTime = m_TimeHide;
        m_Collider.enabled = true;
        enabled = true;
    }
    public void Pick(bool _check=true)
    {
        m_Collider.enabled = false;
        enabled = false;
    }
    public void Clear()
    {
        m_Collider.enabled = true;
        enabled = true;
    }
}
