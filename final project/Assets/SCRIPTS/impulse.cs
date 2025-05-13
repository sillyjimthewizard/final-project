using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulse : MonoBehaviour
{
    
    Rigidbody rig;

    public float degreesPerSecond = 2.0f;
    
    public GameManager manager;
    private SoundManager audioscript;


    public bool rotate;
    public bool rotatedelta;
    public float magnitude = 5;
    
    public AudioClip enemycollission;
    
    public GameObject hitparticle;
    public GameObject blockparticle;
    
    public Color[] theseColors;
    
    // Start is called before the first frame update
    void Start()
    {
    
       manager = GameObject.Find("manager").GetComponent<GameManager>();
       audioscript = manager.GetComponent<SoundManager>();
       
       
       
       rig=GetComponent<Rigidbody>();
       rig.AddForce(Vector3.forward*magnitude,ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate == true)
        {
            transform.rotation = Random.rotation;
        }
        
        if (rotatedelta == true)
        {
            transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
        }

    }



      public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Hoop"))
        {
          Destroy (other.gameObject);
          Destroy(other.transform.parent.gameObject);
          Debug.Log("HELP ME");
        }
   }

    public void OnCollisionEnter(Collision other)
        {
        if (other.gameObject.CompareTag ("enemy"))
        {
          //rig.AddForce(Vector3.forward*magnitude,ForceMode.Impulse); //this make the ball move faster every hit
          
          Transform tempPosition;
          tempPosition = other.transform;
          
          GameObject particleClone = Instantiate (hitparticle, tempPosition);
          particleClone.transform.parent = null;
          Gradient grad = new Gradient();
          grad.SetKeys( new GradientColorKey[] { new GradientColorKey(theseColors[Random.Range(0,theseColors.Length)], 0f), new GradientColorKey(theseColors[Random.Range(0,theseColors.Length)], 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1f, 1f), new GradientAlphaKey(1f, 1.0f) } );
          ParticleSystem ps = particleClone.GetComponent<ParticleSystem>();
          var col = ps.colorOverLifetime;
          col.color = grad;
  
          audioscript.PlaySound(enemycollission);
          
          Destroy (other.gameObject);
          
          Debug.Log("HELP ME");
          
          manager.EnemyAmount --;
          
        }
        
        if (other.gameObject.CompareTag ("block"))
        {
          //rig.AddForce(Vector3.forward*magnitude,ForceMode.Impulse); //this make the ball move faster every hit
          
          Transform tempPosition;
          tempPosition = other.transform;
          
          GameObject particleClone = Instantiate (blockparticle, tempPosition);
          particleClone.transform.parent = null;
          Gradient grad = new Gradient();
          grad.SetKeys( new GradientColorKey[] { new GradientColorKey(theseColors[Random.Range(0,theseColors.Length)], 0f), new GradientColorKey(theseColors[Random.Range(0,theseColors.Length)], 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(0.2f, 1.0f) } );
          ParticleSystem ps = particleClone.GetComponent<ParticleSystem>();
          var col = ps.colorOverLifetime;
          col.color = grad;
  
          audioscript.PlaySound(enemycollission);
          
          Destroy (other.gameObject);
          

          
          manager.BlockAmount --;
          
        }        
        

        if (other.gameObject.CompareTag ("delete"))
        {
          Destroy (gameObject);
          manager.ChooseGamer.SetActive(true);
          Destroy (manager.currentspawner);
          manager.ClearTrash();
          

        }

   }
}
