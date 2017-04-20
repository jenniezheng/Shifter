using UnityEngine;
using System.Collections;
namespace Shifter.OpenRoom { 
    public class MouseWithMouse : Photon.PunBehaviour {
    
	
	    void Update () {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                this.transform.position = mousePos;
            }
      
	    };

   
}
