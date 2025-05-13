using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballToSpawn;
    public GameObject Ball;

    public GameObject Hoops;
    public GameObject invaderz; 

    public bool BlockStarted, HoopsStarted, InvaderzStarted;

    public GameObject mainmenu;

    public GameObject ChooseGamer;

    public bool freezepls;

    public GameObject currentspawner;


    public GameObject bricks;
    [SerializeField]private int GameState; //0 = StartGameUX, 1 = Timetrial, 2 = BrickBreaker, 3 = Space Invader, 4 = HoopShoot, 5 = End Round, 6 = Game Over


    [SerializeField]private int RoundState = 0;
    
    public int BlockAmount;
    public int EnemyAmount; 
    public Transform realTrash;


    // Start is called before the first frame update
    void Start()
    {
        GameState = 0;

        mainmenu = GameObject.Find("Main");
        ChooseGamer = GameObject.Find("chooseGame");
        ChooseGamer.SetActive(false);
        freezepls = false;
        realTrash = GameObject.Find("RealTrash").transform;
               
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GameObject blockGame = Instantiate(bricks, transform);
            GameState = 2;
            //BlockStarted = true;
            
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            GameObject hoopsGame = Instantiate(Hoops, transform);
            GameState = 4;
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameObject invaderzGame = Instantiate(invaderz, transform);
            GameState = 3;
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            GameObject ball = Instantiate(ballToSpawn, new Vector3(-6, -0.54f,33), Quaternion.AngleAxis(180, Vector3.right));
            Ball = ball;
        }

        if (BlockAmount == 0)
        {
            freezepls = true;

        }


        if (GameState == 2){
            
            if (BlockAmount <= 0 && BlockStarted == true)
            {
                //Puase the game
                Destroy(Ball);
                Time.timeScale = 0;
                //Put up button for end round
                //change to game state 1
                mainmenu.SetActive(true);
                Debug.Log("working");
                BlockStarted = false;
                currentspawner = GameObject.Find("BlockSpawner");
                
                
            }
        }

          else if (GameState == 3)
        {
            if (EnemyAmount <= 0 && InvaderzStarted == true)
            {
                //Puase the game
                Time.timeScale = 0;
                //Put up button for end round
                //change to game state 1
                mainmenu.SetActive(true);
                Debug.Log("working");
                InvaderzStarted = false;
                currentspawner = GameObject.Find("InvaderManagger");
            }
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
    
    void StartGame(int GameState)
    {
        
        if (GameState == 1) 
        {
            // Put up a ui that allows you to select a game type

        } 
        else if (GameState == 2)
        {

        }
      
        else if (GameState == 4)
        {

        }
        
        
        
    }

    public void blockgame()
    {
        GameObject blockGame = Instantiate(bricks, transform);
        GameState = 2;
        ChooseGamer.SetActive(false);
        Time.timeScale = 1;
        GameObject ball = Instantiate(ballToSpawn, new Vector3(-6, -0.54f,33), Quaternion.AngleAxis(180, Vector3.right));
        Ball = ball;
    }
    
    
    public void invadergame()
    {
        GameObject invaderGame = Instantiate(invaderz, transform);
        GameState = 3;
        ChooseGamer.SetActive(false);
        Time.timeScale = 1;
        GameObject ball = Instantiate(ballToSpawn, new Vector3(-6, -0.54f,33), Quaternion.AngleAxis(180, Vector3.right));
        Ball = ball;
    }
    
    public void hoopgame()
    {
        GameObject hoopGame = Instantiate(Hoops, transform);
        hoopGame.transform.parent = GameObject.Find("RealTrash").transform;
        GameState = 4;
        ChooseGamer.SetActive(false);
        Time.timeScale = 1;
        GameObject ball = Instantiate(ballToSpawn, new Vector3(-6, -0.54f,33), Quaternion.AngleAxis(180, Vector3.right));
        Ball = ball;
    }

    public void gametomain()
    {
        mainmenu.SetActive(false);
        ChooseGamer.SetActive(true);

    }
    
    
    
    public void ClearTrash()
    {
        foreach (Transform child in realTrash)
        {
            Destroy(child.gameObject);
        }
    }
    
    
    
    

}
