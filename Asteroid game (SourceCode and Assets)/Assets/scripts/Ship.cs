using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject bulletprefab;
    
    // thrust and rotation support
    Rigidbody2D rb2D;
    Rigidbody2D bullet;
    Vector2 thrustDirection = new Vector2(0,1);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 180;

    // screen wrapping support
    float colliderRadiusShip;
    float colliderRadiusBullet;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
        colliderRadiusShip = GetComponent<CircleCollider2D>().radius;
        bullet = bulletprefab.GetComponent<Rigidbody2D>();

    }
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0) {
             // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            //adding 90 degree in rads because of my sprite orentation
            zRotation = (float)(zRotation+1.5708);
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);

            
        }

        //shoot logic if left control is clicked;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            AudioManager.Play(AudioClipName.PlayerShot);
            GameObject bullet = Instantiate<GameObject>(bulletprefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(190 * thrustDirection,ForceMode2D.Force);
            
        }
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        AudioManager.Play(AudioClipName.PlayerDeath);
        Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        HUD.dead=true;

    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            rb2D.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }
    }

    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + colliderRadiusShip < ScreenUtils.ScreenLeft ||
            position.x - colliderRadiusShip > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadiusShip > ScreenUtils.ScreenTop ||
            position.y + colliderRadiusShip < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }
    
}
