using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]private int GameState; //0 = StartGameUX, 1 = Timetrial, 2 = BrickBreaker, 3 = Space Invader, 4 = HoopShoot, 5 = End Round, 6 = Game Over


    [SerializeField]private int RoundState = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameState = 0;
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
        } 
        else if (GameState == 2)
        {
            //Start BrickBreaker
        }
        else if (GameState == 3)
        {
            //Start Space Invader
        }
        else if (GameState == 4)
        {
            //Start HoopShoot
        }
        
        
    }
    
    
    
    
    
    
    
    

}
