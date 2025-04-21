using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PhotonTracker.common;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace PhotonTracker
{
    public class PhotonTrackerViewModel : NotifyViewModel, INotifyPropertyChanged
    {
        public const int DEFAULT_HEIGHT = 550;
        public const int DEFAULT_WIDTH = 800;
        public PhotonTrackerViewModel() 
        {
            WindowHeight = DEFAULT_HEIGHT;
            WindowWidth = DEFAULT_WIDTH;
            ShowSettings = true;
            ThemeList = new List<ComboBoxItem>
            {
                new ComboBoxItem() { Content = "Light" },
                new ComboBoxItem() { Content = "Dark" },
            };

            TheSettingSunImageSource = "images/The_Setting_Sun.png";
            NightParadeImageSource = "images/NPWG.png";
            FreedShadowImageSource = "images/FreedShadow.png";

            PresetList = Directory.GetFiles(presetDirectory, "*.txt")
                .Select(fileName => new ComboBoxItem { Content = Path.GetFileNameWithoutExtension(fileName) })
                .ToList();

            SelectedPreset = PresetList.FirstOrDefault()?.Content?.ToString() ?? "DefaultPreset";

            var filePath = Path.Combine(presetDirectory, presetFileName + ".txt");
            if (!Directory.Exists(presetDirectory))
                Directory.CreateDirectory(presetDirectory);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            LoadPreset();

            SetHook();
        }

        #region Commands

        public ComboBoxItem Theme
        {
            get => theme;
            set
            {
                theme = value;
                if (theme?.Content?.ToString() == "Light")
                {
                    AppBackgroundColor = new SolidColorBrush(Colors.Beige);
                    TimerPanelColor = new SolidColorBrush(Colors.WhiteSmoke);
                    TimerPanelTextColor = new SolidColorBrush(Colors.Black);
                    PhotonTrackerSettingsViewModel.TextColor = new SolidColorBrush(Colors.Black);
                }
                else if (theme?.Content?.ToString() == "Dark")
                {
                    AppBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#352F44"));
                    TimerPanelColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5C5470"));
                    TimerPanelTextColor = new SolidColorBrush(Colors.WhiteSmoke);
                    PhotonTrackerSettingsViewModel.TextColor = new SolidColorBrush(Colors.WhiteSmoke);
                }

                NotifyPropertyChanged(nameof(Theme));
            }
        }

        public ComboBoxItem Preset
        {
            get => preset;
            set
            {
                preset = value;
                SelectedPreset = preset?.Content?.ToString();
                NotifyPropertyChanged(nameof(Preset));
            }
        }

        public List<ComboBoxItem> ThemeList
        {
            get => themeList;
            set
            {
                themeList = value;
                NotifyPropertyChanged(nameof(ThemeList));
            }
        }

        public List<ComboBoxItem> PresetList
        {
            get => presetList;
            set
            {
                presetList = value;
                NotifyPropertyChanged(nameof(PresetList));
            }
        }

        public string SelectedPreset
        {
            get => selectedPreset;
            set
            {
                if (selectedPreset != value)
                {
                    selectedPreset = value;
                    NotifyPropertyChanged(nameof(SelectedPreset));

                    // Load the selected preset
                    presetFileName = selectedPreset; // Update the file name
                    LoadPreset();
                }
            }
        }

        public Brush AppBackgroundColor
        {
            get => appBackgroundColor;
            set
            {
                appBackgroundColor = value;
                NotifyPropertyChanged(nameof(AppBackgroundColor));
            }
        }

        public Brush TimerPanelColor
        {
            get => timerPanelColor;
            set
            {
                timerPanelColor = value;
                NotifyPropertyChanged(nameof(TimerPanelColor));
            }
        }

        public Brush TimerPanelTextColor
        {
            get => timerPanelTextColor;
            set
            {
                timerPanelTextColor = value;
                NotifyPropertyChanged(nameof(TimerPanelTextColor));
            }
        }

        private ICommand _savePresetCommand;
        public ICommand SavePresetCommand
        {
            get
            {
                return _savePresetCommand ?? (_savePresetCommand = new CommandHandler(() => SavePreset(), () => { return true; }));
            }
        }


        private ICommand _loadPresetCommand;
        public ICommand LoadPresetCommand
        {
            get
            {
                return _loadPresetCommand ?? (_loadPresetCommand = new CommandHandler(() => LoadPreset(), () => { return true; }));
            }
        }
        public void SavePreset()
        {
            string filePath = Path.Combine(presetDirectory, presetFileName + ".txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //writer.WriteLine(custom_Minimize);
                writer.WriteLine(Theme.Content.ToString());
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_ChangeTitle);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_NPWG);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_NPWG_Skill);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_FreedShadow);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_The_Setting_Sun);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Natural_Flow);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Awakening);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Onion);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Superhuman_Apple);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Passive);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Passive_Key);
                writer.WriteLine(PhotonTrackerSettingsViewModel.custom_Reset);
                writer.WriteLine(ShowSettings);
                writer.WriteLine(WindowHeight);
                writer.WriteLine(WindowWidth);
            }

            SaveSuccessfulMessage = "Preset saved!";
            Task.Run(async () => { await Task.Delay(3000); SaveSuccessfulMessage = string.Empty; });
        }

        private void LoadPreset()
        {
            string filePath = Path.Combine(presetDirectory, presetFileName + ".txt");
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        var themeColor = reader.ReadLine();
                        Theme = ThemeList.FirstOrDefault(t => t.Content.ToString() == themeColor) ?? ThemeList.FirstOrDefault();
                        PhotonTrackerSettingsViewModel.custom_ChangeTitle = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Switching_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_ChangeTitle}";
                        PhotonTrackerSettingsViewModel.custom_NPWG = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_NPWG_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_NPWG}";
                        PhotonTrackerSettingsViewModel.custom_NPWG_Skill = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_NPWG_Skill}";
                        PhotonTrackerSettingsViewModel.custom_FreedShadow = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_FreedShadow}";
                        PhotonTrackerSettingsViewModel.custom_The_Setting_Sun = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_The_Setting_Sun}";
                        PhotonTrackerSettingsViewModel.custom_Natural_Flow = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Natural_Flow}";
                        PhotonTrackerSettingsViewModel.custom_Awakening = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Awakening_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Awakening}";
                        PhotonTrackerSettingsViewModel.custom_Onion = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Onion_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Onion}";
                        PhotonTrackerSettingsViewModel.custom_Superhuman_Apple = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Superhuman_Apple}";
                        PhotonTrackerSettingsViewModel.custom_Passive = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel._passiveTimerValue = PhotonTrackerSettingsViewModel.custom_Passive;
                        PhotonTrackerSettingsViewModel.custom_Passive_Key = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Passive_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Passive_Key}";
                        PhotonTrackerSettingsViewModel.custom_Reset = int.Parse(reader.ReadLine());
                        PhotonTrackerSettingsViewModel.IsCapturing_Reset_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Reset}";
                        ShowSettings = bool.Parse(reader.ReadLine());
                        var height = int.Parse(reader.ReadLine());
                        var width = int.Parse(reader.ReadLine());
                        WindowHeight = height >= 10 ? height : DEFAULT_HEIGHT;
                        WindowWidth = width >= 10 ? width : DEFAULT_WIDTH;
                    }
                }
                else
                {
                    System.Console.WriteLine("Preset file not found!");
                }
            }
            catch (Exception ex)
            {
                //swallow exception, bad code practice but this isn't being a professional product being used so who cares 
                //Console.WriteLine(ex.ToString());
            }
        }

        #endregion

        #region Properties

        public int WindowHeight
        {
            get => windowHeight;
            set
            {
                if (windowHeight != value)
                {
                    windowHeight = value;
                    NotifyPropertyChanged(nameof(WindowHeight));
                }
            }
        }

        public int WindowWidth
        {
            get => windowWidth;
            set
            {
                if (windowWidth != value)
                {
                    windowWidth = value;
                    NotifyPropertyChanged(nameof(WindowWidth));
                }
            }
        }

        public bool ShowSettings
        {
            get => _showSettings;
            set
            {
                if (_showSettings != value)
                {
                    _showSettings = value;
                    NotifyPropertyChanged(nameof(ShowSettings));
                }
            }
        }

        public PhotonTrackerSettingsViewModel SettingsVM { get; set; } = new PhotonTrackerSettingsViewModel();

        public string SaveSuccessfulMessage
        {
            get => _saveSuccessfulMessage;
            set
            {
                if (_saveSuccessfulMessage != value)
                {
                    _saveSuccessfulMessage = value;
                    NotifyPropertyChanged(nameof(SaveSuccessfulMessage));
                }
            }
        }

        public static string TheSettingSunImageSource
        {
            get => _theSettingSunImageSource;
            set
            {
                if (_theSettingSunImageSource != value)
                {
                    _theSettingSunImageSource = value;
                    NotifyStaticPropertyChanged(nameof(TheSettingSunImageSource));
                }
            }
        }

        public static string NightParadeImageSource
        {
            get => _nightParadeImageSource;
            set
            {
                if (_nightParadeImageSource != value)
                {
                    _nightParadeImageSource = value;
                    NotifyStaticPropertyChanged(nameof(NightParadeImageSource));
                }
            }
        }

        public static string FreedShadowImageSource
        {
            get => _freedShadowImageSource;
            set
            {
                if (_freedShadowImageSource != value)
                {
                    _freedShadowImageSource = value;
                    NotifyStaticPropertyChanged(nameof(FreedShadowImageSource));
                }
            }
        }

        public static int NPWG_Count
        {
            get => _npwg_Count;
            set
            {
                if (_npwg_Count != value)
                {
                    _npwg_Count = value;
                    NotifyStaticPropertyChanged(nameof(NPWG_Count));

                    NightParadeImageSource = (_npwg_Count > 0) ? "images/NPWG_GrayScale.png" : "images/NPWG.png";
                }
            }
        }

        public static int FreedShadow_Count
        {
            get => _freedShadow_Count;
            set
            {
                if (_freedShadow_Count != value)
                {
                    _freedShadow_Count = value;
                    NotifyStaticPropertyChanged(nameof(FreedShadow_Count));

                    FreedShadowImageSource = (_freedShadow_Count > 0) ? "images/FreedShadow_GrayScale.png" : "images/FreedShadow.png";
                }
            }
        }

        public static int The_Setting_Sun_Count
        {
            get => _theSettingSun_Count;
            set
            {
                if (_theSettingSun_Count != value)
                {
                    _theSettingSun_Count = value;
                    NotifyStaticPropertyChanged(nameof(The_Setting_Sun_Count));

                    TheSettingSunImageSource = (_theSettingSun_Count > 0) ? "images/The_Setting_Sun_GrayScale.png" : "images/The_Setting_Sun.png";
                }
            }
        }

        public static int Passive_Count
        {
            get => _passive_Count;
            set
            {
                if (_passive_Count != value)
                {
                    _passive_Count = value;
                    NotifyStaticPropertyChanged(nameof(Passive_Count));
                }
            }
        }

        #endregion

        #region PropertyChanged

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Key logging

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wearable, IntPtr lParam);
        private static LowLevelKeyboardProc keyboardProc = KeyboardHookProc;
        private static IntPtr keyHook = IntPtr.Zero;
        private const int WH_KEYBOARD_LL = 13;
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr IdHook, int nCode, IntPtr wParam, IntPtr IParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint Threadld);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string ipModuleName);

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
            int keyCode = Marshal.ReadInt32(lParam);

            if (PhotonTrackerSettingsViewModel.IsCapturing_Switching && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_ChangeTitle = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Switching = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Switching_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_ChangeTitle}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_NPWG && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_NPWG = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_NPWG = false;
                PhotonTrackerSettingsViewModel.IsCapturing_NPWG_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_NPWG}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_NPWG_Skill && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_NPWG_Skill = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_NPWG_Skill = false;
                PhotonTrackerSettingsViewModel.IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_NPWG_Skill}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_FreedShadow && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_FreedShadow = keyCode; 
                PhotonTrackerSettingsViewModel.IsCapturing_FreedShadow = false; 
                PhotonTrackerSettingsViewModel.IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_FreedShadow}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_The_Setting_Sun && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_The_Setting_Sun = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_The_Setting_Sun = false;
                PhotonTrackerSettingsViewModel.IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_The_Setting_Sun}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_Natural_Flow && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_Natural_Flow = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Natural_Flow = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Natural_Flow}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_Awakening && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_Awakening = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Awakening = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Awakening_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Awakening}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_Onion && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_Onion = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Onion = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Onion_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Onion}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_Superhuman_Apple && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_Superhuman_Apple = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Superhuman_Apple = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Superhuman_Apple}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_Passive && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_Passive_Key = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Passive = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Passive_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Passive_Key}";
            }
            else if (PhotonTrackerSettingsViewModel.IsCapturing_Reset && code >= 0)
            {
                PhotonTrackerSettingsViewModel.custom_Reset = keyCode;
                PhotonTrackerSettingsViewModel.IsCapturing_Reset = false;
                PhotonTrackerSettingsViewModel.IsCapturing_Reset_State = $"Current keycode: {(Keys)PhotonTrackerSettingsViewModel.custom_Reset}";
            }


            if (code >= 0 && (int)wParam == 256)
            {
                if (keyCode == PhotonTrackerSettingsViewModel.custom_ChangeTitle)
                {

                    isChangeTitlePressed = true;

                    timer_ChangeTitle.Change(3000, Timeout.Infinite);
                }
                else if (keyCode == PhotonTrackerSettingsViewModel.custom_NPWG && isChangeTitlePressed)
                {
                    title_Desc = "NPWG";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);

                }
                else if (keyCode == PhotonTrackerSettingsViewModel.custom_FreedShadow && isChangeTitlePressed)
                {
                    title_Desc = "FreedShadow";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);

                }
                else if (keyCode == PhotonTrackerSettingsViewModel.custom_Natural_Flow && isChangeTitlePressed)
                {
                    title_Desc = "Natural Flow";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);
                }
                else if (keyCode == PhotonTrackerSettingsViewModel.custom_The_Setting_Sun && isChangeTitlePressed)
                {
                    title_Desc = "The_Setting_Sun";
                    isChangeTitlePressed = false;
                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);

                }
                else if (keyCode == PhotonTrackerSettingsViewModel.custom_NPWG_Skill && title_Desc == "NPWG")
                {
                    if (NPWG_Count <= 0)
                    {
                        NPWG_Count = 26;
                        timer_NPWG.Change(0, 1000);
                    }
                }
                else if ((keyCode == PhotonTrackerSettingsViewModel.custom_Awakening || keyCode == PhotonTrackerSettingsViewModel.custom_Onion || keyCode == PhotonTrackerSettingsViewModel.custom_Superhuman_Apple) && title_Desc == "FreedShadow")
                {
                    if (FreedShadow_Count <= 0)
                    {
                        FreedShadow_Count = 61;
                        timer_FreedShadow.Change(0, 1000);
                    }
                }
                else if ((keyCode == PhotonTrackerSettingsViewModel.custom_Awakening || keyCode == PhotonTrackerSettingsViewModel.custom_Onion || keyCode == PhotonTrackerSettingsViewModel.custom_Superhuman_Apple) && title_Desc == "The_Setting_Sun")
                {
                    if (The_Setting_Sun_Count <= 0)
                    {
                        The_Setting_Sun_Count = 30;
                        timer_The_Setting_Sun.Change(0, 1000);
                    }
                }
                else if (keyCode == PhotonTrackerSettingsViewModel.custom_Reset)
                {

                    timer_ChangeTitle.Change(Timeout.Infinite, Timeout.Infinite);
                    NPWG_Count = 0;
                    FreedShadow_Count = 0;
                    The_Setting_Sun_Count = 0;
                    Passive_Count = 0;

                }
                if (keyCode == PhotonTrackerSettingsViewModel.custom_Passive_Key)
                {
                    if (Passive_Count <= 0)
                    {
                        Passive_Count = PhotonTrackerSettingsViewModel._passiveTimerValue + 1;
                        timer_Passive.Change(0, 1000);
                    }
                }
            }

            return CallNextHookEx(keyHook, code, wParam, lParam);
        }

        #endregion

        #region Timer Callback
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

        private static void TimerCallback_The_Setting_Sun(object state)
        {

            if (The_Setting_Sun_Count > 0)
            {
                The_Setting_Sun_Count--;
            }

        }

        private static void TimerCallback_Passive(object state)
        {

            if (Passive_Count > 0)
            {
                Passive_Count--;
            }

        }

        #endregion

        #region Private variables
        private int windowHeight;
        private int windowWidth;
        private static bool isChangeTitlePressed = false;
        private static string title_Desc = "FreedShadow";
        private ComboBoxItem theme;
        private ComboBoxItem preset;
        private List<ComboBoxItem> themeList;
        private List<ComboBoxItem> presetList;
        private string selectedPreset;
        private Brush appBackgroundColor;
        private Brush timerPanelColor;
        private Brush timerPanelTextColor;
        private string presetDirectory = "presets";
        private string presetFileName;
        private string _saveSuccessfulMessage;
        private static string _theSettingSunImageSource;
        private static string _nightParadeImageSource;
        private static string _freedShadowImageSource;
        private static int _npwg_Count = 0;
        private static int _freedShadow_Count = 0;
        private static int _theSettingSun_Count = 0;
        private static int _passive_Count = 0;
        private bool _showSettings;
        private static System.Threading.Timer timer_ChangeTitle = new System.Threading.Timer(TimerCallback_ChangeTitle, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_NPWG = new System.Threading.Timer(TimerCallback_NPWG, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_FreedShadow = new System.Threading.Timer(TimerCallback_FreedShadow, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_The_Setting_Sun = new System.Threading.Timer(TimerCallback_The_Setting_Sun, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_Passive = new System.Threading.Timer(TimerCallback_Passive, null, Timeout.Infinite, Timeout.Infinite);
        #endregion
    }
}
