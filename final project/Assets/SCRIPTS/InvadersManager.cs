using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InvadersManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemy2;
    public int noOfEnemies;
    Vector3 spawnPos;
    Transform holder;
    public Color[] theseColors;
    public GameObject[] theseModels;

    GameManager gameManager;
    
    
    public Vector3 centre;
    public Vector3 size;


    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("manager").GetComponent<GameManager>();
        holder = GameObject.Find("SoundTrash").transform;
      
        
          
             for (int i = 0; i < noOfEnemies; i++)
        {
            
            spawnPos = (transform.localPosition + centre) + new Vector3 (Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            
            RaycastHit hit;
            Ray ray = new Ray (spawnPos, Vector3.down);
            Physics.Raycast (ray, out hit);
            
            if (hit.collider.tag =="Ground") {
                spawnPos = hit.point;
            } else {
                return;
            }
            
            Debug.Log("HIT");

            //GameObject enemyObj = Instantiate(enemy, spawnPos, Quaternion.identity);
            //enemyObj.transform.GetComponent<Renderer>().material.color = theseColors[Random.Range(0,theseColors.Length)];
            //enemyObj.transform.parent = holder;
            enemy2 = theseModels[Random.Range(0,theseModels.Length)];
            GameObject enemyObj = Instantiate(enemy2, spawnPos, Quaternion.AngleAxis(180, Vector3.right));

            gameManager.EnemyAmount = noOfEnemies;

            gameManager.InvaderzStarted = true;
        }   
        
    }
    
    void OnDrawGizmosSelected() {
        Gizmos.color = new Color (1,0,0,0.5f);
        Gizmos.DrawCube(transform.localPosition + centre, size);   


    }
}
