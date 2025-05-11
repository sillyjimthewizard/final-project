using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulse : MonoBehaviour
{
    
    Rigidbody rig;

    public float degreesPerSecond = 2.0f;
    
    public GameObject manager;

    public bool rotate;
    public bool rotatedelta;
    public float magnitude = 5;
    
    private AudioClip enemycollission;
    
    // Start is called before the first frame update
    void Start()
    {
    
       manager = GameObject.Find("manager");
       SoundManager audioscript = manager.GetComponent<SoundManager>();
       
       
       
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
          Destroy (other.gameObject);
          
          Debug.Log("HELP ME");
          
        
          
        }

        if (other.gameObject.CompareTag ("delete"))
        {
          Destroy (gameObject);
          
          Debug.Log("HELP ME");
        }

   }
}
