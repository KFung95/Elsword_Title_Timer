
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClickableTransparentOverlay;
using ImGuiNET;
using System.Numerics;


namespace _Elsword__Title_Timer
{

    public unsafe class TimerOverlay : Overlay
    {


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
        public static bool Use_NPWG_FOD = false;
        public static bool Use_FreedShadow_FOD = false;
        public static bool Use_Dusk_FOD = false;
        public static bool ADD_User = false;


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
        public bool form_Use_NPWG_FOD = false;
        public bool form_Use_FreedShadow_FOD = false;
        public bool form_Use_Dusk_FOD = false;
        public bool form_ADD_User = false;
        public bool allowResize = false;
        public bool IsRunning = true;


        private static int awakening_Count = 1;

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
            Use_NPWG_FOD = form_Use_NPWG_FOD;
            Use_FreedShadow_FOD = form_Use_FreedShadow_FOD;
            Use_Dusk_FOD = form_Use_Dusk_FOD;
            ADD_User = form_ADD_User;
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
                else if (keyCode == custom_NPWG_Skill && title_Desc == "NPWG" && !Use_NPWG_FOD)
                {
                    if (NPWG_Count <= 0)
                    {
                        NPWG_Count = 26;
                        timer_NPWG.Change(0, 1000);
                    }
                }
                else if (keyCode == custom_Awakening && !Use_NPWG_FOD)
                {
                    if (ADD_User)
                    {
                        if (awakening_Count == 1)
                        {
                            if (title_Desc == "FreedShadow")
                            {
                                if (FreedShadow_Count <= 0)
                                {
                                    FreedShadow_Count = 61;
                                    timer_FreedShadow.Change(0, 1000);
                                }
                            }
                            else if (title_Desc == "The_Setting_Sun")
                            {
                                if (The_Setting_Sun_Count <= 0)
                                {
                                    The_Setting_Sun_Count = 31;
                                    timer_The_Setting_Sun.Change(0, 1000);
                                }
                            }

                            awakening_Count = 0;
                        }
                        else
                        {
                            awakening_Count++;
                        }

                    }
                    else
                    {
                        if (title_Desc == "FreedShadow")
                        {
                            if (FreedShadow_Count <= 0)
                            {
                                FreedShadow_Count = 61;
                                timer_FreedShadow.Change(0, 1000);
                            }
                        }
                        else if (title_Desc == "The_Setting_Sun")
                        {
                            if (The_Setting_Sun_Count <= 0)
                            {
                                The_Setting_Sun_Count = 31;
                                timer_The_Setting_Sun.Change(0, 1000);
                            }
                        }
                    }
                }


                else if ((keyCode == custom_Onion || keyCode == custom_Superhuman_Apple) && title_Desc == "FreedShadow" && !Use_NPWG_FOD)
                {
                    if (FreedShadow_Count <= 0)
                    {
                        FreedShadow_Count = 61;
                        timer_FreedShadow.Change(0, 1000);
                    }
                }
                else if ((keyCode == custom_Onion || keyCode == custom_Superhuman_Apple) && title_Desc == "The_Setting_Sun" && !Use_NPWG_FOD)
                {
                    if (The_Setting_Sun_Count <= 0)
                    {
                        The_Setting_Sun_Count = 31;
                        timer_The_Setting_Sun.Change(0, 1000);
                    }
                }
                else if (keyCode == custom_FOD && Use_NPWG_FOD)
                {
                    if (title_Desc == "NPWG")
                    {
                        if (NPWG_Count <= 0)
                        {
                            NPWG_Count = 26;
                            timer_NPWG.Change(0, 1000);
                        }
                    }
                    else if (title_Desc == "FreedShadow")
                    {
                        if (FreedShadow_Count <= 0)
                        {
                            FreedShadow_Count = 61;
                            timer_FreedShadow.Change(0, 1000);
                        }
                    }
                    else if (title_Desc == "The_Setting_Sun")
                    {
                        if (The_Setting_Sun_Count <= 0)
                        {
                            The_Setting_Sun_Count = 31;
                            timer_The_Setting_Sun.Change(0, 1000);
                        }
                    }
                }
                else if (keyCode == custom_Reset)
                {

                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);
                    NPWG_Count = 0;
                    FreedShadow_Count = 0;
                    The_Setting_Sun_Count = 0;
                    awakening_Count = 1;

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


