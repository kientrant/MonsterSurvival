using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    private Rigidbody2D rb2D;
    private Vector2 movement;
    [SerializeField] private GameObject playeyBody;
    private Animator animatorPlayer;
    private string PlayerClass;
    private AudioSource[] audioSources;

    //For Static
    public static PlayerData playerData;
    public static int exp;
    public static int heath;
    public static int level;


    //inPlayer
    public int[] ExpScale = { 100, 150, 225, 300, 400, 534, 712, 949, 1265, 1686, 2248, 2997, 3996, 5328, 7104, 9471, 12628, 16837, 22450, 29933, 39910, 53214, 70951, 94602, 126135, 168180, 224240, 298987 };
    private static int currentExp = 0;
    private static int thisLevel = 0;
    const int EXP_PER_ACTION = 10;



    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animatorPlayer = playeyBody.GetComponent<Animator>();
        audioSources = gameObject.GetComponents<AudioSource>();


        rb2D.mass = 10000000f;
        Cursor.visible = false;
        walkSpeed = playerData.Dexterity;
        heath = playerData.Heart;
        exp = 0;
        thisLevel = 0;
        currentExp = 0;
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            WalkAnimation(true);
        } else
        {
            WalkAnimation(false);
        }
        
    }

    private void LateUpdate()
    {
        ExpBar.currentValue = currentExp;
        ExpBar.maxValue = ExpScale[thisLevel];

        HeartBar.currentValue = heath;
        HeartBar.maxValue = playerData.Heart;

        LevelUI.Level = thisLevel;
    }

    public void upgrade()
    {
        walkSpeed = playerData.Dexterity;
    }

    private void WalkAnimation(bool isWalk)
    {
       if (isWalk)
        {
            animatorPlayer.Play("Player.Walk");
        } else
        {
            animatorPlayer.Play("Player.Idle");
        }
    }

    public void GetDamege(int damege)
    {
        heath -= damege;
    }

    private void GetExp(int exp)
    {
        currentExp += exp;
        Debug.Log(currentExp.ToString());
        if (currentExp >= ExpScale[thisLevel])
        {
            thisLevel += 1;
            Debug.Log(thisLevel);
            currentExp = 0;
        }
    }

    private void GetCoin(int coin)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name);
        Collider2D hit = collision.collider;
        if (hit.gameObject.CompareTag("DropItem"))
        {
            
            if (hit.gameObject.name.Contains("Exp"))
            {
                GetExp(EXP_PER_ACTION);
                GameObject.Destroy(hit.gameObject);
                audioSources[0].Play();

            }
            if (hit.gameObject.name.Contains("Coin"))
            {
                GameObject.Destroy(hit.gameObject);
                audioSources[0].Play();
            }

        }
    }

    public void Flip(bool isFlip)
    {
        if (isFlip) {
            playeyBody.transform.localScale = new Vector3(-1,1);
        } else
        {
            playeyBody.transform.localScale = new Vector3(1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement.normalized * walkSpeed * Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        
    }
}
