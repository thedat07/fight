using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lstEnmies;

    public int numberEnmies;
    public Transform player;
    public RevivalPoint RevivalPoint;
    void Start()
    {
        for(int i = 0; i < numberEnmies; i++)
        {
            SpamEnemy(Static.RandomPointInAnnulus(10, 15));
        }
    }
      
    public void SpamEnemy(Vector3 _point)
    {
        var enmey = Lean.Pool.LeanPool.Spawn(lstEnmies[Random.Range(0, lstEnmies.Count)], _point, Quaternion.identity);
        enmey.GetComponent<SnakeAI>().player = player;
        enmey.GetComponent<SnakeAI>().SpamEnemies = this;
    }
    public void SpamRevivalPoint()
    {
        var enmey = Lean.Pool.LeanPool.Spawn(RevivalPoint, Static.RandomPointInAnnulus(10, 15), Quaternion.identity);
    }
    // Update is called once per frame

}
