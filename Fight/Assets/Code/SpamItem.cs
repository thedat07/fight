using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamItem : MonoBehaviour
{
    public float time;
    private float m_CountDownTime;
    public Transform snake;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_CountDownTime < 0)
        {
            SpamItemPos();
            m_CountDownTime = time;
        }
        m_CountDownTime -= Time.deltaTime;
    }
    private void SpamItemPos()
    {
        Vector3 random = Random.insideUnitSphere * 5;
        random.y = 0;
        Vector3 pos = random + snake.position;
        var itemSpam = Instantiate(item, pos, Quaternion.identity);
    }
}
