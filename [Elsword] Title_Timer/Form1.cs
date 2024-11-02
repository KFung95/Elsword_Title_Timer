using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _Elsword__Title_Timer
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);


        private TimerOverlay timerOverlay;

        private Preset currentPreset = new Preset();
        private string presetFileName = "";
        private List<string> presetFiles = new List<string>();
        private string presetDirectory = "Presets"; // 프리셋 저장 디렉토리
        private int selectedPresetIndex = 0; // 선택된 프리셋 인덱스


        public static bool IsCapturing_Switching = false;
        public static bool IsCapturing_NPWG = false;
        public static bool IsCapturing_NPWG_Skill = false;
        public static bool IsCapturing_FreedShadow = false;
        public static bool IsCapturing_Dusk = false;
        public static bool IsCapturing_Natural = false;
        public static bool IsCapturing_Awakening = false;
        public static bool IsCapturing_Onion = false;
        public static bool IsCapturing_Apple = false;
        public static bool IsCapturing_FOD = false;
        public static bool IsCapturing_TimerReset = false;

        public Form1(TimerOverlay overlay)
        {
            InitializeComponent();
            timerOverlay = overlay; // TimerOverlay 인스턴스를 저장
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 프리셋 디렉토리 생성
            if (!Directory.Exists(presetDirectory))
            {
                Directory.CreateDirectory(presetDirectory);
            }

            // 기존 프리셋 파일 로드
            LoadPresetFiles();
            StartPreset();
        }

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
            string filePath = Path.Combine(presetDirectory, text_Preset.Text + ".txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(timerOverlay.form_custom_ChangeTitle);
                writer.WriteLine(timerOverlay.form_custom_NPWG);
                writer.WriteLine(timerOverlay.form_custom_NPWG_Skill);
                writer.WriteLine(timerOverlay.form_custom_FreedShadow);
                writer.WriteLine(timerOverlay.form_custom_Dusk);
                writer.WriteLine(timerOverlay.form_custom_Natural);
                writer.WriteLine(timerOverlay.form_custom_Awakening);
                writer.WriteLine(timerOverlay.form_custom_Onion);
                writer.WriteLine(timerOverlay.form_custom_Apple);
                writer.WriteLine(timerOverlay.form_custom_FOD);
                writer.WriteLine(timerOverlay.form_custom_TimerReset);
                writer.WriteLine(timerOverlay.Show_NPWG);
                writer.WriteLine(timerOverlay.Show_FreedShadow);
                writer.WriteLine(timerOverlay.Show_Dusk);
                writer.WriteLine(timerOverlay.Use_NPWG_FOD);
                writer.WriteLine(timerOverlay.Use_FreedShadow_FOD);
                writer.WriteLine(timerOverlay.Use_Dusk_FOD);
                writer.WriteLine(timerOverlay.ADD_User);
                writer.WriteLine(timerOverlay.allowResize);
            }


            using (StreamWriter writer = new StreamWriter("recent_used.txt"))
            {
                writer.WriteLine(text_Preset.Text);
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
                    timerOverlay.form_custom_ChangeTitle = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_NPWG = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_NPWG_Skill = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_FreedShadow = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Dusk = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Natural = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Awakening = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Onion = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Apple = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_FOD = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_TimerReset = int.Parse(reader.ReadLine());
                    timerOverlay.Show_NPWG = bool.Parse(reader.ReadLine());
                    timerOverlay.Show_FreedShadow = bool.Parse(reader.ReadLine());
                    timerOverlay.Show_Dusk = bool.Parse(reader.ReadLine());
                    timerOverlay.Use_NPWG_FOD = bool.Parse(reader.ReadLine());
                    timerOverlay.Use_FreedShadow_FOD = bool.Parse(reader.ReadLine());
                    timerOverlay.Use_Dusk_FOD = bool.Parse(reader.ReadLine());
                    timerOverlay.ADD_User = bool.Parse(reader.ReadLine());
                    timerOverlay.allowResize = bool.Parse(reader.ReadLine());

                    label_Switching.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_ChangeTitle + "]";
                    label_NPWG.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_NPWG + "]";
                    label_NPWG_Skill.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_NPWG_Skill + "]";
                    label_FreedShadow.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_FreedShadow + "]";
                    label_Dusk.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_Dusk + "]";
                    label_Natural.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_Natural + "]";
                    label_Awakening.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_Awakening + "]";
                    label_Onion.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_Onion + "]";
                    label_Apple.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_Apple + "]";
                    label_FOD.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_FOD + "]";
                    label_TimerReset.Text = "현재 등록된 키\r\n" + "[" + (Keys)timerOverlay.form_custom_TimerReset + "]";
                    check_NPWG.Checked = timerOverlay.Show_NPWG;
                    check_FreedShadow.Checked = timerOverlay.Show_FreedShadow;
                    check_Dusk.Checked = timerOverlay.Show_Dusk;
                    check_NPWG_FOD.Checked = timerOverlay.Use_NPWG_FOD;
                    check_FreedShadow_FOD.Checked = timerOverlay.Use_FreedShadow_FOD;
                    check_Dusk_FOD.Checked = timerOverlay.Use_Dusk_FOD;
                    check_ADD_User.Checked = timerOverlay.ADD_User;
                    check_Resize.Checked = timerOverlay.allowResize;


                }

                using (StreamWriter writer = new StreamWriter("recent_used.txt"))
                {
                    writer.WriteLine(presetFileName);
                }

                comboBox_Preset.Text = presetFileName;
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
                presetFiles.AddRange(Directory.GetFiles(presetDirectory, "*.txt").Select(Path.GetFileNameWithoutExtension).Distinct()); // 중복 제거
                comboBox_Preset.Items.AddRange(presetFiles.ToArray());
            }
        }



        private void DisableOtherControls()
        {
            foreach (Control control in this.Controls)
            {

                control.Enabled = false; // 다른 컨트롤 비활성화

            }
        }

        private void EnableOtherControls()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true; // 모든 컨트롤 활성화
            }

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            int keycode = -1;

            keycode = (int)e.KeyCode;

            if (e.KeyCode == Keys.ShiftKey)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)))
                {
                    keycode = (int)Keys.LShiftKey;
                }
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
                {
                    keycode = (int)Keys.RShiftKey;
                }
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)))
                {
                    keycode = (int)Keys.LControlKey;
                }
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                {
                    keycode = (int)Keys.RControlKey;
                }
            }

            if (e.KeyCode == Keys.Menu)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
                {
                    keycode = (int)Keys.LMenu;
                }
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
                {
                    keycode = (int)Keys.RMenu;
                }
            }



            if (IsCapturing_Switching)
            {

                IsCapturing_Switching = false; // 키 캡처 상태 종료
                // 키 입력이 감지되면 버튼과 레이블 텍스트 변경
                timerOverlay.form_custom_ChangeTitle = keycode;
                btn_Switching.Text = "칭호 스위칭 키\r\n등록버튼";
                label_Switching.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";

            }
            else if (IsCapturing_NPWG)
            {
                IsCapturing_NPWG = false;
                btn_NPWG.Text = "백귀 방향키\r\n등록버튼";
                timerOverlay.form_custom_NPWG = keycode;
                label_NPWG.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_NPWG_Skill)
            {
                IsCapturing_NPWG_Skill = false;
                btn_NPWG_Skill.Text = "백귀 스킬키\r\n등록버튼";
                timerOverlay.form_custom_NPWG_Skill = keycode;
                label_NPWG_Skill.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_FreedShadow)
            {
                IsCapturing_FreedShadow = false;
                btn_FreedShadow.Text = "풀그 방향키\r\n등록버튼";
                timerOverlay.form_custom_FreedShadow = keycode;
                label_FreedShadow.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Dusk)
            {
                IsCapturing_Dusk = false;
                btn_Dusk.Text = "황혼 방향키\r\n등록버튼";
                timerOverlay.form_custom_Dusk = keycode;
                label_Dusk.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Natural)
            {
                IsCapturing_Natural = false;
                btn_Natural.Text = "순리 방향키\r\n등록버튼";
                timerOverlay.form_custom_Natural = keycode;
                label_Natural.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Awakening)
            {
                IsCapturing_Awakening = false;
                btn_Awakening.Text = "각성키\r\n등록버튼";
                timerOverlay.form_custom_Awakening = keycode;
                label_Awakening.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Onion)
            {
                IsCapturing_Onion = false;
                btn_Onion.Text = "양파 사용키\r\n등록버튼";
                timerOverlay.form_custom_Onion = keycode;
                label_Onion.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Apple)
            {
                IsCapturing_Apple = false;
                btn_Apple.Text = "사과 사용키\r\n등록버튼";
                timerOverlay.form_custom_Apple = keycode;
                label_Apple.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_FOD)
            {
                IsCapturing_FOD = false;
                btn_FOD.Text = "유사 포오데 키\r\n등록버튼";
                timerOverlay.form_custom_FOD = keycode;
                label_FOD.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_TimerReset)
            {
                IsCapturing_TimerReset = false;
                btn_TimerReset.Text = "타이머 초기화 키\r\n등록버튼";
                timerOverlay.form_custom_TimerReset = keycode;
                label_TimerReset.Text = "현재 등록된 키\r\n" + "[" + (Keys)keycode + "]";
            }

            // 더 이상 키 입력을 처리하지 않도록 이벤트 핸들러 해제
            this.KeyDown -= Form1_KeyDown; // 이벤트 핸들러 해제

            EnableOtherControls();

        }




        private void btn_Switching_Click(object sender, EventArgs e)
        {


            IsCapturing_Switching = true;
            btn_Switching.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }




        private void btn_NPWG_Click(object sender, EventArgs e)
        {
            IsCapturing_NPWG = true;
            btn_NPWG.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_NPWG_Skill_Click(object sender, EventArgs e)
        {
            IsCapturing_NPWG_Skill = true;
            btn_NPWG_Skill.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_FreedShadow_Click(object sender, EventArgs e)
        {
            IsCapturing_FreedShadow = true;
            btn_FreedShadow.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_Dusk_Click(object sender, EventArgs e)
        {
            IsCapturing_Dusk = true;
            btn_Dusk.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_Natural_Click(object sender, EventArgs e)
        {
            IsCapturing_Natural = true;
            btn_Natural.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_Awakening_Click(object sender, EventArgs e)
        {
            IsCapturing_Awakening = true;
            btn_Awakening.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_Onion_Click(object sender, EventArgs e)
        {
            IsCapturing_Onion = true;
            btn_Onion.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_Apple_Click(object sender, EventArgs e)
        {
            IsCapturing_Apple = true;
            btn_Apple.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_FOD_Click(object sender, EventArgs e)
        {
            IsCapturing_FOD = true;
            btn_FOD.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn_TimerReset_Click(object sender, EventArgs e)
        {
            IsCapturing_TimerReset = true;
            btn_TimerReset.Text = "키를 입력해 주세요";

            DisableOtherControls();

            // 키 입력을 기다리기 위해 폼의 KeyDown 이벤트를 활성화
            this.KeyPreview = true; // 폼이 키 이벤트를 받도록 설정
            this.KeyDown += Form1_KeyDown; // KeyDown 이벤트 핸들러 등록
        }

        private void btn__Switching_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Switching = false;
            timerOverlay.form_custom_ChangeTitle = -1;
            btn_Switching.Text = "칭호 스위칭 키\r\n등록버튼";
            label_Switching.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_NPWG_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_NPWG = false;
            timerOverlay.form_custom_NPWG = -1;
            btn_NPWG.Text = "백귀 방향키\r\n등록버튼";
            label_NPWG.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_NPWG_Skill_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_NPWG_Skill = false;
            timerOverlay.form_custom_NPWG_Skill = -1;
            btn_NPWG_Skill.Text = "백귀 스킬키\r\n등록버튼";
            label_NPWG_Skill.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_FreedShadow_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_FreedShadow = false;
            timerOverlay.form_custom_FreedShadow = -1;
            btn_FreedShadow.Text = "풀그 방향키\r\n등록버튼";
            label_FreedShadow.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_Dusk_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Dusk = false;
            timerOverlay.form_custom_Dusk = -1;
            btn_Dusk.Text = "황혼 방향키\r\n등록버튼";
            label_Dusk.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_Natural_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Natural = false;
            timerOverlay.form_custom_Natural = -1;
            btn_Natural.Text = "순리 방향키\r\n등록버튼";
            label_Natural.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_Awakening_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Awakening = false;
            timerOverlay.form_custom_Awakening = -1;
            btn_Awakening.Text = "각성키\r\n등록버튼";
            label_Awakening.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_Onion_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Onion = false;
            timerOverlay.form_custom_Onion = -1;
            btn_Onion.Text = "양파 사용키\r\n등록버튼";
            label_Onion.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_Apple_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Apple = false;
            timerOverlay.form_custom_Apple = -1;
            btn_Apple.Text = "사과 사용키\r\n등록버튼";
            label_Apple.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_FOD_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_FOD = false;
            timerOverlay.form_custom_FOD = -1;
            btn_FOD.Text = "유사 포오데 키\r\n등록버튼";
            label_FOD.Text = "현재 등록된 키\r\n[없음]";
        }

        private void btn_TimerReset_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_TimerReset = false;
            timerOverlay.form_custom_TimerReset = -1;
            btn_TimerReset.Text = "타이머 초기화 키\r\n등록버튼";
            label_TimerReset.Text = "현재 등록된 키\r\n[없음]";
        }

        private void comboBox_Preset_SelectedIndexChanged(object sender, EventArgs e)
        {
            presetFileName = comboBox_Preset.Text;
        }

        private void btn_savePreset_Click(object sender, EventArgs e)
        {
            SavePreset();
            comboBox_Preset.Text = text_Preset.Text;
        }

        private void btn_loadPreset_Click(object sender, EventArgs e)
        {
            LoadPreset(comboBox_Preset.Text);
        }

        private void check_NPWG_CheckedChanged(object sender, EventArgs e)
        {
            if (check_NPWG.Checked)
            {
                timerOverlay.Show_NPWG = true;
            }
            else
            {
                timerOverlay.Show_NPWG = false;
            }
        }

        private void check_FreedShadow_CheckedChanged(object sender, EventArgs e)
        {
            if (check_FreedShadow.Checked)
            {
                timerOverlay.Show_FreedShadow = true;
            }
            else
            {
                timerOverlay.Show_FreedShadow = false;
            }
        }

        private void check_Dusk_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Dusk.Checked)
            {
                timerOverlay.Show_Dusk = true;
            }
            else
            {
                timerOverlay.Show_Dusk = false;
            }
        }

        private void check_NPWG_FOD_CheckedChanged(object sender, EventArgs e)
        {
            if (check_NPWG_FOD.Checked)
            {
                timerOverlay.Use_NPWG_FOD = true;
            }
            else
            {
                timerOverlay.Use_NPWG_FOD = false;
            }
        }

        private void check_FreedShadow_FOD_CheckedChanged(object sender, EventArgs e)
        {
            if (check_FreedShadow_FOD.Checked)
            {
                timerOverlay.Use_FreedShadow_FOD = true;
            }
            else
            {
                timerOverlay.Use_FreedShadow_FOD = false;
            }
        }

        private void check_Dusk_FOD_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Dusk_FOD.Checked)
            {
                timerOverlay.Use_Dusk_FOD = true;
            }
            else
            {
                timerOverlay.Use_Dusk_FOD = false;
            }
        }

        private void check_ADD_User_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ADD_User.Checked)
            {
                timerOverlay.ADD_User = true;
            }
            else
            {
                timerOverlay.ADD_User = false;
            }
        }

        private void text_Fontsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자와 백스페이스만 입력
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자와 백스페이스만 입력
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void chang_Fontsize_Click(object sender, EventArgs e)
        {
            int fontSize_perCent = int.Parse(text_Fontsize.Text);
            timerOverlay.fontScale = (fontSize_perCent / 100f);
            timerOverlay.isInitialized = false;
        }

        private void btn_Chg_Imgsize_Click(object sender, EventArgs e)
        {
            int imgSize_perCent = int.Parse(text_imgSize.Text);
            timerOverlay.imgScale = (imgSize_perCent / 100f);
            timerOverlay.isInitialized = false;
        }

        private void check_Resize_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Resize.Checked)
            {
                timerOverlay.allowResize = true;
            }
            else
            {
                timerOverlay.allowResize = false;
            }
        }
    }
}
