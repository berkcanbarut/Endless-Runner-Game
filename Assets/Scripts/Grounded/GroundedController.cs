using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    public GameObject go;
    GameObject[] lastGo;
    public GameObject monster;
    GameObject[] lastMonster;
    public GameObject coin;
    GameObject[] lastCoin;
    int addPositionx;
    int addPositiony;
    int randomNumber;
    int lastRandomNumber;
    int counter;
    int monsterCounter;
    int coinCounter;
    int i,j,k;
    Vector2 pos;
    Vector2 posDefault;
    Vector2 posMonster;
    Vector2 posCoin;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        j = 0;
        k = 0;
        counter = 0;
        monsterCounter = 0;
        coinCounter = 0;
        addPositionx = 17;
        addPositiony = 6;
        lastRandomNumber = -1;
        pos = new Vector2(transform.position.x, transform.position.y);
        posMonster = new Vector2(transform.position.x, transform.position.y);
        posDefault = new Vector2(transform.position.x, transform.position.y);
        posCoin = new Vector2(transform.position.x, transform.position.y);
        lastGo = new GameObject[10];
        lastMonster = new GameObject[10];
        lastCoin = new GameObject[10];
        InvokeRepeating("removeGrounded", 6, 1.5f);
        InvokeRepeating("randomGrounded", 2, 1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void randomGrounded()
    {
        pos = posDefault;
        randomNumber = Random.Range(0, 3);
        if (lastRandomNumber == 0)
        {
            randomNumber = Random.Range(0, 2);
        }
        switch (randomNumber)
        {
            case 0:
                pos.y -= addPositiony;
                break;
            case 1:
                break;
            case 2:
                pos.y += addPositiony;
                break;
            default:
                break;
        }
        posDefault.x += addPositionx;
        lastGo[counter%10] = Instantiate(go, pos, transform.rotation);
        lastRandomNumber = randomNumber;
        counter++;
        if (Random.Range(0, 100) > 75)
        {
            posMonster = pos;
            posMonster.y += 2;
            switch (Random.Range(0, 3))
            {
                case 0:
                    posMonster.x -= 2;
                    break;
                case 1:
                    break;
                case 2:
                    posMonster.x += 2;
                    break;
                default:
                    break;
            }
            lastMonster[monsterCounter % 10] = Instantiate(monster, posMonster, transform.rotation);
            Invoke("removeMonster", 3.2f);
            monsterCounter++;
        }
        if(Random.Range(0,100) > 75)
        {
            posCoin = pos;
            posCoin.y += 7;
            switch (Random.Range(0,3))
            {
                case 0:
                    posCoin.x -= 5;
                    break;
                case 1:
                    break;
                case 2:
                    posCoin.x += 5;
                    break;
                default:
                    break;
            }
            lastCoin[coinCounter % 10] = Instantiate(coin, posCoin, transform.rotation);
            Invoke("removeCoin", 3.2f);
            coinCounter++;
        }
    }

    void removeMonster()
    {
        Destroy(lastMonster[j%10]);
        j++;        
    }

    void removeGrounded()
    {
        Destroy(lastGo[i%10]);
        i++;
    }

    void removeCoin()
    {
        Destroy(lastCoin[k % 10]);
        k++;
    }
}
