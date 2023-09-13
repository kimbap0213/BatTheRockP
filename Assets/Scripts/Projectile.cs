using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(_rigidbody2D.velocity);
    }
    public void SetInitialVelocity(Vector2 velocity)
    {
        Debug.Log(velocity.ToString());
        if(_rigidbody2D == null)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        _rigidbody2D.velocity = velocity;
    }
}
