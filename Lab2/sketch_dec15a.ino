#include <math.h> 
int LdrPin = A0;
float LdrValue = 0;
float LdrValueV = 0;
float LdrLux = 0;
int TempPin = A1;
float TempValue = 0;
float TempValueV = 0;
float tempValueC = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(LdrPin,INPUT);
  pinMode(TempPin,INPUT);
  Serial.begin(9600);
  Serial.flush();
}

void loop() {
  // put your main code here, to run repeatedly:
  LdrValue = analogRead(LdrPin);
  LdrValueV = (LdrValue*5)/1024;
  LdrLux =  411.02*pow(LdrValueV,2) - 1843.6*LdrValueV + 2307.1;

  TempValue = analogRead(TempPin);
  TempValueV = (TempValue*5)/1024;
  tempValueC = 3.3733*pow(TempValueV,2) - 1.5283*TempValueV + 5.0848;

  Serial.print("LDR Lux ");
  Serial.print("\n");
  Serial.print(LdrLux);
    Serial.print("\n");
    Serial.print("LDR V ");
  Serial.print("\n");
  Serial.print(LdrValueV);
  Serial.print("\n");
  
  Serial.print("Temperature celius ");
  Serial.print(tempValueC);
  Serial.print("\n");
    Serial.print("Temperature V ");
  Serial.print(TempValueV);
  Serial.print("\n");
  delay(4000);
  
}
