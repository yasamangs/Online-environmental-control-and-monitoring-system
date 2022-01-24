
#include <ESP8266WiFi.h>
#include <FirebaseArduino.h>
#include <ArduinoJson.h>
#include <ESP8266HTTPClient.h>
#include "DHT.h"
#include <NTPClient.h>
#include <WiFiUdp.h>

//----------------------------------------SSID and Password of your WiFi router.
const char* ssid = "sample"; //--> Your wifi name or SSID.
const char* password = "sample"; //--> Your wifi password.
//----------------------------------------
#define FIREBASE_HOST "sara-yasaman-project-default-rtdb.firebaseio.com" //--> URL address of our Firebase Realtime Database.
#define FIREBASE_AUTH "AtGr1OHRlHJaE1j34hCMdSiVr7IiJIpZBRXbEEwW" //--> Our firebase database secret code.
#define ON_Board_LED 2  //--> Defining an On Board LED, used for indicators when the process of connecting to a wifi router

#define LED_D8 15 //--> Defines an LED Pin. D8 = GPIO15

#define DHTTYPE DHT11 //--> Defines the type of DHT sensor used (DHT11, DHT21, and DHT22), in this project the sensor used is DHT11.

//----------------------------------------Adjust the UTC
// You need to adjust the UTC offset for your timezone in milliseconds. 
// Here are some examples for different timezones :
// > For Iran (UTC +3.30) : 3.5 * 60 * 60 : 12600

// This is Our UTC adjustment calculation : 

const long utcOffsetInSeconds = 12600;
//----------------------------------------

//----------------------------------------Define NTP Client to get time
WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP, "pool.ntp.org");
//----------------------------------------

const int DHTPin = 5; //--> The pin used for the DHT11 sensor is Pin D1 = GPIO5
DHT dht(DHTPin, DHTTYPE); //--> Initialize DHT sensor, DHT dht(Pin_used, Type_of_DHT_Sensor);

unsigned long previousMillis = 0;        //--> will store last time was updated
const long interval = 1000;           //--> interval

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  delay(500);

  dht.begin();  //--> Start reading DHT11 sensors
  delay(500);
