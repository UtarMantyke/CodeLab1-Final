using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleForDog : MonoBehaviour
{
    public AudioClip Woof;
    private AudioSource DogAudio;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            GameManager.instance.Score++;
            
            GameObject newHearts = Instantiate(Resources.Load<GameObject>("Prefabs/Hearts"));
            newHearts.transform.position = gameObject.transform.position;
            
            DogAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
            DogAudio.clip = Woof;
            DogAudio.Play();
            
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Cat"))
        {
            GameManager.instance.HP--;
            
            
            GameObject newAngry = Instantiate(Resources.Load<GameObject>("Prefabs/Angry"));
            newAngry.transform.position = gameObject.transform.position;
            
            Destroy(gameObject);
        }
    }
}
