# Mixed Reality Project Master RIM UJM

Hello ! this is a mixed reality project in which we, Snati1206 and Marianne Sicari, a group of students from the Jean Monnet University have worked together.
[You can see a demo of this project if you click on this link](https://drive.google.com/file/d/11V4E1r2pe5vJfmt2Lb1gqGeB0iU6vTL_/view?usp=sharing). 
Our main idea behind this was to create an interactive Installation that mixed a **Virtual Reality World** with our **"Real World"**. In the following lines I'll share with you the main creative and technical steps.

## Arduino and ESP32

Our first consideration was how to send the data from our sensors to our computer, that's why we chose to use a [XIAO ESP32C3](https://wiki.seeedstudio.com/XIAO_ESP32C3_Getting_Started/) that could access WiFi and send UDP Messages to our MaxMsp patch and to Unity.

<img width="420" alt="image" src="https://github.com/user-attachments/assets/e3820b64-f7b3-4e97-b3a9-9dd5265c3bc6" />

>You can acces the script [here](ArduinoScripts/HCRS04_XIAO_ESP32C3_example)

## The rest was "easier"...

Once the distance from the sensors was received, we did a simple smoothing of the incoming data, and then normalized it into a signal.

<img width="280" alt="image" src="https://github.com/user-attachments/assets/1919a6d5-0180-4062-8a91-3ac484c2c63a" />

>You can acces the max patch [here](MaxReaper/SoundBase.maxpat)

## Wwise and Unity

Once the signal was smoothed, we transformed it into MIDI and OSC Messages to use the data in a creative way, that was achieved using the VR inside Unity with the sound being implemented via Wwise. The project is easily accessed in this repository.


