using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class ArduinoBasic : MonoBehaviour {
    private SerialPort arduinoStream;
    private SerialPort arduinoVib;
    public string port;
    public string portVib;
    private Thread readThread; // 宣告執行緒
    private Thread readVibThread;
    public string readMessage;
    bool isNewMessage;

    void Start () {
        if (port != "") {
            arduinoStream = new SerialPort (port, 115200); //指定連接埠、鮑率並實例化SerialPort
            arduinoStream.ReadTimeout = 10;
            try {
                arduinoStream.Open (); //開啟SerialPort連線
                readThread = new Thread (new ThreadStart (ArduinoRead)); //實例化執行緒與指派呼叫函式
                readThread.Start (); //開啟執行緒
                Debug.Log ("SerialPort開啟連接");
            } catch (System.Exception e){
                Debug.Log ("SerialPort連接失敗");
                Debug.Log(e.Message);
            }
        }
        if (portVib != "")
        {
            arduinoVib = new SerialPort(portVib, 115200);
            arduinoVib.ReadTimeout = 10;
            try
            {
                arduinoVib.Open();
                //readVibThread = new Thread(new ThreadStart(ArduinoReadVib));
                //readVibThread.Start();
                Debug.Log("SerialPortVib Open");
            }
            catch(System.Exception e)
            {
                Debug.Log("SerialPort Vib Fail To Open");
                Debug.Log(e);
            }
        }
    }
    void Update () {
        if (isNewMessage) {
            Debug.Log (readMessage);
        }
        isNewMessage = false;
    }
    private void ArduinoRead () {
        while (arduinoStream.IsOpen) {
            try {
                
                readMessage = arduinoStream.ReadLine(); // 讀取SerialPort資料並裝入readMessage
                isNewMessage = true;
             
            } catch (System.Exception e) {
                Debug.LogWarning (e.Message);
            }
        }
    }
    private void ArduinoReadVib()
    {
        while (arduinoVib.IsOpen)
        {
            try
            {

                readMessage = arduinoVib.ReadLine(); // 讀取SerialPort資料並裝入readMessage
                isNewMessage = true;

            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }
    public void ArduinoWrite (string message) {
        Debug.Log (message);
      
        if (arduinoStream.IsOpen)
        {
            try
            {
                arduinoStream.Write(message);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void ArduinoWriteVib (string message)
    {
        if (arduinoVib.IsOpen)
        {
            try
            {
                arduinoVib.Write(message);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }
    void OnApplicationQuit () {
        if (arduinoStream != null) {
            if (arduinoStream.IsOpen) {
                arduinoStream.Close ();
            }
        }
        if (arduinoVib != null)
        {
            if (arduinoVib.IsOpen)
            {
                arduinoVib.Close();
            }
        }
    }

}