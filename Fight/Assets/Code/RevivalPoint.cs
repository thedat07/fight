using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RevivalPoint : MonoBehaviour
{
    SpamEnemies m_SpamEnemies;
    public float m_time;
    // Start is called before the first frame update
    void Start()
    {
        m_SpamEnemies = FindObjectOfType<SpamEnemies>();
    }

    private void OnEnable()
    {
        m_time = 3;
    }
    private void Update()
    {
        if (m_time < 0)
        {
            m_SpamEnemies.SpamEnemy(transform.position);
            gameObject.SetActive(false);
        }
        m_time -= Time.deltaTime;
        transform.localScale = Vector3.one * (m_time>=1?1: m_time);
    }
}
