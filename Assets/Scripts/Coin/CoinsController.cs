using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")){
            Player player = collision.gameObject.GetComponent<Player>();
            player.coinSkor += 10;
            gameObject.SetActive(false);
        }
    }
}
