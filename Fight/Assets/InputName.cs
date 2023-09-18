using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{

    public string Name;
    public TMP_InputField tMP_InputField;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            tMP_InputField.text = PlayerPrefs.GetString("Name");
        }
        else
        {
            tMP_InputField.text = Random.Range(0, 100).ToString();
            OnChangle();
        }
    }

    public void OnChangle()
    {
        PlayerPrefs.SetString("Name", tMP_InputField.text);
        textMeshProUGUI.text = tMP_InputField.text;
        PlayerPrefs.Save();
    }
}
