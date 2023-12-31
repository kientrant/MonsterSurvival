using System;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private Vector2 movement;
    [SerializeField] private GameObject playeyBody;
    private Animator animatorPlayer;
    private string PlayerClass;
    //0 is coin
    private AudioSource[] audioSources;
    public static int soundV;

    //For Static
    public static PlayerData playerData;
    public static int exp;
    public static int heath;
    public static int maxHeath;
    public static int level;
    public static int coin;
    public static int expMultiple = 1;


    //inPlayer
    public int[] ExpScale = { 100, 150, 225, 300, 400, 534, 712, 949, 1265, 1686, 2248, 2997, 3996, 5328, 7104, 9471, 12628, 16837, 22450, 29933, 39910, 53214, 70951, 94602, 126135, 168180, 224240, 298987 };
    private static int currentExp = 0;
    private static int thisLevel = 0;
    private int EXP_PER_ACTION = 10 * expMultiple;

    private float walkSpeed;
    private float depend;

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animatorPlayer = playeyBody.GetComponent<Animator>();
        audioSources = gameObject.GetComponents<AudioSource>();

        rb2D.mass = 10000000f;
        walkSpeed = playerData.Dexterity;
        heath = playerData.Heart;
        depend = playerData.Depend;
        exp = 0;
        thisLevel = 0;
        currentExp = 0;
        coin = PlayerPrefs.GetInt("Coin");
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
        walkSpeed = playerData.Dexterity;
        maxHeath = playerData.Heart;
        depend = playerData.Depend;


    }

    private void LateUpdate()
    {
        ExpBar.currentValue = currentExp;
        ExpBar.maxValue = ExpScale[thisLevel];

        HeartBar.currentValue = heath;
        HeartBar.maxValue = maxHeath;

        ExpBar.coinPlayer = coin;

        LevelUI.Level = thisLevel;

        audioSources[0].volume = soundV;

        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.Save();
    }

    public void upgradeValue()
    {

    }

    private void WalkAnimation(bool isWalk)
    {
        if (isWalk)
        {
            animatorPlayer.Play("Player.Walk");
        }
        else
        {
            animatorPlayer.Play("Player.Idle");
        }
    }

    public void GetDamege(int damege)
    {
        animatorPlayer.Play("Player.Hurt");
        heath -= (int) math.ceil(damege * depend);
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
            MainGame.isUpgrade = true;
        }
    }

    private void GetCoin(int coinIn)
    {
        coin += coinIn;
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
                GetCoin(1);
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
