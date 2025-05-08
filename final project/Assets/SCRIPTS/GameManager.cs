using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject triHoops;

    public InvadersManager spawnage;

    public GameObject Hoops;
    public GameObject invaderz;
 
    public GameObject Ball;

    public GameObject bricks;
    [SerializeField]private int GameState; //0 = StartGameUX, 1 = Timetrial, 2 = BrickBreaker, 3 = Space Invader, 4 = HoopShoot, 5 = End Round, 6 = Game Over


    [SerializeField]private int RoundState = 0;


    // Start is called before the first frame update
    void Start()
    {
        Hoops = GameObject.Find("Hoops");
        invaderz = GameObject.Find("InvaderManager");
        bricks = GameObject.Find("BlockSpawner");
        //Hoops.SetActive(false);
        GameState = 0;
        

        
    }

    public void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            GameState = 4;
            StartGame(GameState);
        }
        if (Input.GetKeyDown("u"))
        {
            GameState = 3;
            StartGame(GameState);
        }
        if (Input.GetKeyDown("i"))
        {
            GameState = 2;
            StartGame(GameState);
        }
        if (Input.GetKeyDown("o"))
        {
            GameState = 1;
            StartGame(GameState);
        }
        if (Input.GetKeyDown("r"))
        {
            GameObject ball = Instantiate(Ball, new Vector3(-6, -0.54f,33), Quaternion.AngleAxis(180, Vector3.right));
        }

    }



    void PlayRound()
    {
        if (RoundState == 0)
        {
            GameState = 1;
            RoundState = 1;
        } 
        else 
        {
            GameState = (Random.Range (2, 5));
            RoundState = 0;
        }
        
        StartGame(GameState);
        
    }
    
    void StartGame(int gameState)
    {
        
        if (GameState == 1) 
        {
            //Start Timetrial
            Hoops.SetActive(false);
            bricks.SetActive(false);
            invaderz.SetActive(false);
        } 
        else if (GameState == 2)
        {
            Hoops.SetActive(false);
            //Start BrickBreaker
            invaderz.SetActive(false);
            bricks.SetActive(true);
        }
        else if (GameState == 3)
        {
            Hoops.SetActive(false);
            bricks.SetActive(false);
            invaderz.SetActive(true);
            

            //Start Space Invader
        }
        else if (GameState == 4)
        {
            //Start HoopShoot
            //Hoops.SetActive(true);
            Instantiate(triHoops,transform.position,Quaternion.identity);
            bricks.SetActive(false);
            invaderz.SetActive(false);
        }
        
        
    }
    
    
    
    
    
    
    
    

}
