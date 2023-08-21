using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBase : MonoBehaviour
{
    public List<GameObject> BodyParts = new List<GameObject>();
    public List<Vector3> PositionsHistory = new List<Vector3>();
    protected virtual bool player => false;
}
