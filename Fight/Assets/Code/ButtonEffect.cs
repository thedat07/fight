using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ButtonEffect : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform m_RectTransform;
    public Ease ease;
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        Scale();
    }

    private void Scale()
    {
        m_RectTransform.DOScale(Vector3.one, 0.5f).SetEase(ease).SetLoops(-1,LoopType.Yoyo).From(Vector3.one*0.8f);
    }
}
