using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void VolumeOff()
    {
        AudioListener.pause = true;

        AudioListener.volume = 0;
    }

    public void VolumeOn()
    {
        AudioListener.pause = false;

        AudioListener.volume = 1;
    }

    
   

}
