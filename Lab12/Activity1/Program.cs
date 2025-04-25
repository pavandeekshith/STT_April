using System;
using System.Threading;

namespace ConsoleAlarmApp
{
    class AlarmClock
    {
        public event EventHandler raiseAlarm;

        public void StartClock(TimeSpan userTime)
        {
            Console.WriteLine($"\n[Info] Waiting for the alarm time: {userTime}");

            while (true)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                Console.Write($"\rCurrent Time: {currentTime.Hours:D2}:{currentTime.Minutes:D2}:{currentTime.Seconds:D2}   ");

                // Allow a margin of 1 second to match
                if (Math.Abs((currentTime - userTime).TotalSeconds) < 1)
                {
                    OnRaiseAlarm();
                    break;
                }

                Thread.Sleep(1000);
            }
        }

        protected virtual void OnRaiseAlarm()
        {
            raiseAlarm?.Invoke(this, EventArgs.Empty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter time in HH:MM:SS format: ");
            string input = Console.ReadLine();

            if (TimeSpan.TryParse(input, out TimeSpan userTime))
            {
                AlarmClock clock = new AlarmClock();
                clock.raiseAlarm += Ring_alarm;
                clock.StartClock(userTime);
            }
            else
            {
                Console.WriteLine("Invalid time format!");
            }
        }

        static void Ring_alarm(object sender, EventArgs e)
        {
            Console.WriteLine("\n⏰ [Alarm] Alarm Time Reached! Ring Ring!");
        }
    }
}