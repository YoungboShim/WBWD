// Firmware of WBWD

// LRA motor driver pin assignment
const int motor1_F =  2;
const int motor1_R =  3;
const int motor2_F =  8;
const int motor2_R =  9;
const int motor3_F =  7;
const int motor3_R =  6;
const int motor4_F =  4;
const int motor4_R =  5;
const int motor5_F =  12; // not used
const int motor5_R =  11; // not used

// Micro fan control pin assignment
const int fan1 = A0;
const int fan2 = A5;
const int fan3 = A3;
const int fan4 = A1;

// LRA on/off flag
bool motorOn[4] = {false, false, false, false};

// Micro fan on/off flag
bool fanOn[4] = {false, false, false, false};

// Pattern managing variables
const int duration = 1500;// Pattern's duration(ms)
int curTime = 0; // Timer starts from 0 when pattern starts
bool patternOn = false; // Pattern indicating flag
const bool initBool[4] = {false, false, false, false};
bool fanFormer[4] = {false, false, false, false};
bool fanLatter[4] = {false, false, false, false};
bool motorFormer[4] = {false, false, false, false};
bool motorLatter[4] = {false, false, false, false};

// Patterns
bool tactorA[4] = {true, false, false, false};
bool tactorB[4] = {false, true, false, false};
bool tactorC[4] = {false, false, true, false};
bool tactorD[4] = {false, false, false, true};

// Serial managing variables
bool stringComplete = false;
char inData[100];
int dataIdx = 0;
 
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

  digitalWrite(motor1_F, LOW);
  digitalWrite(motor1_R, LOW);
  digitalWrite(motor2_F, LOW);
  digitalWrite(motor2_R, LOW);
  digitalWrite(motor3_F, LOW);
  digitalWrite(motor3_R, LOW);
  digitalWrite(motor4_F, LOW);
  digitalWrite(motor4_R, LOW);
  
  Serial.begin(115200);
  
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
    if(curTime > duration*0.95)
    {
      // Turn off both fan and motor becuase time is expired
      memcpy(fanOn, initBool, 4 * sizeof(bool));
      
      memcpy(fanFormer, initBool, 4 * sizeof(bool));
      memcpy(motorFormer, initBool, 4 * sizeof(bool));
      memcpy(fanLatter, initBool, 4 * sizeof(bool));
      memcpy(motorLatter, initBool, 4 * sizeof(bool));
  
      patternOn = false;
    }
    else if(curTime > duration * 0.7)
    {
      memcpy(motorOn, initBool, 4 * sizeof(bool)); 
    }
    else if(curTime > duration * 0.6)
    {
      memcpy(motorOn, motorLatter, 4 * sizeof(bool));
    }
    else if(curTime > duration  * 0.5)
    {
      memcpy(fanOn, fanLatter, 4 * sizeof(bool));
    }
    else if(curTime > duration  * 0.45)
    {
      //Turn off the former bool and assign latter bools
      memcpy(fanOn, initBool, 4 * sizeof(bool));
    }
    else if(curTime > duration * 0.2)
    {
      memcpy(motorOn, initBool, 4 * sizeof(bool)); 
    }
    else if(curTime > duration * 0.1)
    {
      memcpy(motorOn, motorFormer, 4 * sizeof(bool));
    }
    else if(curTime > 0)
    {
      memcpy(fanOn, fanFormer, 4 * sizeof(bool));
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
}

