#include "NetworkReporter.h"
#include <PString.h>
#include <Streaming.h>

const double PULSES_PER_OZ = 5600.0 / 33.814;

NetworkReporter::NetworkReporter(NetworkRequester* requester, const char* tapId) { 
  _requester = requester;
  _tapId = tapId;
}

String toString(double arg) {
  char buf[128];
  snprintf(buf, 128, "%f", arg);
  return buf;
}

void NetworkReporter::ReportStop(long pulses){
  double oz = pulses / PULSES_PER_OZ;
  char buf[128];
  PString pBuf(buf, 128);
  if(oz > 64) {
    pBuf << F("Got pour of ") << oz << F(" oz - treating as 0.01oz");
    _requester->MakeRequest(pBuf);
    pBuf.begin();
    oz = 0.01;
  }
  pBuf << F("/api/Tap/") << _tapId << F("/StopPour?volume=") << oz;
  _requester->MakeRequest(pBuf);
}
void NetworkReporter::ReportContinue(long pulses) {
  double oz = pulses / PULSES_PER_OZ;
  char buf[128];
  PString pBuf(buf, 128);
  pBuf << F("/api/Tap/") << _tapId << F("/Pouring?volume=") << oz;
  _requester->MakeRequest(pBuf);
}
void NetworkReporter::ReportStart(long pulses){
  char buf[128];
  PString pBuf(buf, 128);
  pBuf << F("/api/Tap/") << _tapId << F("/StartPour");
  _requester->MakeRequest(pBuf);
}
void NetworkReporter::ReportIgnore(long pulses){
}
