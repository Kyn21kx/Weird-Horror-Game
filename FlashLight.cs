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
        else if (Power <= 55 && Power >= 40) {
            Decrease(true);
        }
    }
    private void Decrease (bool flickering) {       
        lightSource.intensity -= intensityAmnt * Time.fixedDeltaTime;
        if (flickering)
        StartCoroutine(Blinking(true));
    }
    private IEnumerator Blinking (bool tmr) {
        int cnt = 0;
        while (tmr) {
            yield return new WaitForSeconds(0.2f);
            lightSource.enabled = false;
            yield return new WaitForSeconds(0.2f);
            lightSource.enabled = true;
            cnt++;
            if (cnt >= 5)
                break;
        }
    }


}