// Function: loopSerial
// Serial input for debug 
void loopSerial()
{
  if(stringComplete)
  {
    char line[100];
    int lineIdx = 0;
    // Count command chars & init inData
    while(inData[lineIdx] != '\n' && lineIdx < 100)
    {
      line[lineIdx] = inData[lineIdx];
      inData[lineIdx] = NULL;
      lineIdx++;
    }
    
    bool isPattern = false;
    char c1 = line[0], c2 = line[1], c3 = line[2], c4 = line[3];
    int fanNum, motorNum;
    bool tmpFanFormer[4], tmpFanLatter[4], tmpMotorFormer[4], tmpMotorLatter[4];
    
    switch(c1)
    {
      // Debugging cases
      case 'f':
        fanNum = (int)c2 - 49;
        if(0 <= fanNum && fanNum < 4)
        {
          fanOn[fanNum] = !fanOn[fanNum];
          Serial.print("Fan");
          Serial.print(c2);
          if(fanOn[fanNum])
          {
            Serial.print(": ON\n");
          }
          else
          {
             Serial.print(": OFF\n");
          }
        }
        break;
      case 'm':
        motorNum = (int)c2 - 49;
        if(0 <= motorNum && motorNum < 4)
        {
          motorOn[motorNum] = !motorOn[motorNum];
          Serial.print("Motor");
          Serial.print(c2);
          if(motorOn[fanNum])
          {
            Serial.print(": ON\n");
          }
          else
          {
             Serial.print(": OFF\n");
          }
        }
        break;
      case 'z':
        Serial.println("Stop all");
        for(int i=0;i<4;i++)
        {
          fanOn[i] = false;
          motorOn[i] = false;
        }
        patternOn = false;
        break;
      // Pattern cogition
      case 'a':
        memcpy(tmpFanFormer, tactorA, 4 * sizeof(bool));
        isPattern = true;
        break;
      case 'b':
        memcpy(tmpFanFormer, tactorB, 4 * sizeof(bool));
        isPattern = true;
        break;
      case 'c':
        memcpy(tmpFanFormer, tactorC, 4 * sizeof(bool));
        isPattern = true;
        break;
      case 'd':
        memcpy(tmpFanFormer, tactorD, 4 * sizeof(bool));
        isPattern = true;
        break;
      case 'n':
        memcpy(tmpFanFormer, initBool, 4 * sizeof(bool));
        isPattern = true;
        break;
      default:
        break;
    }
    if(isPattern)
    {
      switch(c2)
      {
        case 'a':
          memcpy(tmpMotorFormer, tactorA, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'b':
          memcpy(tmpMotorFormer, tactorB, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'c':
          memcpy(tmpMotorFormer, tactorC, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'd':
          memcpy(tmpMotorFormer, tactorD, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'n':
          memcpy(tmpMotorFormer, initBool, 4 * sizeof(bool));
          isPattern = true;
          break;
        default:
          isPattern = false;
          break;
      }
    }
    if(isPattern)
    {
      switch(c3)
      {
        case 'a':
        memcpy(tmpFanLatter, tactorA, 4 * sizeof(bool));
        isPattern = true;
        break;
        case 'b':
          memcpy(tmpFanLatter, tactorB, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'c':
          memcpy(tmpFanLatter, tactorC, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'd':
          memcpy(tmpFanLatter, tactorD, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'n':
          memcpy(tmpFanLatter, initBool, 4 * sizeof(bool));
          isPattern = true;
          break;
        default:
          isPattern = false;
          break;
      }
    }
    if(isPattern)
    {
      switch(c4)
      {
        case 'a':
          memcpy(tmpMotorLatter, tactorA, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'b':
          memcpy(tmpMotorLatter, tactorB, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'c':
          memcpy(tmpMotorLatter, tactorC, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'd':
          memcpy(tmpMotorLatter, tactorD, 4 * sizeof(bool));
          isPattern = true;
          break;
        case 'n':
          memcpy(tmpMotorLatter, initBool, 4 * sizeof(bool));
          isPattern = true;
          break;
        default:
          isPattern = false;
          break;
      }
    }
    if(isPattern)
    {
      Serial.println("Pattern: " + String(c1) + String(c2) + String(c3) + String(c4));
      startPattern(tmpFanFormer, tmpMotorFormer, tmpFanLatter, tmpMotorLatter);
    }
    stringComplete = false;
  }
}

void serialEvent()
{
  while(Serial.available() && stringComplete == false)
  {
    char inChar = Serial.read();
    inData[dataIdx++] = inChar;

    if(inChar == '\n')
    {
      dataIdx = 0;
      stringComplete = true;
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
  digitalWrite(motor1_F, LOW);
  digitalWrite(motor1_R, LOW);
  digitalWrite(motor2_F, LOW);
  digitalWrite(motor2_R, LOW);
  digitalWrite(motor3_F, LOW);
  digitalWrite(motor3_R, LOW);
  digitalWrite(motor4_F, LOW);
  digitalWrite(motor4_R, LOW);
  //Forward
  if(motorOn[0])
  {
    digitalWrite(motor1_F, HIGH);
    digitalWrite(motor1_R, LOW);
  }
  if(motorOn[1])
  {
    digitalWrite(motor2_F, HIGH);
    digitalWrite(motor2_R, LOW);
  }
  if(motorOn[2])
  {
    digitalWrite(motor3_F, HIGH);
    digitalWrite(motor3_R, LOW);
  }
  if(motorOn[3])
  {
    digitalWrite(motor4_F, HIGH);
    digitalWrite(motor4_R, LOW);
  }
  
  delayCount(3);
  
  //Reverse
  if(motorOn[0])
  {
    digitalWrite(motor1_F, LOW);
    digitalWrite(motor1_R, HIGH);
  }
  if(motorOn[1])
  {
    digitalWrite(motor2_F, LOW);
    digitalWrite(motor2_R, HIGH);
  }
  if(motorOn[2])
  {
    digitalWrite(motor3_F, LOW);
    digitalWrite(motor3_R, HIGH);
  }
  if(motorOn[3])
  {
    digitalWrite(motor4_F, LOW);
    digitalWrite(motor4_R, HIGH);
  }

  delayCount(3);
}

// Function: delayCount
// Delay time and count up currTime
void delayCount(int time)
{
  if(patternOn)
    curTime = curTime + time;
  delay(time);
}


