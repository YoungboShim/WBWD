// FW of WBWD

// LRA motor driver pin assignment
const int motor1_F =  2;
const int motor1_R =  3;
const int motor2_F =  4;
const int motor2_R =  5;
const int motor3_F =  7;
const int motor3_R =  6;
const int motor4_F =  8;
const int motor4_R =  9;
const int motor5_F =  12;
const int motor5_R =  11;

// Micro fan control pin assignment
const int fan1 = A0;
const int fan2 = A1;
const int fan3 = A3;
const int fan4 = A5;

// LRA on/off flag
bool motor1_on = false;
bool motor2_on = false;
bool motor3_on = false;
bool motor4_on = false;
bool motor5_on = false;

//Micro fan on/off flag
bool fan1_on = false;
bool fan2_on = false;
bool fan3_on = false;
bool fan4_on = false;
 
void setup() 
{ 
  pinMode (motor1_F, OUTPUT);
  pinMode (motor1_R, OUTPUT);
  pinMode (motor2_F, OUTPUT);
  pinMode (motor2_R, OUTPUT);
  pinMode (motor3_F, OUTPUT);
  pinMode (motor3_R, OUTPUT);
  pinMode (motor4_F, OUTPUT);
  pinMode (motor4_R, OUTPUT);
  pinMode (motor5_F, OUTPUT);
  pinMode (motor5_R, OUTPUT);
  
  pinMode (fan1, OUTPUT);
  pinMode (fan2, OUTPUT);
  pinMode (fan3, OUTPUT);
  pinMode (fan4, OUTPUT);
  
  Serial.begin(9600);
  
  while (! Serial);
  Serial.println("Amplitude in percent");
} 
 
void loop() 
{ 
  // Serial input for debug
  if(Serial.available() > 0)
  {
    char c = Serial.read();
    switch(c)
    {
      case 'q':
        fan1_on = true;
        Serial.println("Fan1: ON");
        break;
      case 'a':
        fan1_on = false;
        Serial.println("Fan1: OFF");
        break;
      case 'w':
        fan2_on = true;
        Serial.println("Fan2: ON");
        break;
      case 's':
        fan2_on = false;
        Serial.println("Fan1: OFF");
        break;
      case 'e':
        fan3_on = true;
        Serial.println("Fan3: ON");
        break;
      case 'd':
        fan3_on = false;
        Serial.println("Fan3: OFF");
        break;
      case 'r':
        fan4_on = true;
        Serial.println("Fan4: ON");
        break;
      case 'f':
        fan4_on = false;
        Serial.println("Fan4: OFF");
        break;
    }
  }
  
  // Turn on fan if true
  if(fan1_on)
  {
    digitalWrite(fan1, HIGH);
  }
  else
  {
    digitalWrite(fan1, LOW);
  }
  if(fan2_on)
  {
    digitalWrite(fan2, HIGH);
  }
  else
  {
    digitalWrite(fan2, LOW);
  }
  if(fan3_on)
  {
    digitalWrite(fan3, HIGH);
  }
  else
  {
    digitalWrite(fan3, LOW);
  }
  if(fan4_on)
  {
    digitalWrite(fan4, HIGH);
  }
  else
  {
    digitalWrite(fan4, LOW);
  }

  //Turn on LRA if true
  //Forward
  if(motor1_on)
  {
    digitalWrite(motor1_F, HIGH);
    digitalWrite(motor1_R, LOW);
  }
  else
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, LOW);
  }
  if(motor2_on)
  {
    digitalWrite(motor2_F, HIGH);
    digitalWrite(motor2_R, LOW);
  }
  else
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, LOW);
  }
  if(motor3_on)
  {
    digitalWrite(motor3_F, HIGH);
    digitalWrite(motor3_R, LOW);
  }
  else
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, LOW);
  }
  if(motor4_on)
  {
    digitalWrite(motor4_F, HIGH);
    digitalWrite(motor4_R, LOW);
  }
  else
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, LOW);
  }
  if(motor5_on)
  {
    digitalWrite(motor5_F, HIGH);
    digitalWrite(motor5_R, LOW);
  }
  else
  {
    digitalWrite(motor5_F, LOW);
    digitalWrite(motor5_R, LOW);
  }
  
  delay(3);

  //Reverse
  if(motor1_on)
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, HIGH);
  }
  else
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, LOW);
  }
  if(motor2_on)
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, HIGH);
  }
  else
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, LOW);
  }
  if(motor3_on)
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, HIGH);
  }
  else
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, LOW);
  }
  if(motor4_on)
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, HIGH);
  }
  else
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, LOW);
  }
  if(motor5_on)
  {
    digitalWrite(motor5_F, LOW);
    digitalWrite(motor5_R, HIGH);
  }
  else
  {
    digitalWrite(motor5_F, LOW);
    digitalWrite(motor5_R, LOW);
  }

  delay(3);
} 
