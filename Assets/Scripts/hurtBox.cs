using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtBox : MonoBehaviour
{
    private PlayerHealthManager _playerHealthManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (CompareTag("Player"))
        {
            transform.GetComponent<PlayerHealthManager>().TakeDamage();;
        }

        
    }
}
