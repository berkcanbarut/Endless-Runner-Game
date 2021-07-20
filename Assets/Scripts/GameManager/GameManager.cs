using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            //fonksiyonu cagirmadan once 2 saniye bekle ve calistir.
            Invoke("restartGame", 2);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}
