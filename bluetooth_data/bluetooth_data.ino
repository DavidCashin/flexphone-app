#include <SoftwareSerial.h>

// number of readings that are averaged out.
const int numReadings = 10; //will likely need tuning

String data; //string that stores the incoming message
int flex_position_1 = 0;
int flex_position_2 = 0;
int flex_position_3 = 0;

int fp1Readings[numReadings];
int fp2Readings[numReadings];
int fp3Readings[numReadings];

int readIndex[] = {0,0,0};
int total[] = {0,0,0};
int average[] = {0,0,0};

SoftwareSerial SoftSerial(10,11); // 10=rx, 11=tx

void setup(){
  // initialize all the readings to 0:
  for (int thisReading = 0; thisReading < numReadings; thisReading++) {
    fp1Readings[thisReading] = 0;
    fp2Readings[thisReading] = 0;
    fp3Readings[thisReading] = 0;
  }
  
  // Open serial communications and wait for port to open:
  Serial.begin(115200);  
  Serial.println("Setup usb serial");

  // set the data rate for the SoftwareSerial port
  SoftSerial.begin(115200);
}

void loop(){
  flex_position_1 = analogRead(A0); // right sensor
  flex_position_2 = analogRead(A1); // left sensor
  flex_position_3 = analogRead(A2); // middle sensor

  //filter out irregularities in bend sensor for a smooth reading
  total[0] = total[0] - fp1Readings[readIndex[0]]; // subtract the last reading:
  total[1] = total[1] - fp2Readings[readIndex[1]];
  total[2] = total[2] - fp3Readings[readIndex[2]];
  // read from the sensor:
  fp1Readings[readIndex[0]] = flex_position_1;
  fp2Readings[readIndex[1]] = flex_position_2;
  fp3Readings[readIndex[2]] = flex_position_3;
  
  // add the reading to the total:
  total[0] = total[0] + fp1Readings[readIndex[0]];
  total[1] = total[1] + fp2Readings[readIndex[1]];
  total[2] = total[2] + fp3Readings[readIndex[2]];

  // advance to the next position in the array:
  readIndex[0] = readIndex[0] + 1;
  readIndex[1] = readIndex[1] + 1;
  readIndex[2] = readIndex[2] + 1;

  if (readIndex[0] >= numReadings) {
    readIndex[0] = 0;
    readIndex[1] = 0; 
    readIndex[2] = 0;
  }

  // calculate the average:
  average[0] = total[0] / numReadings;
  average[1] = total[1] / numReadings;
  average[2] = total[2] / numReadings;

  delay(10);        // delay in between reads for stability

  
  data = String(average[0]) +"," + String(average[1]) + "," + String(average[2]);
  
  SoftSerial.println(data);
  Serial.println(data);
  delay(100); 
}
    
