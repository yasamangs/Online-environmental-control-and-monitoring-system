## Project Overview
This repository contains the implementation details for an embedded system that monitors and controls environmental conditions remotely. The project was developed as part of an Embedded Systems Lab and focuses on a case study of a chicken farm. The system integrates hardware and software components to create a prototype for real-time monitoring and control.

## Motivation

Environmental monitoring in chicken farms is crucial to improving productivity and reducing risks. By leveraging sensors, microcontrollers, and the Internet, this project provides an online system for real-time monitoring and control.

## Features

- Environmental Sensors: Tracks temperature, humidity, and CO2 levels.
- User Interface: Provides real-time data visualization and control via a Visual Basic .NET desktop application.
- Data Storage: Utilizes Firebase Realtime Database for data storage and retrieval.
- Remote Control: Prototype actuators (e.g., LEDs) controlled via the desktop UI.

## Components

### Hardware

- **Microcontrollers:** 
  - Arduino Nano
  - NodeMCU
- **Sensors:**
  - DHT11 (Humidity and Temperature)
  - MG-811 (CO2 Gas)
  - Ultrasonic Sensor
  - Light Sensor
  - Water Level Sensor
- **Additional Components:**
  - Breadboard
  - Jumper Wires
  - 5V Relay
  - LEDs
  - Buzzer
  - 9V AC/DC Power Supply

### Software

- **Arduino IDE:** For programming microcontrollers and connecting to Firebase.
- **Firebase Realtime Database:** Stores and retrieves environmental data.
- **Visual Basic .NET:** Provides a user-friendly UI for monitoring and control.


## Setup and Installation

### System Architecture

1. **Hardware Module**
   - Microcontroller and sensors connected via breadboard.
   - Wi-Fi enabled using NodeMCU to send data to Firebase.

2. **Arduino IDE Implementation**
   - Initialize hardware components.
   - Connect to a Wi-Fi router and Firebase.
   - Write and read environmental data.
   - Exception handling for stable operation.

3. **Firebase Realtime Database**
   - Stores temperature, humidity, time, and actuator status.
   - Secured with a secret key for authenticated access.

4. **Desktop UI**
   - Graphical visualization of data.
   - Remote actuator control (on/off switches).
   - Export data to Excel.


### Hardware Setup

- Assemble components on the breadboard as per the architecture diagram.
- Connect sensors and microcontrollers using jumper wires.

### Software Configuration

- Install Arduino IDE and required libraries for sensors and Wi-Fi.
- Create a Firebase project and configure the database.
- Clone the Visual Basic .NET UI from this repository.

### Running the System

- Upload the Arduino code to the microcontroller.
- Launch the Visual Basic .NET UI application.
- Monitor and control environmental parameters remotely.

## Demo

Check out the project in action:

[download the demo video here](assets/Demo.mp4).


## Future Work

- Add relays to control fans and lamps.
- Include a dedicated monitor and protection shield.
- Integrate a buzzer and additional sensors.
- Enhance the UI and develop a mobile application.

## Authors

Nima Esmi
Yasaman Golashan
Sara Asadi

