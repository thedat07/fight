using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    [Header("Setting Enemy AI")]
    public ObstacleAvoidanceType AvoidanceType;
    public float AgentRadius = 0.33f;
    public Vector2 speed = new Vector2(10, 10);

    string[] names = new string[] { "Saab", "Volvo", "BMW", "123", "Panda", "Viet", "Checker", "Funny" };

    void Start()
    {
        for (int i = 0; i < numberEnmies; i++)
        {
            SpamEnemy(Static.RandomPointInAnnulus(minDir, maxDir));
        }
    }

    public void SpamEnemy(Vector3 _point)
    {
        var enmey = Lean.Pool.LeanPool.Spawn(lstEnmies[Random.Range(0, lstEnmies.Count)], _point, Quaternion.identity);
        UIGamePlay.CreateText(string.Format("{0}", RandomName()), enmey.GetComponent<SnakeBase>(), false);
        enmey.GetComponent<SnakeAI>().player = player;
        enmey.GetComponent<SnakeAI>().SpamEnemies = this;
        lstEnmiesNow.Add(enmey);

        SetupAgent(enmey.GetComponent<NavMeshAgent>());
    }

    private void SetupAgent(NavMeshAgent Agent)
    {
        Agent.radius = AgentRadius;
        Agent.obstacleAvoidanceType = AvoidanceType;
        Agent.speed = Random.Range(speed.x, speed.y);
        Agent.avoidancePriority = Random.Range(0, 100);
    }

    public void SpamRevivalPoint()
    {
        var enmey = Lean.Pool.LeanPool.Spawn(RevivalPoint, Static.RandomPointInAnnulus(minDir, maxDir), Quaternion.identity);
    }

    private string RandomName()
    {
        int number = Random.Range(0, names.Length);
        return names[number];
    }
    // Update is called once per frame

}
