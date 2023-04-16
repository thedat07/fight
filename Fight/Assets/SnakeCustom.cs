using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCustom : MonoBehaviour
{
    public Animator m_Animator;
    public InfoItem[] so;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var i in so)
        {
            UpdateCustom(i);
        }
    }

   private void UpdateCustom(InfoItem _info)
    {
        if (_info.pick != null) Lean.Pool.LeanPool.Despawn(_info.pick);
       var item=  Lean.Pool.LeanPool.Spawn(_info.so.prefab[_info.id], Vector3.zero, new Quaternion(0,0,0,0), _info.body.transform);
        item.transform.localPosition = _info.so.prefab[_info.id].transform.localPosition;
        item.transform.localRotation = _info.so.prefab[_info.id].transform.localRotation;
        _info.pick = item;
    }

    public void UpdateCustom(int _id, int _type )
    {
        m_Animator.SetTrigger("Pick");
        so[_type].id = _id;
        UpdateCustom(so[_type]);
    }
}
[System.Serializable]
public class InfoItem
{
    public int id;
    public ScriptableObjectItem so;
    public GameObject body;
    public GameObject pick;
}