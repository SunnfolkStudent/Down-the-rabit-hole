using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,
            .4f);
        Debug.DrawRay(transform.position, Vector3.down, Color.red);


        if (hit == false) return;

        if (hit.transform.CompareTag("Enemy"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 8);
            Destroy(hit.transform.gameObject);
        }
    }
}
