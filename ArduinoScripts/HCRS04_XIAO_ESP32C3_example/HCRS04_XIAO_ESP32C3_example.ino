#include <ArduinoOSCEther.h>
#include <ArduinoOSCWiFi.h>
#include <WiFi.h>
//#include <ArduinoOsc.h>
//This is an example of the code used for the proximity sensors HC-SR04

//WiFi Connection

const char* ssid = "TP-Link_B5C4";
const char* password = "56276718";

//OSC Messages

const char* oscAddress = "/distance/3";
const char* oscIP = "192.168.0.164";
const int port = 9999;

// Define pin numbers for Sensor 
const int trigPin1 = D9; // Trigger pin for Sensor 
const int echoPin1 = D10; // Echo pin for Sensor 



// Variables for measuring distance
long duration1;
float distance3;

void setup() {
  // Initialize serial communication
  Serial.begin(115200);
  delay(20);
  
  // Start WiFi network connection
  WiFi.begin(ssid, password);


  Serial.println("");
  Serial.println("WiFi connected");


  // Set pin modes for Sensor 
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  
}

void loop() {
  // Measure distance from Sensor 1
  digitalWrite(trigPin1, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW);
  
  duration1 = pulseIn(echoPin1, HIGH);
  distance3 = (duration1 * 0.0343) / 2; // Calculate distance for Sensor 1
  
  
  // Print the distances to the Serial Monitor

/*
  Serial.print("Distance: ");
  Serial.print(distance3, 2); // Prints with 2 decimal places
  Serial.println(" cm"); // Add units for clarity
*/
  delay(70);

  //Send distance via OSC protocol

  OscWiFi.send(oscIP, port, oscAddress, distance3);  

}
