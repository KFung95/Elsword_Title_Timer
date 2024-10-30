
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

    public class TimerOverlay : Overlay
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

            LoadPreset(presetFileName);

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
                writer.WriteLine(state.ShowOverlaySample1);
                writer.WriteLine(state.ShowOverlaySample2);
                writer.WriteLine(state.ShowOverlaySample3);
            }


            using (StreamWriter writer = new StreamWriter("recent_used.txt"))
            {
                writer.WriteLine(presetFileName);
            }

        }

        private void LoadPreset(string fileName)
        {
            string filePath = Path.Combine(presetDirectory, fileName + ".txt");
            if (File.Exists(filePath))
            {

                presetFileName = fileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    custom_Minimize = int.Parse(reader.ReadLine());
                    IsCapturing_Minimize_State = $"Current keycode: {(Keys)custom_Minimize}";
                    custom_ChangeTitle = int.Parse(reader.ReadLine());
                    IsCapturing_Switching_State = $"Current keycode: {(Keys)custom_ChangeTitle}";
                    custom_NPWG = int.Parse(reader.ReadLine());
                    IsCapturing_NPWG_State = $"Current keycode: {(Keys)custom_NPWG}";
                    custom_NPWG_Skill = int.Parse(reader.ReadLine());
                    IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)custom_NPWG_Skill}";
                    custom_FreedShadow = int.Parse(reader.ReadLine());
                    IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)custom_FreedShadow}";
                    custom_The_Setting_Sun = int.Parse(reader.ReadLine());
                    IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)custom_The_Setting_Sun}";
                    custom_Natural_Flow = int.Parse(reader.ReadLine());
                    IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)custom_Natural_Flow}";
                    custom_Awakening = int.Parse(reader.ReadLine());
                    IsCapturing_Awakening_State = $"Current keycode: {(Keys)custom_Awakening}";
                    custom_Onion = int.Parse(reader.ReadLine());
                    IsCapturing_Onion_State = $"Current keycode: {(Keys)custom_Onion}";
                    custom_Superhuman_Apple = int.Parse(reader.ReadLine());
                    IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)custom_Superhuman_Apple}";
                    custom_Reset = int.Parse(reader.ReadLine());
                    IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";
                    state.ShowOverlaySample1 = bool.Parse(reader.ReadLine());
                    state.ShowOverlaySample2 = bool.Parse(reader.ReadLine());
                    state.ShowOverlaySample3 = bool.Parse(reader.ReadLine());
                }

                using (StreamWriter writer = new StreamWriter("recent_used.txt"))
                {
                    writer.WriteLine(presetFileName);
                }
            }
            else
            {
                System.Console.WriteLine("Preset file not found!");
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
        private static int custom_Superhuman_Apple;
        private static int custom_Reset;

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



        public TimerOverlay() : base(3840, 2160)
        {

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
        protected override void Render()
        {
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



            if (state.ShowOverlaySample1)
            {
                RenderOverlay_NPWG();
            }
            if (state.ShowOverlaySample2)
            {
                RenderOverlay_Freed_Shadow();
            }
            if (state.ShowOverlaySample3)
            {
                RenderOverlay_The_Setting_Sun();
            }



            if (state.ShowClickableMenu)
            {
                RenderMainMenu();
            }

            return;
        }


        private void RenderMainMenu()
        {
            
            bool isCollapsed = !ImGui.Begin(
                "Title Timer main window",
                ref state.IsRunning,
                ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoCollapse);

            if (!state.IsRunning || isCollapsed)
            {
                ImGui.End();
                if (!state.IsRunning)
                {
                    Close();
                }

                return;
            }

            SetHook();




            // 키 값을 변경할 수 있는 슬라이더 추가
            // 키 입력 캡처 버튼 추가
            if (ImGui.Button("Change [minimize] key"))
            {
                IsCapturing_Minimize = true; // 칭호 변경키 캡처 시작
                IsCapturing_Minimize_State = "Press the [minimize] key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [minimize] key)"))
            {
                IsCapturing_Minimize = false;
                custom_Minimize = -1;
                IsCapturing_Minimize_State = "Current keycode: none";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Minimize_State);
            ImGui.Text("If you want to On/Off the this \"Title Timer main window\", press the [minimize] key.");
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [Title switching] key"))
            {
                IsCapturing_Switching = true; // 칭호 변경키 캡처 시작
                IsCapturing_Switching_State = "Press the [Title] switching key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Title switching] key)"))
            {
                IsCapturing_Switching = false;
                custom_ChangeTitle = -1;
                IsCapturing_Switching_State = "Current keycode: None";

            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Switching_State);
            ImGui.Text("---------------------------------------------------------------");


            if (ImGui.Button("Change [Night Parade of the White-Ghost] arrow key"))
            {
                IsCapturing_NPWG = true; // 칭호 변경키 캡처 시작
                IsCapturing_NPWG_State = "Press the [Night Parade of the White-Ghost] arrow key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Night Parade of the White-Ghost] arrow key)"))
            {
                IsCapturing_NPWG = false;
                custom_NPWG = -1;
                IsCapturing_NPWG_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_NPWG_State);
            ImGui.Text("---------------------------------------------------------------");


            if (ImGui.Button("Change [Night Parade of the White-Ghost] Skill Key)"))
            {
                IsCapturing_NPWG_Skill = true; // 칭호 변경키 캡처 시작
                IsCapturing_NPWG_Skill_State = "Press the [Night Parade of the White-Ghost] Skill key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Night Parade of the White-Ghost] Skill Key"))
            {
                IsCapturing_NPWG_Skill = false;
                custom_NPWG_Skill = -1;
                IsCapturing_NPWG_Skill_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_NPWG_Skill_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [FreedShadow] arrow key"))
            {
                IsCapturing_FreedShadow = true; // 칭호 변경키 캡처 시작
                IsCapturing_FreedShadow_State = "Press the [FreedShadow] arrow key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [FreedShadow] arrow key"))
            {
                IsCapturing_FreedShadow = false;
                custom_FreedShadow = -1;
                IsCapturing_FreedShadow_State = "Current keycode: None";

            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_FreedShadow_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [The_Setting_Sun] arrow key"))
            {
                IsCapturing_The_Setting_Sun = true; // 칭호 변경키 캡처 시작
                IsCapturing_The_Setting_Sun_State = "Press the [The_Setting_Sun] arrow key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [The_Setting_Sun] arrow key"))
            {
                IsCapturing_The_Setting_Sun = false;
                custom_The_Setting_Sun = -1;
                IsCapturing_The_Setting_Sun_State = "Current keycode: None";

            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_The_Setting_Sun_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [Natural Flow] arrow key"))
            {
                IsCapturing_Natural_Flow = true; // 칭호 변경키 캡처 시작
                IsCapturing_Natural_Flow_State = "Press the [Natural Flow] arrow key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Natural Flow] arrow key"))
            {
                IsCapturing_Natural_Flow = false;
                custom_Natural_Flow = -1;
                IsCapturing_Natural_Flow_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Natural_Flow_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [Awakening] key"))
            {
                IsCapturing_Awakening = true; // 칭호 변경키 캡처 시작
                IsCapturing_Awakening_State = "Press the [Awakening] key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Awakening] key"))
            {
                IsCapturing_Awakening = false;
                custom_Awakening = -1;
                IsCapturing_Awakening_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Awakening_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [Onion] key"))
            {
                IsCapturing_Onion = true; // 칭호 변경키 캡처 시작
                IsCapturing_Onion_State = "Press the [Onion] key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Onion] key"))
            {
                IsCapturing_Onion = false;
                custom_Onion = -1;
                IsCapturing_Onion_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Onion_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [Superhuman_Apple] key"))
            {
                IsCapturing_Superhuman_Apple = true; // 칭호 변경키 캡처 시작
                IsCapturing_Superhuman_Apple_State = "Press the [Superhuman_Apple] key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Superhuman_Apple] key"))
            {
                IsCapturing_Superhuman_Apple = false;
                custom_Superhuman_Apple = -1;
                IsCapturing_Superhuman_Apple_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Superhuman_Apple_State);
            ImGui.Text("---------------------------------------------------------------");



            if (ImGui.Button("Change [Timer_Reset] key"))
            {
                IsCapturing_Reset = true; // 칭호 변경키 캡처 시작
                IsCapturing_Reset_State = "Press the [Timer_Reset] key";
            }
            ImGui.SameLine();
            if (ImGui.Button("Reset [Timer_Reset] key"))
            {
                IsCapturing_Reset = true;
                custom_Reset = -1;
                IsCapturing_Reset_State = "Current keycode: None";
            }

            // 캡처한 키 값 출력
            ImGui.Text(IsCapturing_Reset_State);
            ImGui.Text("---------------------------------------------------------------");




            ImGui.Checkbox("Show [Night Parade of the White-Ghost]", ref state.ShowOverlaySample1);
            ImGui.Checkbox("Show [FreedShadow]", ref state.ShowOverlaySample2);
            ImGui.Checkbox("Show [The_Setting_Sun]", ref state.ShowOverlaySample3);




            ImGui.InputText("Plz input Preset Name", ref presetFileName, 100);

            // 저장 버튼
            if (ImGui.Button("Save Preset"))
            {
                SavePreset();
                LoadPresetFiles(); // 저장 후 파일 목록 업데이트
            }

            // 불러오기 버튼
            if (presetFiles.Count > 0) // 파일이 존재할 때만 콤보 박스 표시
            {

                ImGui.Combo("Load Preset", ref selectedPresetIndex, presetFiles.ToArray(), presetFiles.Count);
                if (ImGui.Button("Load Selected Preset"))
                {
                    LoadPreset(presetFiles[selectedPresetIndex]);
                }
            }



            ImGui.End();
        }

        private void RenderOverlay_Freed_Shadow()
        {

            ImGui.Begin(
                "Freed_Shadow",
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.AlwaysAutoResize |
                ImGuiWindowFlags.NoResize);


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
                    ImGui.Image(imgPtr, new Vector2(w, h));

                    // 이미지 옆에 FreedShadow_Count 표시
                    ImGui.SetWindowFontScale(5.0f); // 스케일 조정 (1.5배)
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
                    ImGui.Image(imgPtr, new Vector2(w, h));

                    ImGui.SetWindowFontScale(5.0f); // 스케일 조정 (1.5배)
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

            ImGui.Begin(
                "NPWG",
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.AlwaysAutoResize |
                ImGuiWindowFlags.NoResize);


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
                    ImGui.Image(imgPtr, new Vector2(w, h));

                    ImGui.SetWindowFontScale(5.0f); // 스케일 조정 (1.5배)
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
                    ImGui.Image(imgPtr, new Vector2(w, h));

                    ImGui.SetWindowFontScale(5.0f); // 스케일 조정 (1.5배)
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

            ImGui.Begin(
                "The_Setting_Sun",
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.AlwaysAutoResize |
                ImGuiWindowFlags.NoResize);


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
                    ImGui.Image(imgPtr, new Vector2(w, h));

                    ImGui.SetWindowFontScale(5.0f); // 스케일 조정 (1.5배)
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
                    ImGui.Image(imgPtr, new Vector2(w, h));

                    ImGui.SetWindowFontScale(5.0f); // 스케일 조정 (1.5배)
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

            if (IsCapturing_Minimize && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_Minimize = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Minimize = false; // 키 캡처 상태 종료
                Minimize_count = 0;
                IsCapturing_Minimize_State = $"Current keycode: {(Keys)custom_Minimize}";
            }
            else if (IsCapturing_Switching && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_ChangeTitle = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Switching = false; // 키 캡처 상태 종료
                IsCapturing_Switching_State = $"Current keycode: {(Keys)custom_ChangeTitle}";
            }
            else if (IsCapturing_NPWG && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_NPWG = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_NPWG = false; // 키 캡처 상태 종료
                IsCapturing_NPWG_State = $"Current keycode: {(Keys)custom_NPWG}";
            }
            else if (IsCapturing_NPWG_Skill && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_NPWG_Skill = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_NPWG_Skill = false; // 키 캡처 상태 종료
                IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)custom_NPWG_Skill}";
            }
            else if (IsCapturing_FreedShadow && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_FreedShadow = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_FreedShadow = false; // 키 캡처 상태 종료
                IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)custom_FreedShadow}";
            }
            else if (IsCapturing_The_Setting_Sun && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_The_Setting_Sun = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_The_Setting_Sun = false; // 키 캡처 상태 종료
                IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)custom_The_Setting_Sun}";
            }
            else if (IsCapturing_Natural_Flow && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_Natural_Flow = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Natural_Flow = false; // 키 캡처 상태 종료
                IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)custom_Natural_Flow}";
            }
            else if (IsCapturing_Awakening && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_Awakening = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Awakening = false; // 키 캡처 상태 종료
                IsCapturing_Awakening_State = $"Current keycode: {(Keys)custom_Awakening}";
            }
            else if (IsCapturing_Onion && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_Onion = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Onion = false; // 키 캡처 상태 종료
                IsCapturing_Onion_State = $"Current keycode: {(Keys)custom_Onion}";
            }
            else if (IsCapturing_Superhuman_Apple && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_Superhuman_Apple = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Superhuman_Apple = false; // 키 캡처 상태 종료
                IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)custom_Superhuman_Apple}";
            }
            else if (IsCapturing_Reset && code >= 0)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                custom_Reset = keyCode; // 캡처한 키 코드를 저장
                IsCapturing_Reset = false; // 키 캡처 상태 종료
                IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";
            }


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
                        NPWG_Count = 25;
                        timer_NPWG.Change(0, 1000);
                    }
                }
                else if ((keyCode == custom_Awakening || keyCode == custom_Onion || keyCode == custom_Superhuman_Apple) && title_Desc == "FreedShadow")
                {
                    if (FreedShadow_Count <= 0)
                    {
                        FreedShadow_Count = 60;
                        timer_FreedShadow.Change(0, 1000);
                    }
                }
                else if ((keyCode == custom_Awakening || keyCode == custom_Onion || keyCode == custom_Superhuman_Apple) && title_Desc == "The_Setting_Sun")
                {
                    if (The_Setting_Sun_Count <= 0)
                    {
                        The_Setting_Sun_Count = 30;
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


