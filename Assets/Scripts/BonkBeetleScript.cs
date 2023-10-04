using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonkBeetleScript : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float raycastOffset;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    [SerializeField] private Transform fallCheckPoint;
    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D _hit;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    { _rigidbody2D.velocity = new Vector2(
        moveSpeed * transform.localScale.x, 
        _rigidbody2D.velocity.y); 
    }

    private void LateUpdate()
    {
        if (DetectedPlayer())
        {
            _hit.transform.GetComponent<PlayerHealthManager>().TakeDamage();;
        }
        if (DetectedWallOrFall() || DetectedPlayer())
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
        }
        
    }
    
    private bool DetectedWallOrFall()
    {
        // Origin, Direction, Distance, PhysicsLayer
        return 
            Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastOffset), 
                Vector2.right * transform.localScale, 1.2f,whatIsGround) 
            || 
            !Physics2D.Raycast(fallCheckPoint.position, Vector2.down,
                1f, whatIsGround);
    }
    

    private bool DetectedPlayer()
    {
        _hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastOffset),
            Vector2.right * transform.localScale, 1.8f, whatIsPlayer );
        return _hit;
    }
}