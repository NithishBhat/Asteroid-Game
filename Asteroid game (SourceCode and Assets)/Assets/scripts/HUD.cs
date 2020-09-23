using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text timetext;
    [SerializeField]
    GameObject spaceship;
     float spaceshiptime;
    const string prefix = "TIME: ";
    public static bool dead=false;
    // Start is called before the first frame update
    void Start()
    {
       
        timetext.text = spaceshiptime.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            spaceshiptime = spaceshiptime + Time.deltaTime;
            timetext.text = prefix + spaceshiptime.ToString();
        }
    }
   
}
 
