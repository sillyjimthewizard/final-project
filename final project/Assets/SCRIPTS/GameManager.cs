using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Ball;

    public GameObject Hoops;
    public GameObject invaderz; 


    public GameObject bricks;
    [SerializeField]private int GameState; //0 = StartGameUX, 1 = Timetrial, 2 = BrickBreaker, 3 = Space Invader, 4 = HoopShoot, 5 = End Round, 6 = Game Over


    [SerializeField]private int RoundState = 0;
    
    public int BlockAmount;


    // Start is called before the first frame update
    void Start()
    {
        GameState = 0;
               
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GameObject blockGame = Instantiate(bricks, transform);
            GameState = 2;
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            GameObject hoopsGame = Instantiate(Hoops, transform);
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameObject invaderzGame = Instantiate(invaderz, transform);
        }
        if (Input.GetKeyDown(KeyCode.F8))
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
            // Put up a ui that allows you to select a game type

        } 
        else if (GameState == 2)
        {
            if (BlockAmount <= 0)
            {
                ////Puase the game
                //Put up button for end round
                //change to game state 1
                
            }
        }
        else if (GameState == 3)
        {
        
        }
        else if (GameState == 4)
        {

        }
        
        
        
    }
    
    
    
    
    
    
    
    

}
