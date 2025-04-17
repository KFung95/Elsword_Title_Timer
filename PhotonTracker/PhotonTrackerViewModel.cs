using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace PhotonTracker
{
    public class PhotonTrackerViewModel : INotifyPropertyChanged
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

            IsCapturing_Switching_State = $"Current keycode: {(Keys)custom_ChangeTitle}";
            IsCapturing_NPWG_State = $"Current keycode: {(Keys)custom_NPWG}";
            IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)custom_NPWG_Skill}";
            IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)custom_FreedShadow}";
            IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)custom_The_Setting_Sun}";
            IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)custom_Natural_Flow}";
            IsCapturing_Awakening_State = $"Current keycode: {(Keys)custom_Awakening}";
            IsCapturing_Onion_State = $"Current keycode: {(Keys)custom_Onion}";
            IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)custom_Superhuman_Apple}";
            IsCapturing_Passive_State = $"Current keycode: {(Keys)custom_Passive_Key}";
            IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";

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
                }
                else if (theme?.Content?.ToString() == "Dark")
                {
                    AppBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#352F44"));
                    TimerPanelColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5C5470"));
                    TimerPanelTextColor = new SolidColorBrush(Colors.WhiteSmoke);
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
                writer.WriteLine(custom_ChangeTitle);
                writer.WriteLine(custom_NPWG);
                writer.WriteLine(custom_NPWG_Skill);
                writer.WriteLine(custom_FreedShadow);
                writer.WriteLine(custom_The_Setting_Sun);
                writer.WriteLine(custom_Natural_Flow);
                writer.WriteLine(custom_Awakening);
                writer.WriteLine(custom_Onion);
                writer.WriteLine(custom_Superhuman_Apple);
                writer.WriteLine(custom_Passive);
                writer.WriteLine(custom_Passive_Key);
                writer.WriteLine(custom_Reset);
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
                        custom_Passive = int.Parse(reader.ReadLine());
                        _passiveTimerValue = custom_Passive;
                        custom_Passive_Key = int.Parse(reader.ReadLine());
                        IsCapturing_Passive_State = $"Current keycode: {(Keys)custom_Passive_Key}";
                        custom_Reset = int.Parse(reader.ReadLine());
                        IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";
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

        private ICommand _bindTitleSwitchKeyCommand;
        public ICommand BindTitleSwitchKeyCommand
        {
            get
            {
                return _bindTitleSwitchKeyCommand ?? (_bindTitleSwitchKeyCommand = new CommandHandler(() => BindTitleSwitchKey(), () => { return true; }));
            }
        }

        public void BindTitleSwitchKey()
        {
            IsCapturing_Switching_State = "Press the [Title] switching key";
            IsCapturing_Switching = true;
        }

        private ICommand _bindNightParadeArrowKeyCommand;
        public ICommand BindNightParadeArrowKeyCommand
        {
            get
            {
                return _bindNightParadeArrowKeyCommand ?? (_bindNightParadeArrowKeyCommand = new CommandHandler(() => BindNightParadeArrowKey(), () => { return true; }));
            }
        }

        public void BindNightParadeArrowKey()
        {
            IsCapturing_NPWG_State = "Press the [Night Parade of the White-Ghost] arrow key";
            IsCapturing_NPWG = true;
        }

        private ICommand _bindNightParadeSkillKeyCommand;
        public ICommand BindNightParadeSkillKeyCommand
        {
            get
            {
                return _bindNightParadeSkillKeyCommand ?? (_bindNightParadeSkillKeyCommand = new CommandHandler(() => BindNightParadeSkillKey(), () => { return true; }));
            }
        }

        public void BindNightParadeSkillKey()
        {
            IsCapturing_NPWG_Skill_State = "Press the [Night Parade of the White-Ghost] skill key";
            IsCapturing_NPWG_Skill = true;
        }

        private ICommand _bindFreedShadowArrowKeyCommand;
        public ICommand BindFreedShadowArrowKeyCommand
        {
            get
            {
                return _bindFreedShadowArrowKeyCommand ?? (_bindFreedShadowArrowKeyCommand = new CommandHandler(() => BindFreedShadowArrowKey(), () => { return true; }));
            }
        }

        public void BindFreedShadowArrowKey()
        {
            IsCapturing_FreedShadow_State = "Press the [Freed Shadow] arrow key";
            IsCapturing_FreedShadow = true;
        }

        private ICommand _bindSettingSunArrowKeyCommand;
        public ICommand BindSettingSunArrowKeyCommand
        {
            get
            {
                return _bindSettingSunArrowKeyCommand ?? (_bindSettingSunArrowKeyCommand = new CommandHandler(() => BindSettingSunArrowKey(), () => { return true; }));
            }
        }

        public void BindSettingSunArrowKey()
        {
            IsCapturing_The_Setting_Sun_State = "Press the [The Setting Sun] arrow key";
            IsCapturing_The_Setting_Sun = true;
        }

        private ICommand _bindNaturalFlowArrowKeyCommand;
        public ICommand BindNaturalFlowArrowKeyCommand
        {
            get
            {
                return _bindNaturalFlowArrowKeyCommand ?? (_bindNaturalFlowArrowKeyCommand = new CommandHandler(() => BindNaturalFlowArrowKey(), () => { return true; }));
            }
        }

        public void BindNaturalFlowArrowKey()
        {
            IsCapturing_Natural_Flow_State = "Press the [Natural Flow] arrow key";
            IsCapturing_Natural_Flow = true;
        }

        private ICommand _bindAwakeningKeyCommand;
        public ICommand BindAwakeningKeyCommand
        {
            get
            {
                return _bindAwakeningKeyCommand ?? (_bindAwakeningKeyCommand = new CommandHandler(() => BindAwakeningKey(), () => { return true; }));
            }
        }

        public void BindAwakeningKey()
        {
            IsCapturing_Awakening_State = "Press the [Awakening] key";
            IsCapturing_Awakening = true;
        }

        private ICommand _bindOnionKeyCommand;
        public ICommand BindOnionKeyCommand
        {
            get
            {
                return _bindOnionKeyCommand ?? (_bindOnionKeyCommand = new CommandHandler(() => BindOnionKey(), () => { return true; }));
            }
        }

        public void BindOnionKey()
        {
            IsCapturing_Onion_State = "Press the [Onion] key";
            IsCapturing_Onion = true;
        }

        private ICommand _bindSuperhumanAppleKeyCommand;
        public ICommand BindSuperhumanAppleKeyCommand
        {
            get
            {
                return _bindSuperhumanAppleKeyCommand ?? (_bindSuperhumanAppleKeyCommand = new CommandHandler(() => BindSuperhumanAppleKey(), () => { return true; }));
            }
        }

        public void BindSuperhumanAppleKey()
        {
            IsCapturing_Superhuman_Apple_State = "Press the [Superhuman Apple] key";
            IsCapturing_Superhuman_Apple = true;
        }

        private ICommand _bindPassiveKeyCommand;
        public ICommand BindPassiveKeyCommand
        {
            get
            {
                return _bindPassiveKeyCommand ?? (_bindPassiveKeyCommand = new CommandHandler(() => BindPassiveKey(), () => { return true; }));
            }
        }

        public void BindPassiveKey()
        {
            IsCapturing_Passive_State = "Press the [Passive] key";
            IsCapturing_Passive = true;
        }

        private ICommand _bindResetKeyCommand;
        public ICommand BindResetKeyCommand
        {
            get
            {
                return _bindResetKeyCommand ?? (_bindResetKeyCommand = new CommandHandler(() => BindResetKey(), () => { return true; }));
            }
        }

        public void BindResetKey()
        {
            IsCapturing_Reset_State = "Press the [Reset] key";
            IsCapturing_Reset = true;
        }

        #endregion

        #region Command Handler
        public class CommandHandler : ICommand
        {
            private Action _action;
            private Func<bool> _canExecute;

            /// <summary>
            /// Creates instance of the command handler
            /// </summary>
            /// <param name="action">Action to be executed by the command</param>
            /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
            public CommandHandler(Action action, Func<bool> canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            /// <summary>
            /// Wires CanExecuteChanged event 
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            /// <summary>
            /// Forcess checking if execute is allowed
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool CanExecute(object parameter)
            {
                return _canExecute.Invoke();
            }

            public void Execute(object parameter)
            {
                _action();
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

        public static int PassiveTimerValue
        {
            get => _passiveTimerValue;
            set
            {
                if (_passiveTimerValue != value)
                {
                    _passiveTimerValue = value;
                    custom_Passive = value;
                    NotifyStaticPropertyChanged(nameof(PassiveTimerValue));
                }
            }
        }

        #endregion

        #region PropertyChanged
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
            if (propertyChangedEventHandler != null)
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Labels/Key Text

        private static int custom_ChangeTitle;
        private static int custom_NPWG;
        private static int custom_NPWG_Skill;
        private static int custom_FreedShadow;
        private static int custom_The_Setting_Sun;
        private static int custom_Natural_Flow;
        private static int custom_Awakening;
        private static int custom_Onion;
        private static int custom_Superhuman_Apple;
        private static int custom_Passive = 0;
        private static int custom_Passive_Key;
        private static int custom_Reset;

        public static bool IsCapturing_Switching = false;
        private static string _isCapturing_Switching_State;
        public static string IsCapturing_Switching_State
        {
            get => _isCapturing_Switching_State;
            set
            {
                if (_isCapturing_Switching_State != value)
                {
                    _isCapturing_Switching_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Switching_State));
                }
            }
        }

        public static bool IsCapturing_NPWG = false;
        private static string _isCapturing_NPWG_State;
        public static string IsCapturing_NPWG_State
        {
            get => _isCapturing_NPWG_State;
            set
            {
                if (_isCapturing_NPWG_State != value)
                {
                    _isCapturing_NPWG_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_NPWG_State));
                }
            }
        }

        public static bool IsCapturing_NPWG_Skill = false;
        private static string _isCapturing_NPWG_Skill_State;
        public static string IsCapturing_NPWG_Skill_State
        {
            get => _isCapturing_NPWG_Skill_State;
            set
            {
                if (_isCapturing_NPWG_Skill_State != value)
                {
                    _isCapturing_NPWG_Skill_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_NPWG_Skill_State));
                }
            }
        }

        public static bool IsCapturing_FreedShadow = false;
        private static string _isCapturing_FreedShadow_State;
        public static string IsCapturing_FreedShadow_State
        {
            get => _isCapturing_FreedShadow_State;
            set
            {
                if (_isCapturing_FreedShadow_State != value)
                {
                    _isCapturing_FreedShadow_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_FreedShadow_State));
                }
            }
        }

        public static bool IsCapturing_The_Setting_Sun = false;
        private static string _isCapturing_The_Setting_Sun_State;
        public static string IsCapturing_The_Setting_Sun_State
        {
            get => _isCapturing_The_Setting_Sun_State;
            set
            {
                if (_isCapturing_The_Setting_Sun_State != value)
                {
                    _isCapturing_The_Setting_Sun_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_The_Setting_Sun_State));
                }
            }
        }
        public static bool IsCapturing_Natural_Flow = false;
        private static string _isCapturing_Natural_Flow_State;
        public static string IsCapturing_Natural_Flow_State
        {
            get => _isCapturing_Natural_Flow_State;
            set
            {
                if (_isCapturing_Natural_Flow_State != value)
                {
                    _isCapturing_Natural_Flow_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Natural_Flow_State));
                }
            }
        }
        public static bool IsCapturing_Awakening = false;
        private static string _isCapturing_Awakening_State;
        public static string IsCapturing_Awakening_State
        {
            get => _isCapturing_Awakening_State;
            set
            {
                if (_isCapturing_Awakening_State != value)
                {
                    _isCapturing_Awakening_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Awakening_State));
                }
            }
        }
        public static bool IsCapturing_Onion = false;
        private static string _isCapturing_Onion_State;
        public static string IsCapturing_Onion_State
        {
            get => _isCapturing_Onion_State;
            set
            {
                if (_isCapturing_Onion_State != value)
                {
                    _isCapturing_Onion_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Onion_State));
                }
            }
        }

        public static bool IsCapturing_Superhuman_Apple = false;
        private static string _isCapturing_Superhuman_Apple_State;
        public static string IsCapturing_Superhuman_Apple_State
        {
            get => _isCapturing_Superhuman_Apple_State;
            set
            {
                if (_isCapturing_Superhuman_Apple_State != value)
                {
                    _isCapturing_Superhuman_Apple_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Superhuman_Apple_State));
                }
            }
        }

        public static bool IsCapturing_Passive = false;
        private static string _isCapturing_Passive_State;
        public static string IsCapturing_Passive_State
        {
            get => _isCapturing_Passive_State;
            set
            {
                if (_isCapturing_Passive_State != value)
                {
                    _isCapturing_Passive_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Passive_State));
                }
            }
        }

        public static bool IsCapturing_Reset = false;
        private static string _isCapturing_Reset_State;
        public static string IsCapturing_Reset_State
        {
            get => _isCapturing_Reset_State;
            set
            {
                if (_isCapturing_Reset_State != value)
                {
                    _isCapturing_Reset_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_Reset_State));
                }
            }
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

            if (IsCapturing_Switching && code >= 0)
            {
                custom_ChangeTitle = keyCode; 
                IsCapturing_Switching = false; 
                IsCapturing_Switching_State = $"Current keycode: {(Keys)custom_ChangeTitle}";
            }
            else if (IsCapturing_NPWG && code >= 0)
            {
                custom_NPWG = keyCode;
                IsCapturing_NPWG = false; 
                IsCapturing_NPWG_State = $"Current keycode: {(Keys)custom_NPWG}";
            }
            else if (IsCapturing_NPWG_Skill && code >= 0)
            {
                custom_NPWG_Skill = keyCode;
                IsCapturing_NPWG_Skill = false;
                IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)custom_NPWG_Skill}";
            }
            else if (IsCapturing_FreedShadow && code >= 0)
            {
                custom_FreedShadow = keyCode; 
                IsCapturing_FreedShadow = false; 
                IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)custom_FreedShadow}";
            }
            else if (IsCapturing_The_Setting_Sun && code >= 0)
            {
                custom_The_Setting_Sun = keyCode; 
                IsCapturing_The_Setting_Sun = false;
                IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)custom_The_Setting_Sun}";
            }
            else if (IsCapturing_Natural_Flow && code >= 0)
            {
                custom_Natural_Flow = keyCode;
                IsCapturing_Natural_Flow = false; 
                IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)custom_Natural_Flow}";
            }
            else if (IsCapturing_Awakening && code >= 0)
            {
                custom_Awakening = keyCode;
                IsCapturing_Awakening = false; 
                IsCapturing_Awakening_State = $"Current keycode: {(Keys)custom_Awakening}";
            }
            else if (IsCapturing_Onion && code >= 0)
            {
                custom_Onion = keyCode;
                IsCapturing_Onion = false; 
                IsCapturing_Onion_State = $"Current keycode: {(Keys)custom_Onion}";
            }
            else if (IsCapturing_Superhuman_Apple && code >= 0)
            {
                custom_Superhuman_Apple = keyCode; 
                IsCapturing_Superhuman_Apple = false;
                IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)custom_Superhuman_Apple}";
            }
            else if (IsCapturing_Passive && code >= 0)
            {
                custom_Passive_Key = keyCode;
                IsCapturing_Passive = false;
                IsCapturing_Passive_State = $"Current keycode: {(Keys)custom_Passive_Key}";
            }
            else if (IsCapturing_Reset && code >= 0)
            {
                custom_Reset = keyCode;
                IsCapturing_Reset = false;
                IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";
            }


            if (code >= 0 && (int)wParam == 256)
            {
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
                    Passive_Count = 0;

                }
                if (keyCode == custom_Passive_Key)
                {
                    if (Passive_Count <= 0)
                    {
                        Passive_Count = _passiveTimerValue;
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
        private static int _passiveTimerValue = custom_Passive;
        private bool _showSettings;
        private static System.Threading.Timer timer_ChangeTitle = new System.Threading.Timer(TimerCallback_ChangeTitle, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_NPWG = new System.Threading.Timer(TimerCallback_NPWG, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_FreedShadow = new System.Threading.Timer(TimerCallback_FreedShadow, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_The_Setting_Sun = new System.Threading.Timer(TimerCallback_The_Setting_Sun, null, Timeout.Infinite, Timeout.Infinite);
        private static System.Threading.Timer timer_Passive = new System.Threading.Timer(TimerCallback_Passive, null, Timeout.Infinite, Timeout.Infinite);
        #endregion
    }
}
