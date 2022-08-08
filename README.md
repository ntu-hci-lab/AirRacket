# AirRacket: Perceptual Design of Ungrounded, Directional Force Feedback to Improve Virtual Racket Sports Experiences

Ching-Yi Tsai, I-Lun Tsai, Chao-Jung Lai, Derrek Chow, Lauren Wei, Lung-Pan Cheng, Mike Yen Chen

CHI'22 Best Paper 🏆

![](./Figures/Teaser_Figure_bordered.jpg)




### Table of Contents  
- [System Diagram](#system-diagram)
- [Racket-shaped Handheld Devices](#racket-shaped-handheld-devices)
  - [Alternative Tracking System](#alternative-tracking-system)
  - [Additional Racket Sports](#additional-racket-sports)
- [Pneumatic Control System](#pneumatic-control-system)
  - [Pneumatic System Overview](#pneumatic-system-overview)
  - [Circuit Schematic](#circuit-schematic)
  - [Control Code](#code)
    - [Arduino](#arduino)
    - [Unity](#unity) 
- [Website, Paper/Video Links and BibTeX](#reference)

<a name="system-diagram"/>

## System Diagram

![](./Figures/SystemArchitecture.jpg)

AirRacket system includes: (1) Custom-designed racket devices: Two nozzles with separate tubing mounted on sport-specific handle and shaft, and (2) Pneumatic control system: a pressure regulator controlling force magnitude and two solenoid valves controlling force direction.


<a name="racket-shaped-handheld-devices"/>

# Racket-shaped Handheld Devices

![](./Figures/RacketStructure.jpg)

Each of our handhheld devices consists of a 3D-printed handle, a carbon fiber shaft (ø14mm or ø 23mm outer-diameter), and two noise-reducing nozzles on a 3D-printed nozzle mount. 
The 3D-models in the `./3D Racket Model` folder includes:
1. Racket-shaped Handle: components with specific shapes modelled after real rackets handles with a cuboid-shaped hole for placing LRA vibrator and tunnels for low-friction polyurethane tubing (ø6mm),
2. Shaft connector: components that connect the carbon fiber stick and racket-shaped handle by clamping them (to compensate margin error due to 3D printing resolution, appplying adhesive or electrical tape "inside" the shaft connectors are recommended), and
3. Nozzle connector: components for mounting the nozzles and should be able to clamp the carbon fiber shaft (those additional branches are for adding reflective markers, but we also include file without them).

Notice: to complete the rest of the handheld device, compressed air nozzles, L-shape nozzle fittings, carbon fiber shaft, and PU tubes(ø6mm) are required. 

<a name="alternative-tracking-system"/>

### Alternative Tracking System
To be compatible with general VR systems, in `./3D Racket Model/ViveTracker Version/`, we also provides additional nozzle connectors (shaft connectors for badminton) for mounting ViveTrackers, which can be mounted as the below. However, the center-of-mass and total weight would deviate a lot with this current version. 

|                    OptiTrack                     |                         ViveTracker                          |
| :----------------------------------------------: | :----------------------------------------------------------: |
| ![](./Figures/LRA.PNG) | ![](./Figures/DevicesVive.jpg) |


<a name="additional-racket-sports"/>

### Additional Racket Sports
Besides the three racket sports (pingpong/badminton/tennis) we demonstrated and experimented in our paper, we also put some additional racket sports design in the `./3D Racket Model/Other Raccket Sports/`, including designs for baseball, hockey, golf, racquet ball, and a sword.

<img src="./Figures/AdditionalRacketsDesign.PNG" style="zoom:75%;" />

<a name="pneumatic-control-system"/>

## Pneumatic Control System

<a name="pneumatic-system-overview"/>

### Pneumatic System Overview
Below is what our handheld devices and pneumatic system combined looks like.
![](./Figures/DeviceLayout.png)

<a name="circuit-schematic"/>

### Circuit Schematic
![](./Figures/Circuit.png)

<a name="code"/>

### Control Code

<a name="arduino"/>

#### Arduino
We include the compiled code on our Arduino board at `./Code/AirRacket.ino`.

<a name="unity"/>

#### Unity
The specific communicating protocols are written in `./Code/ArduinoBasic.cs` and `./Code/ArduinoControl.cs`, which we attached on Unity GameObject in our virtual scene.

<a name="reference"/>

## Website, Paper/Video Links and BibTeX
[DOI](https://doi.org/10.1145/3491102.3502034), [Video Preview](https://www.youtube.com/watch?v=UAoQlSbQRYY), [Video Presentation](https://www.youtube.com/watch?v=INXk8tT5H3U)
### BibTex
```
@inproceedings{10.1145/3491102.3502034,
author = {Tsai, Ching-Yi and Tsai, I-Lun and Lai, Chao-Jung and Chow, Derrek and Wei, Lauren and Cheng, Lung-Pan and Chen, Mike Y.},
title = {AirRacket: Perceptual Design of Ungrounded, Directional Force Feedback to Improve Virtual Racket Sports Experiences},
year = {2022},
isbn = {9781450391573},
publisher = {Association for Computing Machinery},
address = {New York, NY, USA},
url = {https://doi.org/10.1145/3491102.3502034},
doi = {10.1145/3491102.3502034},
abstract = {We present AirRacket, perceptual modeling and design of ungrounded, directional force feedback for virtual racket sports. Using compressed air propulsion jets to provide directional impact forces, we iteratively designed for three popular sports that span a wide range of force magnitudes: ping-pong, badminton, and tennis. To address the limited force magnitude of ungrounded force feedback technologies, we conducted a perception study which discovered the novel illusion that users perceive larger impact force magnitudes with longer impact duration, by an average factor of 2.57x. Through a series of formative, perceptual, and user experience studies with a combined total of 72 unique participants, we explored several perceptual designs using force magnitude scaling and duration scaling methods to expand the dynamic range of perceived force magnitude. Our user experience evaluation showed that perceptual designs can significantly improve realism and preference vs. physics-based designs for ungrounded force feedback systems.},
booktitle = {CHI Conference on Human Factors in Computing Systems},
articleno = {185},
numpages = {15},
keywords = {air propulsion, ungrounded force feedback, Haptics, perceptual design, virtual reality., force perception},
location = {New Orleans, LA, USA},
series = {CHI '22}
}
```
