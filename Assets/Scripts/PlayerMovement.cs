using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpSpeed = 12f;
    private Vector2 _desiredVelocity;

    [Header("CoyoteTime")]
    public float coyoteTime = 0.02f;
    public float coyoteTimeCounter;

    [Header("JumpBuffer")] 
    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;
    
    [Header("Acceleration")] 
    public float accelerationTime = 0.02f;
    public float groundFriction = 0.03f;
    public float airFriction = 0.005f;
    
    [Header("isGrounded")]
    public LayerMask whatIsGround;

    [Header("Audio")]
    public AudioClip[] jumpClip;
    
    
    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private InputManager _input;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private PlayerHealthManager _healthManager;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputManager>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _healthManager = GetComponent<PlayerHealthManager>();
    }

    private void Update()
    {

        if (_healthManager.lives <= 0) return;
        _desiredVelocity = _rigidbody2D.velocity;

        if (_input.moveDirection.x != 0)
        {
            _spriteRenderer.flipX = _input.moveDirection.x < 0;
        }


        if (IsPlayerGrounded())
        { coyoteTimeCounter = coyoteTime; }
        else
        { coyoteTimeCounter -= 1 * Time.deltaTime; }

        if (_input.jumpPressed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= 1 * Time.deltaTime;
        }
        
        if (_input.jumpPressed && coyoteTimeCounter > 0)
        {
            //_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            _desiredVelocity.y = jumpSpeed;
            jumpBufferCounter = 0f;
            int random;
            random = Random.Range(0, jumpClip.Length);
            _audioSource.PlayOneShot(jumpClip[random]);
        }
        
        if (_input.jumpReleased && _desiredVelocity.y > 0f)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.2f);
            _desiredVelocity.y *= 0.5f;
            coyoteTimeCounter = 0f;
        }

        _rigidbody2D.velocity = _desiredVelocity;
    }
    
    private void FixedUpdate()
    {
        if (_healthManager.lives <= 0) return;
        
        if (_input.moveDirection.x != 0)
        {
            _desiredVelocity.x = Mathf.Lerp(
                _desiredVelocity.x, moveSpeed *_input.moveDirection.x,accelerationTime);
        }
        else
        {
            _desiredVelocity.x = Mathf.Lerp(
                _desiredVelocity.x, 0f, IsPlayerGrounded() ? groundFriction : airFriction);  
        }

        _rigidbody2D.velocity = _desiredVelocity;
    }

    public bool IsPlayerGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, whatIsGround);
    }
}