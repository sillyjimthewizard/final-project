using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Tweening : MonoBehaviour
{

    public GameObject Cube;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Cube.transform.DOScale(new Vector3(1.25f, 1.5f, 1), 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        
        
        
        //button.GetComponent<RectTransform>().DOAnchorPos (new Vector2 (0, 0), 1f).SetEase(Ease.InOutQuart);
             
        
    }
    
    
    public void PressBtn()
    {
        //button.GetComponent<RectTransform>().DOAnchorPos (new Vector2 (0, 594), 1f).SetEase(Ease.InOutQuart);
    }


}
