using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhotonTracker.common;
using Brush = System.Windows.Media.Brush;

namespace PhotonTracker
{
    public class PhotonTrackerSettingsViewModel : NotifyViewModel
    {

        public PhotonTrackerSettingsViewModel()
        {
            IsCapturing_Switching_State = $"Current keycode: {(Keys)custom_ChangeTitle}";
            IsCapturing_NPWG_State = $"Current keycode: {(Keys)custom_NPWG}";
            IsCapturing_NPWG_Skill_State = $"Current keycode: {(Keys)custom_NPWG_Skill}";
            IsCapturing_NPWG_2_State = $"Current keycode: {(Keys)custom_NPWG_2}";
            IsCapturing_NPWG_Skill_2_State = $"Current keycode: {(Keys)custom_NPWG_Skill_2}";
            IsCapturing_FreedShadow_State = $"Current keycode: {(Keys)custom_FreedShadow}";
            IsCapturing_The_Setting_Sun_State = $"Current keycode: {(Keys)custom_The_Setting_Sun}";
            IsCapturing_Natural_Flow_State = $"Current keycode: {(Keys)custom_Natural_Flow}";
            IsCapturing_Awakening_State = $"Current keycode: {(Keys)custom_Awakening}";
            IsCapturing_Onion_State = $"Current keycode: {(Keys)custom_Onion}";
            IsCapturing_Superhuman_Apple_State = $"Current keycode: {(Keys)custom_Superhuman_Apple}";
            IsCapturing_Passive_State = $"Current keycode: {(Keys)custom_Passive_Key}";
            IsCapturing_Reset_State = $"Current keycode: {(Keys)custom_Reset}";
        }

        private static Brush textColor;
        public static Brush TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                NotifyStaticPropertyChanged(nameof(TextColor));
            }
        }

        #region Commands

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

        private ICommand _bindNightParadeSkill2KeyCommand;
        public ICommand BindNightParadeSkill2KeyCommand
        {
            get
            {
                return _bindNightParadeSkill2KeyCommand ?? (_bindNightParadeSkill2KeyCommand = new CommandHandler(() => BindNightParadeSkill2Key(), () => { return true; }));
            }
        }

        public void BindNightParadeSkillKey()
        {
            IsCapturing_NPWG_Skill_State = "Press the [Night Parade of the White-Ghost] skill key";
            IsCapturing_NPWG_Skill = true;
        }

        public void BindNightParadeSkill2Key()
        {
            IsCapturing_NPWG_Skill_2_State = "Press the [Night Parade of the White-Ghost] second skill key";
            IsCapturing_NPWG_Skill_2 = true;
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

        #region PropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Labels/Key Text

        public static int custom_ChangeTitle;
        public static int custom_NPWG;
        public static int custom_NPWG_2;
        public static int custom_NPWG_Skill;
        public static int custom_NPWG_Skill_2;
        public static int custom_FreedShadow;
        public static int custom_The_Setting_Sun;
        public static int custom_Natural_Flow;
        public static int custom_Awakening;
        public static int custom_Onion;
        public static int custom_Superhuman_Apple;
        public static int custom_Passive = 0;
        public static int custom_Passive_Key;
        public static int custom_Reset;

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

        public static bool IsCapturing_NPWG_2 = false;
        private static string _isCapturing_NPWG_2_State;
        public static string IsCapturing_NPWG_2_State
        {
            get => _isCapturing_NPWG_2_State;
            set
            {
                if (_isCapturing_NPWG_2_State != value)
                {
                    _isCapturing_NPWG_2_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_NPWG_2_State));
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

        public static bool IsCapturing_NPWG_Skill_2 = false;
        private static string _isCapturing_NPWG_Skill_2_State;
        public static string IsCapturing_NPWG_Skill_2_State
        {
            get => _isCapturing_NPWG_Skill_2_State;
            set
            {
                if (_isCapturing_NPWG_Skill_2_State != value)
                {
                    _isCapturing_NPWG_Skill_2_State = value;
                    NotifyStaticPropertyChanged(nameof(IsCapturing_NPWG_Skill_2_State));
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

        public static int _passiveTimerValue = custom_Passive;
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

        public bool ShowTSSPanel
        {
            get => _showTSSPanel;
            set
            {
                if (_showTSSPanel != value)
                {
                    _showTSSPanel = value;
                    NotifyPropertyChanged(nameof(ShowTSSPanel));
                }
            }
        }

        public bool ShowNightParadePanel
        {
            get => _showNightParadePanel;
            set
            {
                if (_showNightParadePanel != value)
                {
                    _showNightParadePanel = value;
                    NotifyPropertyChanged(nameof(ShowNightParadePanel));
                }
            }
        }

        public bool ShowFreedShadowPanel
        {
            get => _showFreedShadowPanel;
            set
            {
                if (_showFreedShadowPanel != value)
                {
                    _showFreedShadowPanel = value;
                    NotifyPropertyChanged(nameof(ShowFreedShadowPanel));
                }
            }
        }

        public bool ShowPassiveCDPanel
        {
            get => _showPassiveCDPanel;
            set
            {
                if (_showPassiveCDPanel != value)
                {
                    _showPassiveCDPanel = value;
                    NotifyPropertyChanged(nameof(ShowPassiveCDPanel));
                }
            }
        }

        public bool ShowTransCDPanel
        {
            get => _showTransCDPanel;
            set
            {
                if (_showTransCDPanel != value)
                {
                    _showTransCDPanel = value;
                    NotifyPropertyChanged(nameof(ShowTransCDPanel));
                }
            }
        }

        private bool _showTSSPanel = true;
        private bool _showNightParadePanel = true;
        private bool _showFreedShadowPanel = true;
        private bool _showPassiveCDPanel = true;
        private bool _showTransCDPanel = true;

        #endregion
    }
}
