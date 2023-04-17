using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RevivalPoint : MonoBehaviour
{
    SpamEnemies m_SpamEnemies;
    private float m_Time;
    // Start is called before the first frame update
    void Start()
    {
        m_SpamEnemies = FindObjectOfType<SpamEnemies>();
    }

    private void OnEnable()
    {
        m_Time = 3;
    }
    private void Update(){
        if(m_Time<0){
       m_SpamEnemies.SpamEnemy(transform.position);
            gameObject.SetActive(false);
        }
        m_Time-=Time.deltaTime;
    }
}
