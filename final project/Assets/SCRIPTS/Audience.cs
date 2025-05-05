using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Audience : MonoBehaviour
{

    float waitTimer;
    bool waiting;
    public Color[] theseColors;
    public float lowTime,hiTime;

    private void Start() {
        //this.transform.GetComponent<Renderer>().material.color = new Color (Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        this.transform.GetComponent<Renderer>().material.color = theseColors[Random.Range(0,theseColors.Length)];
        RandomTime();
    }


    // Update is called once per frame
    void Update()
    {
        waitTimer -= Time.deltaTime;
        
        if (waitTimer <= 0f)
        {
            StartCoroutine(PlayAnim());
        }
    }
    
    
    void RandomTime()
    {
        waitTimer = Random.Range(lowTime,hiTime);
    }
    
    
    IEnumerator PlayAnim()
    {
        RandomTime();
        
        int chooseAnim = Random.Range(0,2);
        
        if (chooseAnim == 0){
            this.transform.DOJump(transform.position, 2f, 1, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
        else if (chooseAnim == 1)
        {
            this.transform.DOShakeRotation(0.5f, 90f, 10, 90);
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
    
    
}
