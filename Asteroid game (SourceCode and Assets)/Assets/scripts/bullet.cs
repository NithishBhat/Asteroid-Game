using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
 

    Rigidbody2D bullet1;
    float colliderRadiusBullet;
    Timer bulletdeathTimer;
    // Start is called before the first frame update
    void Start()
    {
        
        bullet1 = GetComponent<Rigidbody2D>();
        colliderRadiusBullet = GetComponent<CircleCollider2D>().radius;
        bulletdeathTimer = gameObject.AddComponent<Timer>();
        bulletdeathTimer.Duration = 2;
        bulletdeathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletdeathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        
        Destroy(gameObject);

    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 bulletposition = transform.position;

        // check left, right, top, and bottom sides
        if (bulletposition.x + colliderRadiusBullet < ScreenUtils.ScreenLeft ||
            bulletposition.x - colliderRadiusBullet > ScreenUtils.ScreenRight)
        {
            bulletposition.x *= -1;
        }
        if (bulletposition.y - colliderRadiusBullet > ScreenUtils.ScreenTop ||
            bulletposition.y + colliderRadiusBullet < ScreenUtils.ScreenBottom)
        {
            bulletposition.y *= -1;
        }

        // move ship
        transform.position = bulletposition;
    }
}

   

