/*
Written by Peter O.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://upokecenter.dreamhosters.com/articles/donate-now-2/
 */
using System;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace AudioBatteryNotify
{
  class Program
  {
    public static void Main(string[] args) {
      int lastState=-1;
      var synth = new SpeechSynthesizer();
      while (true) {
        if (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.High||
           SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.Low||
           SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.Critical) {
          float pct = SystemInformation.PowerStatus.BatteryLifePercent;
          int newState=(int)Math.Round(pct);
          if (pct <= 1.0) {
 newState=(int)Math.Round(pct*100);
}
          if (newState <= 100 && newState != lastState) {
            string text = ("" + newState + " percent");
            synth.SpeakAsync(text);
          }
          lastState = newState;
        } else {
          lastState=-1;
        }
        Thread.Sleep(4000);
      }
    }
  }
}
