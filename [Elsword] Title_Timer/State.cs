namespace _Elsword__Title_Timer
{
    using System.Diagnostics;
    using System.Diagnostics.Metrics;

    public class State
    {


        public readonly Stopwatch Watch = Stopwatch.StartNew();
        public bool ShowClickableMenu = true;
        public bool ShowOverlaySample1 = true;
        public bool ShowOverlaySample2 = true;
        public bool ShowOverlaySample3 = true;
        public bool ShowImGuiDemo = false;
        public int[] resizeHelper = new int[4] { 0, 0, 2560, 1440 };
        public int Seconds = 5;
        public int CurrentDisplay = 0;
        public bool IsRunning = true;
        public bool Visible;


        public int LogicTickDelayInMilliseconds = 10;
        public float LogicalDelta = 0;

        public bool RequestLogicThreadSleep = false;
        public int SleepInSeconds = 5;


        public float ReappearTimeRemaining = 0;

        public bool LogicThreadCloseOverlay = false;
    }
}