using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    float colliderRadius ;
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject halfrock1;

    // Start is called before the first frame update
    void Start()
    {
        
        
        //get asteriod
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;


        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
        Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        AudioManager.Play(AudioClipName.AsteroidHit);
        Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Instantiate<GameObject>(halfrock1, transform.position, Quaternion.identity);
        Instantiate<GameObject>(halfrock1, transform.position, Quaternion.identity);
        
        

    }
}
