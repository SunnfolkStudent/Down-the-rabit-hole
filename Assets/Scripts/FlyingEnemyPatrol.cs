using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingEnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float raycastOffset;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    [SerializeField] private Transform fallCheckPoint;
    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D _hit;

    private Vector2 originPosition;
    public float patrolOffset;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        originPosition = transform.position;
    }
    
    private void FixedUpdate()
    { 
        _rigidbody2D.velocity = new Vector2(moveSpeed * direction, _rigidbody2D.velocity.y); // Constant velocity
    }
    
    private int direction = 2;
    private void Update()
    {
        
        if (originPosition.x + patrolOffset > transform.position.x)
        {
            direction = 2;
        }
        else if (originPosition.x - patrolOffset < transform.position.x)
        {
            //transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            direction = -2;
        }
        
        transform.localScale = new Vector3(direction, 2f, 1f);
    }

    private void LateUpdate()
    {
        if (DetectedPlayer())
        {
            _hit.transform.GetComponent<PlayerHealthManager>().TakeDamage(); // Damage Player
            print("Kill the puny rabbit!!");
        }
        if (DetectedWall() || DetectedPlayer())
        {
            //transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f); // Turn
            direction = -direction;
        }
    }
    
    private bool DetectedWall()
    {
        // Origin, Direction, Distance, PhysicsLayer
        return
            Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastOffset),
                Vector2.right * transform.localScale, .6f, whatIsGround);
    }
    

    private bool DetectedPlayer()
    {
         _hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastOffset),
            Vector2.right * transform.localScale, .5f, whatIsPlayer );
         return _hit;
    }
}