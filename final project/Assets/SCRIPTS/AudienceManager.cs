using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{

    public GameObject audienceMember;
    public GameObject[] audienceSpawns;
    public Transform holder;

    // Start is called before the first frame update
    void Start()
    {
        holder = GameObject.Find("CrowdPoints").transform;
        audienceSpawns = GameObject.FindGameObjectsWithTag("CrowdSpawn");
        
        
        for (int i = 0; i < audienceSpawns.Length; i++)
        {
            float coinFlip = Random.Range (0.0f, 1.0f);
            
            if (coinFlip >= 0.3f)
            {
                GameObject crowdMember = Instantiate(audienceMember, audienceSpawns[i].transform);
                crowdMember.transform.parent = holder;
            }
        }        
      
        
        
    }


}
