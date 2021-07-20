using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }


    void Update()
    {
        //Oyuncu 'space' tusuna bastiysa ve player yerde ise zipla
        if (Input.GetButtonDown("Jump") && player.isGrounded)
        {
            player.jump();
            player.canDoubleJump = true;

        }
        else if(Input.GetButtonDown("Jump") && !player.isGrounded && player.canDoubleJump)
        {
            player.doubleJump();
            player.canDoubleJump = false;
        }
    }
}
