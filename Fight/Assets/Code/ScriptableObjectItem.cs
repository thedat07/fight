using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableObjectItem", order = 1)]
public class ScriptableObjectItem : ScriptableObject
{
    public GameObject[] prefab;
}