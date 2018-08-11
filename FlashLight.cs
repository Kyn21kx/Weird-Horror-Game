using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    #region Variables
    float Power;
    float decreaseAmnt = 1.3f;
    float intensityAmnt = 0.1f;
    public Light lightSource;
    #endregion
    private void Start() {
        Power = 100f;
        lightSource = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Light>();
    }

    private void FixedUpdate() {
        Power -= decreaseAmnt * Time.fixedDeltaTime;
        Debug.Log(Power);
        
        if (Power <= 80 && Power >= 70) {
            Decrease(false);
        }
        if (Power <= 55 && Power >= 40) {
            Decrease(true);
        }
    }
    private void Decrease (bool flicker) {
        
        lightSource.intensity -= intensityAmnt * Time.fixedDeltaTime;
        if (flicker) {
            for (int i = 0; i <= 6; i++) {
                if (i % 2 == 0) {
                    System.Threading.Timer timer = new System.Threading.Timer(Blinking, 10, 1, 1000);
                }
                else {
                    
                }
            }
        }
    }
    private void Blinking (object state) {

    }


}
