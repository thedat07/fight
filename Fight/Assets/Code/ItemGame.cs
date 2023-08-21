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
    public float m_TimeHide;
    public SnakeBase snake;
    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
    }

    void OnEnable()
    {
        transform.DOScale(Vector3.one, 0.25f).From(Vector3.zero)
            .OnStart(() => { m_Collider.enabled = false; })
            .OnComplete(() => { m_Collider.enabled = true; });
        m_CountDownTime = m_TimeHide;
        m_Collider.enabled = true;
        enabled = true;

        int LayerIgnoreRaycast = LayerMask.NameToLayer("Item");
        gameObject.layer = LayerIgnoreRaycast;
    }

    public void Pick(SnakeBase snake,bool _check=true)
    {
        this.snake = snake;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerIgnoreRaycast;
    }

    public void Clear()
    {
        snake = null;
       int LayerIgnoreRaycast = LayerMask.NameToLayer("Item");
        gameObject.layer = LayerIgnoreRaycast;
    }
}
