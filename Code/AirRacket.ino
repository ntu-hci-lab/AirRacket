#include <Wire.h>
#include "Adafruit_DRV2605.h"
int intensity = 100;
int vibe_duration = 30; 
int riseTime = 0;

int force_pin = 5;
int valve_pin_0 = 6;
int valve_pin_1 = 7;
int led_pin = 13;

//default configuration
int air_duration = 40;
int force = 0;

//
int currentMillis;
int startFireTime = 0;

Adafruit_DRV2605 drv;
void tcaselect() {
  Wire.beginTransmission(0x70);
  Wire.write(0x03);
  Wire.endTransmission();
}
void setup() {
  Serial.begin(115200);
  Serial.println("DRV test");
  Wire.begin();
  tcaselect();
  drv.begin();
  drv.useLRA();
  drv.writeRegister8(DRV2605_REG_CONTROL3, drv.readRegister8(DRV2605_REG_CONTROL3) | 0x01);
  drv.setMode(DRV2605_MODE_REALTIME);
  Serial.begin(115200);
  pinMode(force_pin, OUTPUT);
  pinMode(valve_pin_0, OUTPUT);
  pinMode(valve_pin_1, OUTPUT);
  pinMode(led_pin, OUTPUT);
}

uint8_t rtp_index = 0;
uint8_t rtp[] = {
  0x30, 100
};
void loop() {
  analogWrite(force_pin, force);
  currentMillis = millis();
  if(Serial.available()>0){
    char cmd = Serial.read();
    if(cmd == 'f'){
      fireStart(valve_pin_0);
    }
    else if(cmd == 'b'){
      fireStart(valve_pin_1);  
    }
    else if(cmd == 'v'){
      vibeStart();  
    }
    else if(cmd == 'c'){
      configForce();
    }
    else if(cmd == 'm') {
      configVibe();
    }
    //Serial.flush();
  }
}

//fire the air jet
void fireStart(int valve_pin){
  digitalWrite(valve_pin, HIGH);
  digitalWrite(led_pin, HIGH);
  delay(air_duration);
  digitalWrite(valve_pin, LOW);
  digitalWrite(led_pin, LOW);
}

void vibeStart(){
   drv.setRealtimeValue(intensity);
    delay(vibe_duration);
    drv.setRealtimeValue(0x00);
}

void configForce(){
  force = parseData();
  air_duration = parseTime();
  
  analogWrite(force_pin, force);
  
  Serial.print("Read");
  Serial.print(" f: ");
  Serial.print(force);
  Serial.print(" d: ");
  Serial.println(air_duration);
}

void configVibe(){
  intensity = parseData();
  vibe_duration = parseTime();
  Serial.print("VibeRead");
  Serial.print(" f: ");
  Serial.print(intensity);
  Serial.print(" d: ");
  Serial.println(vibe_duration);
}

int parseData(){
  String num = "";
  char c;
   for(int i = 0; i < 3; i++){
      while(true){
        if(Serial.available()){
          c = Serial.read();
          break;
        }
      }
      num += c;
   }
   return num.toInt();
}

int parseTime(){
  String num = "";
  char c;
   for(int i = 0; i < 4; i++){
      while(true){
        if(Serial.available()){
          c = Serial.read();
          break;
        }
      }
      num += c;
   }
   return num.toInt();
}
