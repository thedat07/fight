using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBase : MonoBehaviour
{
    public List<GameObject> BodyParts = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();
    private void Awake()
    {
        FindObjectOfType<UIGamePlay>().CreateText(string.Format("Player {0}", Random.Range(0, 100)), this);
    }
}
