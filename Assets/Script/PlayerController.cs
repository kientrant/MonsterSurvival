using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 3f;
    private Rigidbody2D rb2D;
    private Vector2 movement;
    [SerializeField] private GameObject playeyBody;
    private Animator animatorPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animatorPlayer = playeyBody.GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
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

    private void WalkAnimation(bool isWalk)
    {
        
        animatorPlayer.SetBool("isWalk", isWalk);
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
