using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public GameObject gamePlay;
    // Start is called before the first frame update
   public void OnClickButtonPlay()
    {
        gamePlay.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
