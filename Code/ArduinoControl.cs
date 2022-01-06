using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoControl : MonoBehaviour
{	
    public int duration = 0;
    public int force = 0;
    public int vibration_intensity;
    public int vibration_duration;

    private ArduinoBasic arduinoBasic;
    // Start is called before the first frame update
    void Start()
    {
        arduinoBasic = this.GetComponent<ArduinoBasic>();
        
    }

    // Update is called once per frame
    void Update()
    {	
     	if(Input.GetKeyDown(KeyCode.Space)){
     		Debug.Log("space is pressed");
     		Fire();
     	}
    }

    public void SetDuration(int duration){
        if (duration < 0 || duration > 4000)
            return;
    	this.duration = duration;
    }

    public void SetForce(int force){
        if (force < 0 || force > 255)
            return;
    	this.force = force;
    }


    public int GetDuration(){
        return duration;
    }

    public int GetForce(){
        return force;
    }

    public void SendConfig(){

        arduinoBasic.ArduinoWrite(string.Format("c{0:d3}{1:d4}", force, duration));
    }

    public void ForceFeedback(){
        arduinoBasic.ArduinoWrite("f");
    }
	public void VibeFeedback(){
        arduinoBasic.ArduinoWriteVib(string.Format("{0:d3} {0:d3} ", vibration_duration, vibration_intensity));
	}
}
