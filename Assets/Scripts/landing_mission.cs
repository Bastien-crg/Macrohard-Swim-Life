using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landing_mission : MonoBehaviour
{
    public List<GameObject> mongolfiers;
    // Start is called before the first frame update

    public GameEvent endEvent;
   

    // Update is called once per frame
    void Update()
    {
        if (mongolfiers[0] == null && mongolfiers[1] == null && mongolfiers[2] == null)
        {
            endEvent.Raise(null, "You have completed the mission !");
        }
        


     
    }
}
