using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent (typeof (Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D body2D;

    BoxCollider2D box2D;
    CircleCollider2D cir2D;

    public float playerSpeed;
    public bool isGrounded;

    public float jumpPower;
    public float doubleJumpPower;

    public bool canDoubleJump;

    public TextMeshProUGUI textMesh;

    public TextMeshProUGUI textMeshSkor;

    Transform groundCheck;
    const float GroundChechkRadius = 0.2f;
    public LayerMask groundLayer;

    public bool playerTurn = true;

    Animator playerAnimController;

    public int playerHealth = 100 ;
    public int currentPlayerHealth;
    public bool isHurt;

    public bool isDead;

    public float deadForce;

    public int totalSkor;

    public int skor;
    public int coinSkor;

    GiveDamage giveDamage;

    void Start()
    {
        //Playerin baglanmasi
        body2D = GetComponent<Rigidbody2D>();
        //Animator Controllerin baglanmasi
        playerAnimController = GetComponent<Animator>();
        //Playerin yer cekimi
        body2D.gravityScale = 20;
        //Z rotation donduruldu. Player baska objelerin icine girmesini engeller
        body2D.freezeRotation = true;
        //Playerin
        body2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //Playerin x eksenindeki hareket hizi
        playerSpeed = 14;
        //Playerin y eksenindeki hareket gucu
        jumpPower = 2300;
        //Playerin ikinci ziplamasi
        doubleJumpPower = 50;
        //Playerin ayagindaki component. Playerin yerde veya havada olmasi kontrol ediliyor
        groundCheck = transform.Find("GroundCheck");
        //Playere can ata
        currentPlayerHealth = playerHealth;

        giveDamage = FindObjectOfType<GiveDamage>();

        deadForce = 2.1f;

        box2D = GetComponent<BoxCollider2D>();
        cir2D = GetComponent<CircleCollider2D>();


        totalSkor = 0;
        skor = 0;
        coinSkor = 0;
    }

    void Update()
    {
        skor = (int)transform.position.x + 30;
        totalSkor = skor + coinSkor; 
        textMesh.text = "Skor : " + totalSkor.ToString();
        updateAnimations();
        reduceHealth();
        if (currentPlayerHealth <= 0 || transform.position.y < -7)
        {
            isDead = true;
            textMeshSkor.text = "Oyun Skorunuz : " + totalSkor;
        }
       killPlayer();
    }


    //Fremater'dan bağımsız olarak çalışır. Fizik ile ilgili kodlar buraya 
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundChechkRadius, groundLayer);

        float horizontal = Input.GetAxis("Horizontal"); 
        //float vertical = Input.GetAxis("Vertical");

        //Playerin yeni konum ve hizina vektorel2d ile toplaniyor.Player hareket ediyor
        //body2D.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed);
        body2D.velocity = new Vector2(horizontal * playerSpeed, body2D.velocity.y);

        turning(horizontal);
            
    }
    
    public void jump()
    {
        //Playerin gucune ekleme yapilir. Zimplamada sadece y ekseninde vektorel ekleme yapilir.
        body2D.AddForce(new Vector2(0, jumpPower));
    }

    public void doubleJump()
    {
        //Playerin ikinci kez ziplamada y eksenine sert vektorel ekleme yapilir.
        body2D.AddForce(new Vector2(0, doubleJumpPower), ForceMode2D.Impulse);
    }

    public void turning(float h)
    {
        if(h>0 && !playerTurn || h<0 && playerTurn)
        {
            playerTurn = !playerTurn;

            Vector2 currentScale = transform.localScale;

            currentScale.x *= -1;

            transform.localScale = currentScale;
        }
     
    }

    public void updateAnimations()
    {
        //Player hareket ediyorsa animosyonu degistirir.
        playerAnimController.SetFloat("VelocityX", Mathf.Abs(body2D.velocity.x));
        playerAnimController.SetBool("isGrounded", isGrounded);
        playerAnimController.SetFloat("VelocityY", Mathf.Abs(body2D.velocity.y));
        playerAnimController.SetBool("isDead", isDead);
    }

    public void reduceHealth()
    {
        if (isHurt)
        {
            currentPlayerHealth -= giveDamage.damage;
            isHurt = false;
        }
    }

    public void killPlayer()
    {
        if (isDead)
        {
            totalSkor = (int)transform.position.x % 20;
            isHurt = false;
            body2D.AddForce(new Vector2(0, deadForce), ForceMode2D.Impulse);
            body2D.drag = Time.deltaTime * 100;
            deadForce -= Time.deltaTime * 9;
            body2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            box2D.enabled = false;
            cir2D.enabled = false;
        }  
        
    }

}
