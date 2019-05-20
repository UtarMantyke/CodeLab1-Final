using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public List<GameObject> hearts;
    public GameManager GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager=GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < GameManager.HP)
            {
                
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
