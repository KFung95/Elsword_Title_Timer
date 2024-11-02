
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection.Emit;
using System.Drawing.Imaging;
using ClickableTransparentOverlay;
using ClickableTransparentOverlay.Win32;
using ImGuiNET;
using System.IO;
using System.Numerics;
using static System.Windows.Forms.AxHost;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Unicode;
using Vortice.Direct3D11.Debug;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Vortice.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace _Elsword__Title_Timer
{
    public class Preset
    {
        public int Value_custom_Minimize { get; set; }
        public int Value_custom_ChangeTitle { get; set; }
        public int Value_custom_NPWG { get; set; }
        public int Value_custom_NPWG_Skill { get; set; }
        public int Value_custom_FreedShadow { get; set; }
        public int Value_custom_The_Setting_Sun { get; set; }
        public int Value_custom_Natural_Flow { get; set; }
        public int Value_custom_Awakening { get; set; }
        public int Value_custom_Onion { get; set; }
        public int Value_custom_Superhuman_Apple { get; set; }
        public int Value_custom_Reset { get; set; }


        public bool Value_show_NPWG { get; set; }
        public bool Value_show_FreedShadow { get; set; }

        public bool Value_show_The_Setting_Sun { get; set; }

    }

    public unsafe class TimerOverlay : Overlay
    {

        private Preset currentPreset = new Preset();
        private string presetFileName = "";
        private List<string> presetFiles = new List<string>();
        private string presetDirectory = "Presets"; // 프리셋 저장 디렉토리
        private int selectedPresetIndex = 0; // 선택된 프리셋 인덱스



        private void StartPreset()
        {
            if (File.Exists("recent_used.txt"))
            {
                using (StreamReader reader = new StreamReader("recent_used.txt"))
                {
                    presetFileName = (string)(reader.ReadLine());
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("recent_used.txt"))
                {
                    writer.WriteLine("");
                }
            }


        }

        private void SavePreset()
        {
            string filePath = Path.Combine(presetDirectory, presetFileName + ".txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(custom_Minimize);
                writer.WriteLine(custom_ChangeTitle);
                writer.WriteLine(custom_NPWG);
                writer.WriteLine(custom_NPWG_Skill);
                writer.WriteLine(custom_FreedShadow);
                writer.WriteLine(custom_The_Setting_Sun);
                writer.WriteLine(custom_Natural_Flow);
                writer.WriteLine(custom_Awakening);
                writer.WriteLine(custom_Onion);
                writer.WriteLine(custom_Superhuman_Apple);
                writer.WriteLine(custom_Reset);
                writer.WriteLine(Show_NPWG);
                writer.WriteLine(Show_FreedShadow);
                writer.WriteLine(Show_Dusk);
            }


            using (StreamWriter writer = new StreamWriter("recent_used.txt"))
            {
                writer.WriteLine(presetFileName);
            }

        }


        private void LoadPresetFiles()
        {
            presetFiles.Clear();
            if (Directory.Exists(presetDirectory))
            {
                presetFiles.AddRange(Directory.GetFiles(presetDirectory, "*.txt").Select(Path.GetFileNameWithoutExtension));
            }
        }


        public static int Minimize_count = 1;

        private static int custom_Minimize;
        private static int custom_ChangeTitle;
        private static int custom_NPWG;
        private static int custom_NPWG_Skill;
        private static int custom_FreedShadow;
        private static int custom_The_Setting_Sun;
        private static int custom_Natural_Flow;
        private static int custom_Awakening;
        private static int custom_Onion;
        private static int custom_FOD;
        private static int custom_Superhuman_Apple;
        private static int custom_Reset;


        public int form_custom_ChangeTitle;
        public int form_custom_NPWG;
        public int form_custom_NPWG_Skill;
        public int form_custom_FreedShadow;
        public int form_custom_Dusk;
        public int form_custom_Natural;
        public int form_custom_Awakening;
        public int form_custom_Onion;
        public int form_custom_Apple;
        public int form_custom_FOD;
        public int form_custom_TimerReset;
        public bool Show_NPWG = true;
        public bool Show_FreedShadow = true;
        public bool Show_Dusk = true;
        public bool Use_NPWG_FOD = false;
        public bool Use_FreedShadow_FOD = false;
        public bool Use_Dusk_FOD = false;
        public bool ADD_User = false;
        public bool allowResize = false;


        private volatile State state;
        private readonly Thread logicThread;

        public static bool IsCapturing_Minimize = false;
        public static string IsCapturing_Minimize_State = $"Current keycode: {(Keys)custom_Minimize}";
        public static bool IsCapturing_Switching = false;
        public static string IsCapturing_Switching_State = $"Current keycode: {(Keys)custom_ChangeTitle}";
        public static bool IsCapturing_NPWG = false;
        public static string IsCapturing_NPWG_State = $"Current keycode: {(Keys)custom_NPWG}";
        public static bool IsCapturing_NPWG_Skill = false;
        public static string IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)custom_NPWG_Skill}";
        public static bool IsCapturing_FreedShadow = false;
        public static string IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)custom_FreedShadow}";
        public static bool IsCapturing_The_Setting_Sun = false;
        public static string IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)custom_The_Setting_Sun}";
        public static bool IsCapturing_Natural_Flow = false;
        public static string IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)custom_Natural_Flow}";
        public static bool IsCapturing_Awakening = false;
        public static string IsCapturing_Awakening_State = $"Current keycode: {(Keys)custom_Awakening}";
        public static bool IsCapturing_Onion = false;
        public static string IsCapturing_Onion_State = $"Current keycode: {(Keys)custom_Onion}";
        public static bool IsCapturing_Superhuman_Apple = false;
        public static string IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)custom_Superhuman_Apple}";
        public static bool IsCapturing_Reset = false;
        public static string IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";

        private Thread overlayThread;

        public unsafe TimerOverlay() : base(8000, 8000)
        {

            overlayThread = new Thread(() =>
            {
                var form1 = new Form1(this); // TimerOverlay 인스턴스를 Form1에 전달
                System.Windows.Forms.Application.Run(form1); // Form1을 메인 스레드에서 실행
            });
            overlayThread.SetApartmentState(ApartmentState.STA); // STA 스레드 설정
            overlayThread.Start(); // 스레드 시작

            state = new State();
            logicThread = new Thread(() =>
            {
                var lastRunTickStamp = state.Watch.ElapsedTicks;

                while (state.IsRunning)
                {
                    var currentRunTickStamp = state.Watch.ElapsedTicks;
                    var delta = currentRunTickStamp - lastRunTickStamp;
                    LogicUpdate(delta);
                    lastRunTickStamp = currentRunTickStamp;
                }
            });

            logicThread.Start();



            // 프리셋 디렉토리 생성
            if (!Directory.Exists(presetDirectory))
            {
                Directory.CreateDirectory(presetDirectory);
            }

            // 기존 프리셋 파일 로드
            LoadPresetFiles();
            StartPreset();


        }



        public override void Close()
        {
            base.Close();
            this.state.IsRunning = false;
        }






        private void LogicUpdate(float updateDeltaTicks)
        {
            state.LogicalDelta = updateDeltaTicks;

            if (state.RequestLogicThreadSleep)
            {
                Thread.Sleep(TimeSpan.FromSeconds(state.SleepInSeconds));
                state.RequestLogicThreadSleep = false;
            }

            if (state.LogicThreadCloseOverlay)
            {
                Close();
                state.LogicThreadCloseOverlay = false;
            }

            Thread.Sleep(state.LogicTickDelayInMilliseconds); //Not accurate at all as a mechanism for limiting thread runs
        }

        public int FontSize { get; set; } = 55;
        public float fontScale { get; set; } = 80 / 100f;
        public float imgScale { get; set; } = 40 / 100f;

        public bool isInitialized = false;
        private unsafe void InitializeOnce()
        {
            ImGuiIOPtr io = ImGui.GetIO();
            ReplaceFont(@"C:\Windows\Fonts\malgun.ttf", FontSize, FontGlyphRangeType.Korean);
            io.FontGlobalScale = 1.0f;

            SetHook();
        }



        private void synchronization()
        {
            custom_ChangeTitle = form_custom_ChangeTitle;
            custom_NPWG = form_custom_NPWG;
            custom_NPWG_Skill = form_custom_NPWG_Skill;
            custom_FreedShadow = form_custom_FreedShadow;
            custom_The_Setting_Sun = form_custom_Dusk;
            custom_Natural_Flow = form_custom_Natural;
            custom_Awakening = form_custom_Awakening;
            custom_Onion = form_custom_Onion;
            custom_Superhuman_Apple = form_custom_Apple;
            custom_FOD = form_custom_FOD;
            custom_Reset = form_custom_TimerReset;
        }








        protected override void Render()
        {

            //ImGui.ShowDemoWindow();
            synchronization();

            if (!isInitialized)
            {
                InitializeOnce(); // ImGui가 초기화된 후에만 실행
                isInitialized = true; // 초기화 완료 표시
            }


            var deltaSeconds = ImGui.GetIO().DeltaTime;

            if (!state.Visible)
            {
                state.ReappearTimeRemaining -= deltaSeconds;
                if (state.ReappearTimeRemaining < 0)
                {
                    state.Visible = true;
                }

                return;
            }

            if (Utils.IsKeyPressedAndNotTimeout((VK)custom_Minimize))
            {
                if (custom_Minimize != 0 && Minimize_count > 0)
                {
                    state.ShowClickableMenu = !state.ShowClickableMenu;
                }

                Minimize_count++;

            }

            if (Show_NPWG)
            {
                RenderOverlay_NPWG();
            }
            if (Show_FreedShadow)
            {
                RenderOverlay_Freed_Shadow();
            }
            if (Show_Dusk)
            {
                RenderOverlay_The_Setting_Sun();
            }



            return;
        }


        private void RenderOverlay_Freed_Shadow()
        {
            var windowFlags = allowResize ? ImGuiWindowFlags.NoResize : ImGuiWindowFlags.None;

            ImGui.Begin(
                "Freed_Shadow",
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.NoDocking | windowFlags);

            var windowSize = ImGui.GetWindowSize();
            float imgScaleFactor = imgScale;

            // 이미지 크기 계산
            var imgWidth = windowSize.X * imgScaleFactor;
            var imgHeight = windowSize.Y * 0.8f;
            var imgSize = new Vector2(imgWidth, imgHeight);




            if (FreedShadow_Count > 0)
            {


                if (File.Exists("FreedShadow_GrayScale.png"))
                {
                    AddOrGetImagePointer(
                        "FreedShadow_GrayScale.png",
                        false,
                        out IntPtr imgPtr,
                        out uint w,
                        out uint h);
                    ImGui.Image(imgPtr, imgSize);

                    ImGui.SetWindowFontScale(fontScale);
                    ImGui.SameLine();
                    ImGui.Text($"{FreedShadow_Count}");

                }
                else
                {
                    ImGui.Text("Put any image where the exe is, name is 'FreedShadow_GrayScale.png'");
                }

            }
            else
            {
                if (File.Exists("FreedShadow.png"))
                {
                    AddOrGetImagePointer(
                        "FreedShadow.png",
                        false,
                        out IntPtr imgPtr,
                        out uint w,
                        out uint h);
                    ImGui.Image(imgPtr, imgSize);

                    ImGui.SetWindowFontScale(fontScale);
                    ImGui.SameLine();
                    ImGui.Text($"ON");

                }
                else
                {
                    ImGui.Text("Put any image where the exe is, name is 'FreedShadow.png'");
                }
            }
            ImGui.End();

        }

        private void RenderOverlay_NPWG()
        {
            var windowFlags = allowResize ? ImGuiWindowFlags.NoResize : ImGuiWindowFlags.None;

            ImGui.Begin(
                "NPWG",
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.NoDocking | windowFlags);


            var windowSize = ImGui.GetWindowSize();
            float imgScaleFactor = imgScale;

            // 이미지 크기 계산
            var imgWidth = windowSize.X * imgScaleFactor;
            var imgHeight = windowSize.Y * 0.8f;
            var imgSize = new Vector2(imgWidth, imgHeight);



            if (NPWG_Count > 0)
            {


                if (File.Exists("NPWG_GrayScale.png"))
                {
                    AddOrGetImagePointer(
                        "NPWG_GrayScale.png",
                        false,
                        out IntPtr imgPtr,
                        out uint w,
                        out uint h);
                    ImGui.Image(imgPtr, imgSize);

                    ImGui.SetWindowFontScale(fontScale);
                    ImGui.SameLine();
                    ImGui.Text($"{NPWG_Count}");

                }
                else
                {
                    ImGui.Text("Put any image where the exe is, name is 'NPWG_GrayScale.png'");
                }

            }
            else
            {
                if (File.Exists("NPWG.png"))
                {
                    AddOrGetImagePointer(
                        "NPWG.png",
                        false,
                        out IntPtr imgPtr,
                        out uint w,
                        out uint h);
                    ImGui.Image(imgPtr, imgSize);

                    ImGui.SetWindowFontScale(fontScale);
                    ImGui.SameLine();
                    ImGui.Text($"ON");

                }
                else
                {
                    ImGui.Text("Put any image where the exe is, name is 'NPWG.png'");
                }
            }
            ImGui.End();

        }

        private void RenderOverlay_The_Setting_Sun()
        {
            var windowFlags = allowResize ? ImGuiWindowFlags.NoResize : ImGuiWindowFlags.None;

            ImGui.Begin(
                "The_Setting_Sun",
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.NoDocking | windowFlags);

            // 현재 창의 크기 가져오기
            var windowSize = ImGui.GetWindowSize();
            float imgScaleFactor = imgScale;

            // 이미지 크기 계산
            var imgWidth = windowSize.X * imgScaleFactor;
            var imgHeight = windowSize.Y * 0.8f;
            var imgSize = new Vector2(imgWidth, imgHeight);


            if (The_Setting_Sun_Count > 0)
            {


                if (File.Exists("The_Setting_Sun_GrayScale.png"))
                {
                    AddOrGetImagePointer(
                        "The_Setting_Sun_GrayScale.png",
                        false,
                        out IntPtr imgPtr,
                        out uint w,
                        out uint h);
                    ImGui.Image(imgPtr, imgSize);

                    ImGui.SetWindowFontScale(fontScale);
                    ImGui.SameLine();
                    ImGui.Text($"{The_Setting_Sun_Count}");

                }
                else
                {
                    ImGui.Text("Put any image where the exe is, name is 'The_Setting_Sun_GrayScale.png'");
                }

            }
            else
            {
                if (File.Exists("The_Setting_Sun.png"))
                {
                    AddOrGetImagePointer(
                        "The_Setting_Sun.png",
                        false,
                        out IntPtr imgPtr,
                        out uint w,
                        out uint h);
                    ImGui.Image(imgPtr, imgSize);

                    ImGui.SetWindowFontScale(fontScale);
                    ImGui.SameLine();
                    ImGui.Text($"ON");

                }
                else
                {
                    ImGui.Text("Put any image where the exe is, name is 'The_Setting_Sun.png'");
                }
            }

            ImGui.End();

        }


        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint Threadld);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hlnstance);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr IdHook, int nCode, IntPtr wParam, IntPtr IParam);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string ipModuleName);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string IpFileName);

        private const int WH_KEYBOARD_LL = 13;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wearable, IntPtr lParam);
        private static bool isChangeTitlePressed = false;
        private static string title_Desc = "FreedShadow";
        private static int NPWG_Count = 0;
        private static int FreedShadow_Count = 0;
        private static int The_Setting_Sun_Count = 0;

        //이 위로는 DLL import 등입니다.

        private static LowLevelKeyboardProc keyboardProc = KeyboardHookProc;
        private static IntPtr keyHook = IntPtr.Zero;



        private static System.Threading.Timer timer_ChangeTitle = new System.Threading.Timer(TimerCallback_ChangeTitle, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_NPWG = new System.Threading.Timer(TimerCallback_NPWG, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_FreedShadow = new System.Threading.Timer(TimerCallback_FreedShadow, null, Timeout.Infinite, Timeout.Infinite);
        //private static System.Threading.Timer timer_Right = new System.Threading.Timer(TimerCallback_Right, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_The_Setting_Sun = new System.Threading.Timer(TimerCallback_The_Setting_Sun, null, Timeout.Infinite, Timeout.Infinite);


        //후킹을 설정해줍니다.
        public static void SetHook()
        {
            if (keyHook == IntPtr.Zero)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    keyHook = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardProc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        private static IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam)
        {

            if (code >= 0 && (int)wParam == 256)
            {
                int keyCode = Marshal.ReadInt32(lParam);

                if (keyCode == custom_ChangeTitle)
                {

                    isChangeTitlePressed = true;

                    timer_ChangeTitle.Change(3000, Timeout.Infinite);
                }
                else if (keyCode == custom_NPWG && isChangeTitlePressed)
                {
                    title_Desc = "NPWG";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);

                }
                else if (keyCode == custom_FreedShadow && isChangeTitlePressed)
                {
                    title_Desc = "FreedShadow";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);

                }
                else if (keyCode == custom_Natural_Flow && isChangeTitlePressed)
                {
                    title_Desc = "Natural Flow";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);
                }
                else if (keyCode == custom_The_Setting_Sun && isChangeTitlePressed)
                {
                    title_Desc = "The_Setting_Sun";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);

                }
                else if (keyCode == custom_NPWG_Skill && title_Desc == "NPWG")
                {
                    if (NPWG_Count <= 0)
                    {
                        NPWG_Count = 26;
                        timer_NPWG.Change(0, 1000);
                    }
                }
                else if ((keyCode == custom_Awakening || keyCode == custom_Onion || keyCode == custom_Superhuman_Apple) && title_Desc == "FreedShadow")
                {
                    if (FreedShadow_Count <= 0)
                    {
                        FreedShadow_Count = 61;
                        timer_FreedShadow.Change(0, 1000);
                    }
                }
                else if ((keyCode == custom_Awakening || keyCode == custom_Onion || keyCode == custom_Superhuman_Apple) && title_Desc == "The_Setting_Sun")
                {
                    if (The_Setting_Sun_Count <= 0)
                    {
                        The_Setting_Sun_Count = 31;
                        timer_The_Setting_Sun.Change(0, 1000);
                    }
                }
                else if (keyCode == custom_Reset)
                {

                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);
                    NPWG_Count = 0;
                    FreedShadow_Count = 0;
                    The_Setting_Sun_Count = 0;

                }
            }

            return CallNextHookEx(keyHook, code, wParam, lParam);
        }

        private static void TimerCallback_ChangeTitle(object state)
        {
            isChangeTitlePressed = false;
        }

        private static void TimerCallback_NPWG(object state)
        {

            if (NPWG_Count > 0)
            {
                NPWG_Count--;
            }

        }

        private static void TimerCallback_FreedShadow(object state)
        {

            if (FreedShadow_Count > 0)
            {
                FreedShadow_Count--;
            }

        }

        //private static void TimerCallback_Right(object state)
        //{

        //}

        private static void TimerCallback_The_Setting_Sun(object state)
        {

            if (The_Setting_Sun_Count > 0)
            {
                The_Setting_Sun_Count--;
            }

        }



        private void UnHook()
        {
            UnhookWindowsHookEx(keyHook);
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            UnHook();
        }




    }
}


