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
        int count = 0;
        foreach(var i in so)
        {
            i.id = GetData(count);
            UpdateCustom(i);
            count++;
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
        SaveData(_id, _type);
    }
    public void SaveData(int _id, int _type)
    {
        switch (_type)
        {
            case 1:
                PlayerPrefs.SetInt(Static.armLeftData, _id);
                break;
            case 2:
                PlayerPrefs.SetInt(Static.armRightData, _id);
                break;
            case 3:
                PlayerPrefs.SetInt(Static.headData, _id);
                break;
            case 4:
                PlayerPrefs.SetInt(Static.bodyData, _id);
                break;
        }
        PlayerPrefs.Save();
    }

    public int GetData( int _type)
    {
        int number = 0;
        switch (_type)
        {
            case 1:
                number= PlayerPrefs.GetInt(Static.armLeftData, _type);
                break;
            case 2:
                number= PlayerPrefs.GetInt(Static.armRightData, _type);
                break;
            case 3:
                number= PlayerPrefs.GetInt(Static.headData, _type);
                break;
            case 4:
                number= PlayerPrefs.GetInt(Static.bodyData, _type);
                break;
        }
        return number;
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