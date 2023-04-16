using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ButtonItem : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public int typeId;
    public Transform modelPoint;
    public SnakeCustom snakeCustom;
    public GameObject modelGame;
    public float degreesPerSecond = 20;
    public void InitModel(GameObject _model, SnakeCustom _snakeCustom, int _id, int _typeId)
    {
        id = _id;
        typeId = _typeId;
        snakeCustom = _snakeCustom;
        modelGame = Lean.Pool.LeanPool.Spawn(_model, modelPoint);
        modelGame.transform.localPosition = Vector3.zero;
        modelGame.transform.localScale = Vector3.one;
        modelGame.transform.localRotation = Quaternion.identity;
        modelGame?.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero * 0.5f).SetEase(Ease.InOutSine);
    }
    private void Update()
    {
        modelGame.transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
    }
    void OnEnable()
    {
        if(modelGame !=null) modelGame.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero * 0.5f).SetEase(Ease.InOutSine);
    }
        public void OnclickItem()
    {
        modelGame.transform.DORewind();
        modelGame.transform.DOPunchScale(Vector3.one * 0.2f, 0.25f);
        snakeCustom.UpdateCustom(id, typeId);
    }
}
