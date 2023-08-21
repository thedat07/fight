using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lstEnmies;
    public List<GameObject> lstEnmiesNow;
    public int numberEnmies;
    public Transform player;
    public RevivalPoint RevivalPoint;
    public int minDir;
    public int maxDir;
    public UIGamePlay UIGamePlay;
    void Start()
    {
        for(int i = 0; i < numberEnmies; i++)
        {
            SpamEnemy(Static.RandomPointInAnnulus(minDir, maxDir));
        }
    }
      
    public void SpamEnemy(Vector3 _point)
    {
        var enmey = Lean.Pool.LeanPool.Spawn(lstEnmies[Random.Range(0, lstEnmies.Count)], _point, Quaternion.identity);
        UIGamePlay.CreateText(string.Format("Player {0}", Random.Range(0, 100)), enmey.GetComponent<SnakeBase>(), false);
        enmey.GetComponent<SnakeAI>().player = player;
        enmey.GetComponent<SnakeAI>().SpamEnemies = this;
        lstEnmiesNow.Add(enmey);
    }
    public void SpamRevivalPoint()
    {
        var enmey = Lean.Pool.LeanPool.Spawn(RevivalPoint, Static.RandomPointInAnnulus(minDir, maxDir), Quaternion.identity);
    }
    // Update is called once per frame

}
