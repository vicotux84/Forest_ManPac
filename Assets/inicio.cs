using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicio : MonoBehaviour{
  
    void Awake(){
		Screen.SetResolution(1024, 600, false);
		QualitySettings.vSyncCount = 1;
    }
}
