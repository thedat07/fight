using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StoreItemPick : MonoBehaviour
{
    // Start is called before the first frame update
    public SnakeCustom snakeCustom;
    public Transform Content;
    public int type;
    public ButtonItem prefabs;
    void Start()
    {
        for(int i =0;i< snakeCustom.so[type].so.prefab.Length; i++)
        {
            GameObject model = snakeCustom.so[type].so.prefab[i];
            var btn = Lean.Pool.LeanPool.Spawn(prefabs, Content);
            btn.GetComponent<ButtonItem>().InitModel(model, snakeCustom,i, type);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
