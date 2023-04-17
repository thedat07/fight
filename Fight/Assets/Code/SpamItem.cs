using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpamItem : MonoBehaviour
{
    public float time;
    private float m_CountDownTime;
    public Transform snake;
    public ItemGame item;
    public ItemGame itemGold;
    public int numberMax;
    public float disMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CountDownTime < 0)
        {
            int random = Random.Range(1, numberMax);
            for(int i = 0; i < random; i++)
            {
                SpamItemPos();
            }
            m_CountDownTime = time;
        }
        m_CountDownTime -= Time.deltaTime;
    }
    private void SpamItemPos()
    {
        Vector3 random = Random.insideUnitSphere * Random.Range(1, disMax);
        random.y = 0;
        Vector3 pos = random;
        int randomRate = Random.Range(0, 100);
        var itemSpam = Lean.Pool.LeanPool.Spawn(randomRate>80? itemGold: item, pos, Quaternion.identity);

        itemSpam.GetComponent<ItemGame>().enabled = true;
    }
}
