using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D[] asteriods = new Rigidbody2D[3];
    // Start is called before the first frame update
    void Start()
    {
        // storing 4 spawn location centers top bottom left and right
        Vector3[] location = new Vector3[4];
        location[0] = new Vector3(0, ScreenUtils.ScreenTop, 0);
        location[1] = new Vector3(0, ScreenUtils.ScreenBottom, 0);
        location[2] = new Vector3(ScreenUtils.ScreenLeft,0, 0);
        location[3] = new Vector3(ScreenUtils.ScreenRight,0, 0);

        for (int i = 0; i <4; i++)
        {
            int y = Random.Range(0, 3);
            Rigidbody2D asteriod = Instantiate(asteriods[y]) as Rigidbody2D;
            asteriod.transform.position = location[i];
        }
        
    }

  
}
