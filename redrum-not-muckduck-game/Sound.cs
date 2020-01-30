using System;
using NAudio.Wave;
using System.Threading;

namespace redrum_not_muckduck_game
{
    public static class Sound
    {
        internal static AudioFileReader audioFile;
        internal static WaveOutEvent outputDevice;

        internal static void PlaySound(string musicFile, int milliSeconds = 0)
        {
            audioFile = new AudioFileReader(musicFile);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            Thread.Sleep(milliSeconds);
        }

        internal static void DisposeAudio()
        {
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}
