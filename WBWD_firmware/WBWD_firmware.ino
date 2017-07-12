// Firmware of WBWD

// LRA motor driver pin assignment
const int motor1_F =  2;
const int motor1_R =  3;
const int motor2_F =  4;
const int motor2_R =  5;
const int motor3_F =  7;
const int motor3_R =  6;
const int motor4_F =  8;
const int motor4_R =  9;
const int motor5_F =  12; // not used
const int motor5_R =  11; // not used

// Micro fan control pin assignment
const int fan1 = A0;
const int fan2 = A1;
const int fan3 = A3;
const int fan4 = A5;

// LRA on/off flag
bool motorOn[4] = {false, false, false, false};

// Micro fan on/off flag
bool fanOn[4] = {false, false, false, false};

// Pattern managing variables
const int duration = 500;// Pattern's duration(ms)
int curTime = 0; // Timer starts from 0 when pattern starts
bool patternOn = false; // Pattern indicating flag
const bool initBool[4] = {false, false, false, false};
bool fanFormer[4] = {false, false, false, false};
bool fanLatter[4] = {false, false, false, false};
bool motorFormer[4] = {false, false, false, false};
bool motorLatter[4] = {false, false, false, false};

bool tmpFormer[4] = {true, false, false, false};
bool tmpLatter[4] = {false, true, false, false};
 
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
  Serial.println("Ready for command...");
} 
 
void loop() 
{ 
  loopPatternManager();
  loopSerial();
  loopFanOnOff();
  loopMotorOnOff();
}

// Function: loopPatternManager
// Check if the counter exceeds the duration and change or turn off the pattern bools
void loopPatternManager()
{
  if(patternOn)
  {
    if(curTime > duration)
    {
      // Turn off both fan and motor becuase time is expired
      memcpy(fanLatter, initBool, 4 * sizeof(bool));
      memcpy(motorLatter, initBool, 4 * sizeof(bool));
      memcpy(fanOn, initBool, 4 * sizeof(bool));
      memcpy(motorOn, initBool, 4 * sizeof(bool));
  
      patternOn = false;
    }
    else if(curTime > duration / 2)
    {
      //Turn off the former bool and assign latter bools
      memcpy(fanOn, fanLatter, 4 * sizeof(bool));
      memcpy(motorOn, motorLatter, 4 * sizeof(bool));
      memcpy(fanFormer, initBool, 4 * sizeof(bool));
      memcpy(motorFormer, initBool, 4 * sizeof(bool));
    }
  }
}

// Function: startPattern
// Get pattern arrays and assign pattern variables
void startPattern(bool fanFormerIn[4], bool motorFormerIn[4], bool fanLatterIn[4], bool motorLatterIn[4])
{
  // Copy pattern values
  memcpy(fanFormer, fanFormerIn, 4 * sizeof(bool));
  memcpy(motorFormer, motorFormerIn, 4 * sizeof(bool));
  memcpy(fanLatter, fanLatterIn, 4 * sizeof(bool));
  memcpy(motorLatter, motorLatterIn, 4 * sizeof(bool));

  // Set pattern
  patternOn = true;
  curTime = 0;
  memcpy(fanOn, fanFormer, 4 * sizeof(bool));
  memcpy(motorOn, motorFormer, 4 * sizeof(bool));
}

// Function: loopSerial
// Serial input for debug 
void loopSerial()
{
  if(Serial.available() > 0)
  {
    char c = Serial.read();
    switch(c)
    {
      case 'q':
        fanOn[0] = true;
        Serial.println("Fan1: ON");
        break;
      case 'a':
        fanOn[0] = false;
        Serial.println("Fan1: OFF");
        break;
      case 'w':
        fanOn[1] = true;
        Serial.println("Fan2: ON");
        break;
      case 's':
        fanOn[1] = false;
        Serial.println("Fan1: OFF");
        break;
      case 'e':
        fanOn[2] = true;
        Serial.println("Fan3: ON");
        break;
      case 'd':
        fanOn[2] = false;
        Serial.println("Fan3: OFF");
        break;
      case 'r':
        fanOn[3] = true;
        Serial.println("Fan4: ON");
        break;
      case 'f':
        fanOn[3] = false;
        Serial.println("Fan4: OFF");
        break;
      case 't':
        motorOn[0] = true;
        Serial.println("Motor1: ON");
        break;
      case 'g':
        motorOn[0] = false;
        Serial.println("Motor1: OFF");
        break;
      case 'y':
        motorOn[1] = true;
        Serial.println("Motor2: ON");
        break;
      case 'h':
        motorOn[1] = false;
        Serial.println("Motor2: OFF");
        break;
      case 'u':
        motorOn[2] = true;
        Serial.println("Motor3: ON");
        break;
      case 'j':
        motorOn[2] = false;
        Serial.println("Motor3: OFF");
        break;
      case 'i':
        motorOn[3] = true;
        Serial.println("Motor4: ON");
        break;
      case 'k':
        motorOn[3] = false;
        Serial.println("Motor4: OFF");
        break;
      case 'z':
        startPattern(tmpFormer, initBool, tmpLatter, initBool);
      default:
        break;
    }
  }
}

// Function: loopMotorOnOff
// Turn on fan if true
void loopFanOnOff()
{
  if(fanOn[0])
  {
    digitalWrite(fan1, HIGH);
  }
  else
  {
    digitalWrite(fan1, LOW);
  }
  if(fanOn[1])
  {
    digitalWrite(fan2, HIGH);
  }
  else
  {
    digitalWrite(fan2, LOW);
  }
  if(fanOn[2])
  {
    digitalWrite(fan3, HIGH);
  }
  else
  {
    digitalWrite(fan3, LOW);
  }
  if(fanOn[3])
  {
    digitalWrite(fan4, HIGH);
  }
  else
  {
    digitalWrite(fan4, LOW);
  }
}

// Function: loopMotorOnOff
// Turn on LRA if true
void loopMotorOnOff()
{
  //Forward
  if(motorOn[0])
  {
    digitalWrite(motor1_F, HIGH);
    digitalWrite(motor1_R, LOW);
  }
  else
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, LOW);
  }
  if(motorOn[1])
  {
    digitalWrite(motor2_F, HIGH);
    digitalWrite(motor2_R, LOW);
  }
  else
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, LOW);
  }
  if(motorOn[2])
  {
    digitalWrite(motor3_F, HIGH);
    digitalWrite(motor3_R, LOW);
  }
  else
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, LOW);
  }
  if(motorOn[3])
  {
    digitalWrite(motor4_F, HIGH);
    digitalWrite(motor4_R, LOW);
  }
  else
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, LOW);
  }
  
  delayCount(6);

  //Reverse
  if(motorOn[0])
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, HIGH);
  }
  else
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, LOW);
  }
  if(motorOn[1])
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, HIGH);
  }
  else
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, LOW);
  }
  if(motorOn[2])
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, HIGH);
  }
  else
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, LOW);
  }
  if(motorOn[3])
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, HIGH);
  }
  else
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, LOW);
  }

  delayCount(6);
}

// Function: delayCount
// Delay time and count up currTime
void delayCount(int time)
{
  if(patternOn)
    curTime = curTime + time;
  delay(time);
}


