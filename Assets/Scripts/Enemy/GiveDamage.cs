using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    public int damage;
    Player player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Playera zarar ver veya oldur.
            player.isHurt = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isHurt = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isHurt = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
