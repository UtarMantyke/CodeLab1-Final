using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleForCat : MonoBehaviour
{
    public AudioClip Meow;
    private AudioSource CatAudio;
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
        if (other.gameObject.CompareTag("Cat"))
        {
            GameManager.instance.Score++;
            
            GameObject newHearts = Instantiate(Resources.Load<GameObject>("Prefabs/Hearts"));
            newHearts.transform.position = gameObject.transform.position;
            
            CatAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
            CatAudio.clip = Meow;
            CatAudio.Play();
            
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Dog"))
        {
            GameObject newAngry = Instantiate(Resources.Load<GameObject>("Prefabs/Angry"));
            newAngry.transform.position = gameObject.transform.position;
            
            Destroy(gameObject);
        }
    }
}
