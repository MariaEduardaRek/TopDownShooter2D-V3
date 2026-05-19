using System.Reflection.Emit;
using UnityEngine;


public class playermoviment : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Playercontrol playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private void Awake()
    {
      playerControls = new Playercontrol ();
      rb = GetComponent<Rigidbody2D>();
      myAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    void Start()
    {
        
    }


    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.moviment.move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);

    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
