using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHide : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lstObjectFollow;
    public List<GameObject> lstObjectDontFollow;
    void OnDisable()
    {
        foreach(var i in lstObjectFollow)
        {
            i.SetActive(false);
        }
        foreach (var i in lstObjectDontFollow)
        {
            i.SetActive(true);
        }
    }

    void OnEnable()
    {
        foreach (var i in lstObjectFollow)
        {
            i.SetActive(true);
        }
        foreach (var i in lstObjectDontFollow)
        {
            i.SetActive(false);
        }
    }
}