WiFi.begin(ssid, password); //--> Connect to your WiFi router
  Serial.println("");
    
  pinMode(ON_Board_LED,OUTPUT); //--> On Board LED port Direction output
  digitalWrite(ON_Board_LED, HIGH); //--> Turn off Led On Board

  pinMode(LED_D8,OUTPUT); //--> LED port Direction output
  digitalWrite(LED_D8, LOW); //--> Turn off Led

  //----------------------------------------Wait for connection
  Serial.print("Connecting");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    //----------------------------------------Make the On Board Flashing LED on the process of connecting to the wifi router.
    digitalWrite(ON_Board_LED, LOW);
    delay(250);
    digitalWrite(ON_Board_LED, HIGH);
    delay(250);
    //----------------------------------------
  }
  //----------------------------------------
  digitalWrite(ON_Board_LED, HIGH); //--> Turn off the On Board LED when it is connected to the wifi router.
  //----------------------------------------If successfully connected to the wifi router, the IP Address that will be visited is displayed in the serial monitor
  Serial.println("");
  Serial.print("Successfully connected to : ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
  Serial.println();
  //----------------------------------------

  //----------------------------------------Firebase Configuration.
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
  //----------------------------------------
  
  //----------------------------------------Initialize a NTPClient to get time
  timeClient.begin();
  timeClient.setTimeOffset(utcOffsetInSeconds);
  //----------------------------------------
  delay(1000);
}
void loop() {
  // put your main code here, to run repeatedly:
  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis; //--> save the last time
  
    //----------------------------------------Update and send data every 5 seconds based on time.
    timeClient.update();   
    int everyfive = timeClient.getSeconds();
    
    if (everyfive % 5 == 0) { //--> This means that NodeMCU sends and gets data at 0,5,10,15,20 seconds and so on.
      unsigned long epochTime = timeClient.getEpochTime();
      struct tm *ptm = gmtime ((time_t *)&epochTime);
  
      int monthDay = ptm->tm_mday; 
      int currentMonth = ptm->tm_mon+1;
      int currentYear = ptm->tm_year+1900;
      String strmonthDay;
      String strcurrentMonth;

      if (monthDay <10) {
        strmonthDay = "0" + String(monthDay);
      } else {
        strmonthDay = String(monthDay);
      }

      if (currentMonth <10) {
        strcurrentMonth = "0" + String(currentMonth);
      } else {
        strcurrentMonth = String(currentMonth);
      }
  
      String currentDate = strmonthDay + "-" + strcurrentMonth + "-" + String(currentYear);
      Serial.print("Current Date: ");
      Serial.print(currentDate);
  
      String currentTime = timeClient.getFormattedTime();
      Serial.print("  Current Time: ");
      Serial.println(currentTime);  
      //----------------------------------------Send Time Data to the Firebase Realtime Database.
      Firebase.setString("InternetEngineeringProject/Time",currentTime); //--> Command or code for sending Time Data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Temperature failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      //----------------------------------------
  
      Serial.println("Sending Time Data Successfully");
      Serial.println();
      //----------------------------------------Reading Temperature and Humidity
      // Reading temperature or humidity takes about 250 milliseconds!
      // Sensor readings may also be up to 2 seconds 'old' (its a very slow sensor)
      int h = dht.readHumidity(); //--> Read humidity.
      float t = dht.readTemperature(); //--> Read temperature as Celsius (the default). 
      // float tf = dht.readTemperature(true); //--> // Read temperature as Fahrenheit (isFahrenheit = true)
      
      // Check if any reads failed and exit early (to try again).
      if (isnan(h) || isnan(t)) {
        Serial.println(" Failed to load DHT sensor !");
        delay(1000);
        return;
      }
      //----------------------------------------
    
      Serial.print(F("Humidity: "));
      Serial.print(h);
      Serial.print(F("%  Temperature: "));
      Serial.print(t);
      Serial.println(F("°C "));
    
      String strHum = String(h); //--> Convert Humidity value to String data type.
      String strTem = String(t); //--> Convert Temperature values to the String data type.
      }
      //----------------------------------------
          //----------------------------------------Send Humidity data to the Firebase Realtime Database.
      Firebase.setString("InternetEngineeringProject/Humidity",strHum); //--> Command or code for sending Humidity data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Humidity failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      //----------------------------------------
    
      //----------------------------------------Send Temperature data to the Firebase Realtime Database.
      Firebase.setString("InternetEngineeringProject/Temperature",strTem); //--> Command or code for sending Temperature data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Temperature failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      //----------------------------------------
      Serial.println("Sending DHT11 Sensor Data Successfully");
      Serial.println();

      //----------------------------------------Sending DHT11 Sensor Data, Time Data and Date Data for Data Log.
      String DateAndTime = currentDate + "_" + currentTime;
 Firebase.setString("DHT11Database/" + DateAndTime + "/_Date",currentDate); //--> Command or code for sending Date data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Date failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      Firebase.setString("DHT11Database/" + DateAndTime + "/_Time",currentTime); //--> Command or code for sending Time data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Time failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      Firebase.setString("DHT11Database/" + DateAndTime + "/_Humidity",strHum); //--> Command or code for sending Humidity data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Humidity failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      Firebase.setString("DHT11Database/" + DateAndTime + "/_Temperature",strTem); //--> Command or code for sending Temperature data in the form of a String data type to the Firebase Realtime Database.
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("setting Temperature failed :");
          Serial.println(Firebase.error()); 
          delay(500);
      }
      //----------------------------------------
      Serial.println("Sending Date, Time and DHT11 Sensor Data Successfully");
      Serial.println();
      //----------------------------------------Retrieve data from the Firebase Realtime Database.
      String getData = Firebase.getString("InternetEngineeringProject/LightState");
      // Conditions for handling errors.
      if (Firebase.failed()) {
          Serial.print("Getting /LightState failed :");
          Serial.println(Firebase.error()); 
          delay(500); 
      }
      //----------------------------------------
    
    }   
  }
