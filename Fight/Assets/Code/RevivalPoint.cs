using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RevivalPoint : MonoBehaviour
{
    SpamEnemies m_SpamEnemies;
    // Start is called before the first frame update
    void Start()
    {
        m_SpamEnemies = FindObjectOfType<SpamEnemies>();
    }

    private void OnEnable()
    {
        transform.DOScale(Vector3.one, 1f).From(Vector3.one * 0.5f).SetLoops(3,LoopType.Yoyo).OnComplete(() =>
        {
            m_SpamEnemies.SpamEnemy(transform.position);
            gameObject.SetActive(false);
        });
    }
}
