using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{


    public Vector3 centre;
    public Vector3 size;
    public GameObject block;
    public int noOfBlocks;
    public Color[] theseColors;
    Vector3 spawnPos;
    Transform holder;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        holder = GameObject.Find("SoundTrash").transform;
        gameManager = GameObject.Find("manager").GetComponent<GameManager>();
        
        for (int i = 0; i < noOfBlocks; i++)
        {
            spawnPos = (transform.localPosition + centre) + new Vector3 (Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject blockObj = Instantiate(block, spawnPos, Quaternion.identity);
            blockObj.transform.GetComponent<Renderer>().material.color = theseColors[Random.Range(0,theseColors.Length)];
            blockObj.transform.parent = holder;
        }
        
        gameManager.BlockAmount = noOfBlocks;
        
    }
    
    void OnDrawGizmosSelected() {
        Gizmos.color = new Color (1,0,0,0.5f);
        Gizmos.DrawCube(transform.localPosition + centre, size);   


    }
}
    
    
