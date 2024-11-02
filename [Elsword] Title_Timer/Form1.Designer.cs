namespace _Elsword__Title_Timer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            text_Fontsize = new TextBox();
            btn_Chg_Fontsize = new Button();
            btn_Switching = new Button();
            btn__Switching_reset = new Button();
            btn_NPWG = new Button();
            btn_NPWG_Skill = new Button();
            btn_FreedShadow = new Button();
            btn_Dusk = new Button();
            btn_Natural = new Button();
            btn_Awakening = new Button();
            btn_Onion = new Button();
            btn_Apple = new Button();
            btn_TimerReset = new Button();
            btn_NPWG_reset = new Button();
            btn_NPWG_Skill_reset = new Button();
            btn_FreedShadow_reset = new Button();
            btn_Dusk_reset = new Button();
            btn_Natural_reset = new Button();
            btn_Awakening_reset = new Button();
            btn_Onion_reset = new Button();
            btn_Apple_reset = new Button();
            btn_TimerReset_reset = new Button();
            check_NPWG = new CheckBox();
            check_FreedShadow = new CheckBox();
            check_Dusk = new CheckBox();
            check_NPWG_FOD = new CheckBox();
            check_FreedShadow_FOD = new CheckBox();
            check_Dusk_FOD = new CheckBox();
            label1 = new Label();
            label_Switching = new Label();
            label_NPWG = new Label();
            label_NPWG_Skill = new Label();
            label_FreedShadow = new Label();
            label_Dusk = new Label();
            label_Natural = new Label();
            label_Awakening = new Label();
            label_Onion = new Label();
            label_Apple = new Label();
            label_TimerReset = new Label();
            text_Preset = new TextBox();
            label12 = new Label();
            btn_savePreset = new Button();
            comboBox_Preset = new ComboBox();
            btn_loadPreset = new Button();
            btn_FOD = new Button();
            label_FOD = new Label();
            btn_FOD_reset = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btn_Chg_Imgsize = new Button();
            text_imgSize = new TextBox();
            check_ADD_User = new CheckBox();
            check_Resize = new CheckBox();
            SuspendLayout();
            // 
            // text_Fontsize
            // 
            text_Fontsize.Location = new Point(298, 630);
            text_Fontsize.Name = "text_Fontsize";
            text_Fontsize.Size = new Size(40, 23);
            text_Fontsize.TabIndex = 0;
            text_Fontsize.TabStop = false;
            text_Fontsize.KeyPress += text_Fontsize_KeyPress;
            // 
            // btn_Chg_Fontsize
            // 
            btn_Chg_Fontsize.Location = new Point(363, 631);
            btn_Chg_Fontsize.Name = "btn_Chg_Fontsize";
            btn_Chg_Fontsize.Size = new Size(43, 23);
            btn_Chg_Fontsize.TabIndex = 1;
            btn_Chg_Fontsize.TabStop = false;
            btn_Chg_Fontsize.Text = "변경";
            btn_Chg_Fontsize.UseVisualStyleBackColor = true;
            btn_Chg_Fontsize.Click += chang_Fontsize_Click;
            // 
            // btn_Switching
            // 
            btn_Switching.Location = new Point(12, 12);
            btn_Switching.Name = "btn_Switching";
            btn_Switching.Size = new Size(116, 43);
            btn_Switching.TabIndex = 2;
            btn_Switching.TabStop = false;
            btn_Switching.Text = "칭호 스위칭 키\r\n등록버튼";
            btn_Switching.UseVisualStyleBackColor = true;
            btn_Switching.Click += btn_Switching_Click;
            // 
            // btn__Switching_reset
            // 
            btn__Switching_reset.Location = new Point(242, 12);
            btn__Switching_reset.Name = "btn__Switching_reset";
            btn__Switching_reset.Size = new Size(65, 43);
            btn__Switching_reset.TabIndex = 3;
            btn__Switching_reset.TabStop = false;
            btn__Switching_reset.Text = "<< 리셋";
            btn__Switching_reset.UseVisualStyleBackColor = true;
            btn__Switching_reset.Click += btn__Switching_reset_Click;
            // 
            // btn_NPWG
            // 
            btn_NPWG.Location = new Point(12, 61);
            btn_NPWG.Name = "btn_NPWG";
            btn_NPWG.Size = new Size(116, 43);
            btn_NPWG.TabIndex = 4;
            btn_NPWG.TabStop = false;
            btn_NPWG.Text = "백귀 방향키\r\n등록버튼";
            btn_NPWG.UseVisualStyleBackColor = true;
            btn_NPWG.Click += btn_NPWG_Click;
            // 
            // btn_NPWG_Skill
            // 
            btn_NPWG_Skill.Location = new Point(12, 110);
            btn_NPWG_Skill.Name = "btn_NPWG_Skill";
            btn_NPWG_Skill.Size = new Size(116, 43);
            btn_NPWG_Skill.TabIndex = 5;
            btn_NPWG_Skill.TabStop = false;
            btn_NPWG_Skill.Text = "백귀 스킬키\r\n등록버튼";
            btn_NPWG_Skill.UseVisualStyleBackColor = true;
            btn_NPWG_Skill.Click += btn_NPWG_Skill_Click;
            // 
            // btn_FreedShadow
            // 
            btn_FreedShadow.Location = new Point(12, 159);
            btn_FreedShadow.Name = "btn_FreedShadow";
            btn_FreedShadow.Size = new Size(116, 43);
            btn_FreedShadow.TabIndex = 6;
            btn_FreedShadow.TabStop = false;
            btn_FreedShadow.Text = "풀그 방향키\r\n등록버튼";
            btn_FreedShadow.UseVisualStyleBackColor = true;
            btn_FreedShadow.Click += btn_FreedShadow_Click;
            // 
            // btn_Dusk
            // 
            btn_Dusk.Location = new Point(12, 208);
            btn_Dusk.Name = "btn_Dusk";
            btn_Dusk.Size = new Size(116, 43);
            btn_Dusk.TabIndex = 7;
            btn_Dusk.TabStop = false;
            btn_Dusk.Text = "황혼 방향키\r\n등록버튼";
            btn_Dusk.UseVisualStyleBackColor = true;
            btn_Dusk.Click += btn_Dusk_Click;
            // 
            // btn_Natural
            // 
            btn_Natural.Location = new Point(12, 257);
            btn_Natural.Name = "btn_Natural";
            btn_Natural.Size = new Size(116, 43);
            btn_Natural.TabIndex = 8;
            btn_Natural.TabStop = false;
            btn_Natural.Text = "순리 방향키\r\n등록버튼";
            btn_Natural.UseVisualStyleBackColor = true;
            btn_Natural.Click += btn_Natural_Click;
            // 
            // btn_Awakening
            // 
            btn_Awakening.Location = new Point(12, 306);
            btn_Awakening.Name = "btn_Awakening";
            btn_Awakening.Size = new Size(116, 43);
            btn_Awakening.TabIndex = 9;
            btn_Awakening.TabStop = false;
            btn_Awakening.Text = "각성키\r\n등록버튼";
            btn_Awakening.UseVisualStyleBackColor = true;
            btn_Awakening.Click += btn_Awakening_Click;
            // 
            // btn_Onion
            // 
            btn_Onion.Location = new Point(12, 355);
            btn_Onion.Name = "btn_Onion";
            btn_Onion.Size = new Size(116, 43);
            btn_Onion.TabIndex = 10;
            btn_Onion.TabStop = false;
            btn_Onion.Text = "양파 사용키\r\n등록버튼";
            btn_Onion.UseVisualStyleBackColor = true;
            btn_Onion.Click += btn_Onion_Click;
            // 
            // btn_Apple
            // 
            btn_Apple.Location = new Point(12, 404);
            btn_Apple.Name = "btn_Apple";
            btn_Apple.Size = new Size(116, 43);
            btn_Apple.TabIndex = 11;
            btn_Apple.TabStop = false;
            btn_Apple.Text = "사과 사용키\r\n등록버튼";
            btn_Apple.UseVisualStyleBackColor = true;
            btn_Apple.Click += btn_Apple_Click;
            // 
            // btn_TimerReset
            // 
            btn_TimerReset.Location = new Point(12, 502);
            btn_TimerReset.Name = "btn_TimerReset";
            btn_TimerReset.Size = new Size(116, 43);
            btn_TimerReset.TabIndex = 12;
            btn_TimerReset.TabStop = false;
            btn_TimerReset.Text = "타이머 초기화 키\r\n등록버튼";
            btn_TimerReset.UseVisualStyleBackColor = true;
            btn_TimerReset.Click += btn_TimerReset_Click;
            // 
            // btn_NPWG_reset
            // 
            btn_NPWG_reset.Location = new Point(242, 61);
            btn_NPWG_reset.Name = "btn_NPWG_reset";
            btn_NPWG_reset.Size = new Size(65, 43);
            btn_NPWG_reset.TabIndex = 14;
            btn_NPWG_reset.TabStop = false;
            btn_NPWG_reset.Text = "<< 리셋";
            btn_NPWG_reset.UseVisualStyleBackColor = true;
            btn_NPWG_reset.Click += btn_NPWG_reset_Click;
            // 
            // btn_NPWG_Skill_reset
            // 
            btn_NPWG_Skill_reset.Location = new Point(242, 110);
            btn_NPWG_Skill_reset.Name = "btn_NPWG_Skill_reset";
            btn_NPWG_Skill_reset.Size = new Size(65, 43);
            btn_NPWG_Skill_reset.TabIndex = 15;
            btn_NPWG_Skill_reset.TabStop = false;
            btn_NPWG_Skill_reset.Text = "<< 리셋";
            btn_NPWG_Skill_reset.UseVisualStyleBackColor = true;
            btn_NPWG_Skill_reset.Click += btn_NPWG_Skill_reset_Click;
            // 
            // btn_FreedShadow_reset
            // 
            btn_FreedShadow_reset.Location = new Point(242, 159);
            btn_FreedShadow_reset.Name = "btn_FreedShadow_reset";
            btn_FreedShadow_reset.Size = new Size(65, 43);
            btn_FreedShadow_reset.TabIndex = 16;
            btn_FreedShadow_reset.TabStop = false;
            btn_FreedShadow_reset.Text = "<< 리셋";
            btn_FreedShadow_reset.UseVisualStyleBackColor = true;
            btn_FreedShadow_reset.Click += btn_FreedShadow_reset_Click;
            // 
            // btn_Dusk_reset
            // 
            btn_Dusk_reset.Location = new Point(242, 208);
            btn_Dusk_reset.Name = "btn_Dusk_reset";
            btn_Dusk_reset.Size = new Size(65, 43);
            btn_Dusk_reset.TabIndex = 17;
            btn_Dusk_reset.TabStop = false;
            btn_Dusk_reset.Text = "<< 리셋";
            btn_Dusk_reset.UseVisualStyleBackColor = true;
            btn_Dusk_reset.Click += btn_Dusk_reset_Click;
            // 
            // btn_Natural_reset
            // 
            btn_Natural_reset.Location = new Point(242, 257);
            btn_Natural_reset.Name = "btn_Natural_reset";
            btn_Natural_reset.Size = new Size(65, 43);
            btn_Natural_reset.TabIndex = 18;
            btn_Natural_reset.TabStop = false;
            btn_Natural_reset.Text = "<< 리셋";
            btn_Natural_reset.UseVisualStyleBackColor = true;
            btn_Natural_reset.Click += btn_Natural_reset_Click;
            // 
            // btn_Awakening_reset
            // 
            btn_Awakening_reset.Location = new Point(242, 306);
            btn_Awakening_reset.Name = "btn_Awakening_reset";
            btn_Awakening_reset.Size = new Size(65, 43);
            btn_Awakening_reset.TabIndex = 19;
            btn_Awakening_reset.TabStop = false;
            btn_Awakening_reset.Text = "<< 리셋";
            btn_Awakening_reset.UseVisualStyleBackColor = true;
            btn_Awakening_reset.Click += btn_Awakening_reset_Click;
            // 
            // btn_Onion_reset
            // 
            btn_Onion_reset.Location = new Point(242, 355);
            btn_Onion_reset.Name = "btn_Onion_reset";
            btn_Onion_reset.Size = new Size(65, 43);
            btn_Onion_reset.TabIndex = 20;
            btn_Onion_reset.TabStop = false;
            btn_Onion_reset.Text = "<< 리셋";
            btn_Onion_reset.UseVisualStyleBackColor = true;
            btn_Onion_reset.Click += btn_Onion_reset_Click;
            // 
            // btn_Apple_reset
            // 
            btn_Apple_reset.Location = new Point(242, 404);
            btn_Apple_reset.Name = "btn_Apple_reset";
            btn_Apple_reset.Size = new Size(65, 43);
            btn_Apple_reset.TabIndex = 21;
            btn_Apple_reset.TabStop = false;
            btn_Apple_reset.Text = "<< 리셋";
            btn_Apple_reset.UseVisualStyleBackColor = true;
            btn_Apple_reset.Click += btn_Apple_reset_Click;
            // 
            // btn_TimerReset_reset
            // 
            btn_TimerReset_reset.Location = new Point(242, 502);
            btn_TimerReset_reset.Name = "btn_TimerReset_reset";
            btn_TimerReset_reset.Size = new Size(65, 43);
            btn_TimerReset_reset.TabIndex = 22;
            btn_TimerReset_reset.TabStop = false;
            btn_TimerReset_reset.Text = "<< 리셋";
            btn_TimerReset_reset.UseVisualStyleBackColor = true;
            btn_TimerReset_reset.Click += btn_TimerReset_reset_Click;
            // 
            // check_NPWG
            // 
            check_NPWG.AutoSize = true;
            check_NPWG.Checked = true;
            check_NPWG.CheckState = CheckState.Checked;
            check_NPWG.Location = new Point(332, 74);
            check_NPWG.Name = "check_NPWG";
            check_NPWG.Size = new Size(142, 19);
            check_NPWG.TabIndex = 23;
            check_NPWG.TabStop = false;
            check_NPWG.Text = "백귀 타이머 사용여부";
            check_NPWG.UseVisualStyleBackColor = true;
            check_NPWG.CheckedChanged += check_NPWG_CheckedChanged;
            // 
            // check_FreedShadow
            // 
            check_FreedShadow.AutoSize = true;
            check_FreedShadow.Checked = true;
            check_FreedShadow.CheckState = CheckState.Checked;
            check_FreedShadow.Location = new Point(332, 172);
            check_FreedShadow.Name = "check_FreedShadow";
            check_FreedShadow.Size = new Size(142, 19);
            check_FreedShadow.TabIndex = 24;
            check_FreedShadow.TabStop = false;
            check_FreedShadow.Text = "풀그 타이머 사용여부";
            check_FreedShadow.UseVisualStyleBackColor = true;
            check_FreedShadow.CheckedChanged += check_FreedShadow_CheckedChanged;
            // 
            // check_Dusk
            // 
            check_Dusk.AutoSize = true;
            check_Dusk.Checked = true;
            check_Dusk.CheckState = CheckState.Checked;
            check_Dusk.Location = new Point(332, 221);
            check_Dusk.Name = "check_Dusk";
            check_Dusk.Size = new Size(142, 19);
            check_Dusk.TabIndex = 25;
            check_Dusk.TabStop = false;
            check_Dusk.Text = "황혼 타이머 사용여부";
            check_Dusk.UseVisualStyleBackColor = true;
            check_Dusk.CheckedChanged += check_Dusk_CheckedChanged;
            // 
            // check_NPWG_FOD
            // 
            check_NPWG_FOD.AutoSize = true;
            check_NPWG_FOD.Location = new Point(480, 74);
            check_NPWG_FOD.Name = "check_NPWG_FOD";
            check_NPWG_FOD.Size = new Size(180, 19);
            check_NPWG_FOD.TabIndex = 26;
            check_NPWG_FOD.TabStop = false;
            check_NPWG_FOD.Text = "백귀 \"유사 포오데\" 사용여부";
            check_NPWG_FOD.UseVisualStyleBackColor = true;
            check_NPWG_FOD.CheckedChanged += check_NPWG_FOD_CheckedChanged;
            // 
            // check_FreedShadow_FOD
            // 
            check_FreedShadow_FOD.AutoSize = true;
            check_FreedShadow_FOD.Location = new Point(480, 172);
            check_FreedShadow_FOD.Name = "check_FreedShadow_FOD";
            check_FreedShadow_FOD.Size = new Size(180, 19);
            check_FreedShadow_FOD.TabIndex = 27;
            check_FreedShadow_FOD.TabStop = false;
            check_FreedShadow_FOD.Text = "풀그 \"유사 포오데\" 사용여부";
            check_FreedShadow_FOD.UseVisualStyleBackColor = true;
            check_FreedShadow_FOD.CheckedChanged += check_FreedShadow_FOD_CheckedChanged;
            // 
            // check_Dusk_FOD
            // 
            check_Dusk_FOD.AutoSize = true;
            check_Dusk_FOD.Location = new Point(480, 221);
            check_Dusk_FOD.Name = "check_Dusk_FOD";
            check_Dusk_FOD.Size = new Size(180, 19);
            check_Dusk_FOD.TabIndex = 28;
            check_Dusk_FOD.TabStop = false;
            check_Dusk_FOD.Text = "황혼 \"유사 포오데\" 사용여부";
            check_Dusk_FOD.UseVisualStyleBackColor = true;
            check_Dusk_FOD.CheckedChanged += check_Dusk_FOD_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 589);
            label1.Name = "label1";
            label1.Size = new Size(687, 15);
            label1.TabIndex = 29;
            label1.Text = "----------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // label_Switching
            // 
            label_Switching.AutoSize = true;
            label_Switching.Location = new Point(134, 18);
            label_Switching.Name = "label_Switching";
            label_Switching.Size = new Size(87, 30);
            label_Switching.TabIndex = 30;
            label_Switching.Text = "현재 등록된 키\r\n[없음]";
            label_Switching.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_NPWG
            // 
            label_NPWG.AutoSize = true;
            label_NPWG.Location = new Point(134, 67);
            label_NPWG.Name = "label_NPWG";
            label_NPWG.Size = new Size(87, 30);
            label_NPWG.TabIndex = 31;
            label_NPWG.Text = "현재 등록된 키\r\n[없음]";
            label_NPWG.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_NPWG_Skill
            // 
            label_NPWG_Skill.AutoSize = true;
            label_NPWG_Skill.Location = new Point(134, 116);
            label_NPWG_Skill.Name = "label_NPWG_Skill";
            label_NPWG_Skill.Size = new Size(87, 30);
            label_NPWG_Skill.TabIndex = 32;
            label_NPWG_Skill.Text = "현재 등록된 키\r\n[없음]";
            label_NPWG_Skill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_FreedShadow
            // 
            label_FreedShadow.AutoSize = true;
            label_FreedShadow.Location = new Point(134, 165);
            label_FreedShadow.Name = "label_FreedShadow";
            label_FreedShadow.Size = new Size(87, 30);
            label_FreedShadow.TabIndex = 33;
            label_FreedShadow.Text = "현재 등록된 키\r\n[없음]";
            label_FreedShadow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Dusk
            // 
            label_Dusk.AutoSize = true;
            label_Dusk.Location = new Point(134, 214);
            label_Dusk.Name = "label_Dusk";
            label_Dusk.Size = new Size(87, 30);
            label_Dusk.TabIndex = 34;
            label_Dusk.Text = "현재 등록된 키\r\n[없음]";
            label_Dusk.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Natural
            // 
            label_Natural.AutoSize = true;
            label_Natural.Location = new Point(134, 263);
            label_Natural.Name = "label_Natural";
            label_Natural.Size = new Size(87, 30);
            label_Natural.TabIndex = 35;
            label_Natural.Text = "현재 등록된 키\r\n[없음]";
            label_Natural.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Awakening
            // 
            label_Awakening.AutoSize = true;
            label_Awakening.Location = new Point(134, 312);
            label_Awakening.Name = "label_Awakening";
            label_Awakening.Size = new Size(87, 30);
            label_Awakening.TabIndex = 36;
            label_Awakening.Text = "현재 등록된 키\r\n[없음]";
            label_Awakening.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Onion
            // 
            label_Onion.AutoSize = true;
            label_Onion.Location = new Point(134, 361);
            label_Onion.Name = "label_Onion";
            label_Onion.Size = new Size(87, 30);
            label_Onion.TabIndex = 37;
            label_Onion.Text = "현재 등록된 키\r\n[없음]";
            label_Onion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Apple
            // 
            label_Apple.AutoSize = true;
            label_Apple.Location = new Point(134, 410);
            label_Apple.Name = "label_Apple";
            label_Apple.Size = new Size(87, 30);
            label_Apple.TabIndex = 38;
            label_Apple.Text = "현재 등록된 키\r\n[없음]";
            label_Apple.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_TimerReset
            // 
            label_TimerReset.AutoSize = true;
            label_TimerReset.Location = new Point(134, 508);
            label_TimerReset.Name = "label_TimerReset";
            label_TimerReset.Size = new Size(87, 30);
            label_TimerReset.TabIndex = 39;
            label_TimerReset.Text = "현재 등록된 키\r\n[없음]";
            label_TimerReset.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // text_Preset
            // 
            text_Preset.Location = new Point(12, 629);
            text_Preset.Name = "text_Preset";
            text_Preset.Size = new Size(116, 23);
            text_Preset.TabIndex = 40;
            text_Preset.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(20, 607);
            label12.Name = "label12";
            label12.Size = new Size(99, 15);
            label12.TabIndex = 41;
            label12.Text = "프리셋 이름 입력";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_savePreset
            // 
            btn_savePreset.Location = new Point(134, 629);
            btn_savePreset.Name = "btn_savePreset";
            btn_savePreset.Size = new Size(107, 23);
            btn_savePreset.TabIndex = 42;
            btn_savePreset.TabStop = false;
            btn_savePreset.Text = "프리셋 저장";
            btn_savePreset.UseVisualStyleBackColor = true;
            btn_savePreset.Click += btn_savePreset_Click;
            // 
            // comboBox_Preset
            // 
            comboBox_Preset.FormattingEnabled = true;
            comboBox_Preset.Location = new Point(12, 665);
            comboBox_Preset.Name = "comboBox_Preset";
            comboBox_Preset.Size = new Size(134, 23);
            comboBox_Preset.TabIndex = 43;
            comboBox_Preset.TabStop = false;
            comboBox_Preset.SelectedIndexChanged += comboBox_Preset_SelectedIndexChanged;
            // 
            // btn_loadPreset
            // 
            btn_loadPreset.Location = new Point(152, 665);
            btn_loadPreset.Name = "btn_loadPreset";
            btn_loadPreset.Size = new Size(107, 23);
            btn_loadPreset.TabIndex = 44;
            btn_loadPreset.TabStop = false;
            btn_loadPreset.Text = "프리셋 불러오기";
            btn_loadPreset.UseVisualStyleBackColor = true;
            btn_loadPreset.Click += btn_loadPreset_Click;
            // 
            // btn_FOD
            // 
            btn_FOD.Location = new Point(12, 453);
            btn_FOD.Name = "btn_FOD";
            btn_FOD.Size = new Size(116, 43);
            btn_FOD.TabIndex = 45;
            btn_FOD.TabStop = false;
            btn_FOD.Text = "유사 포오데 키\r\n등록버튼";
            btn_FOD.UseVisualStyleBackColor = true;
            btn_FOD.Click += btn_FOD_Click;
            // 
            // label_FOD
            // 
            label_FOD.AutoSize = true;
            label_FOD.Location = new Point(134, 459);
            label_FOD.Name = "label_FOD";
            label_FOD.Size = new Size(87, 30);
            label_FOD.TabIndex = 46;
            label_FOD.Text = "현재 등록된 키\r\n[없음]";
            label_FOD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_FOD_reset
            // 
            btn_FOD_reset.Location = new Point(242, 453);
            btn_FOD_reset.Name = "btn_FOD_reset";
            btn_FOD_reset.Size = new Size(65, 43);
            btn_FOD_reset.TabIndex = 47;
            btn_FOD_reset.TabStop = false;
            btn_FOD_reset.Text = "<< 리셋";
            btn_FOD_reset.UseVisualStyleBackColor = true;
            btn_FOD_reset.Click += btn_FOD_reset_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(339, 635);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 48;
            label2.Text = "%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(298, 607);
            label3.Name = "label3";
            label3.Size = new Size(127, 15);
            label3.TabIndex = 49;
            label3.Text = "칭호창 글씨 크기 변경";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(298, 668);
            label4.Name = "label4";
            label4.Size = new Size(139, 15);
            label4.TabIndex = 50;
            label4.Text = "칭호창 아이콘 크기 변경";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(339, 691);
            label5.Name = "label5";
            label5.Size = new Size(17, 15);
            label5.TabIndex = 53;
            label5.Text = "%";
            // 
            // btn_Chg_Imgsize
            // 
            btn_Chg_Imgsize.Location = new Point(363, 687);
            btn_Chg_Imgsize.Name = "btn_Chg_Imgsize";
            btn_Chg_Imgsize.Size = new Size(43, 23);
            btn_Chg_Imgsize.TabIndex = 52;
            btn_Chg_Imgsize.TabStop = false;
            btn_Chg_Imgsize.Text = "변경";
            btn_Chg_Imgsize.UseVisualStyleBackColor = true;
            btn_Chg_Imgsize.Click += btn_Chg_Imgsize_Click;
            // 
            // text_imgSize
            // 
            text_imgSize.Location = new Point(298, 686);
            text_imgSize.Name = "text_imgSize";
            text_imgSize.Size = new Size(40, 23);
            text_imgSize.TabIndex = 51;
            text_imgSize.TabStop = false;
            text_imgSize.KeyPress += textBox1_KeyPress;
            // 
            // check_ADD_User
            // 
            check_ADD_User.AutoSize = true;
            check_ADD_User.Location = new Point(12, 551);
            check_ADD_User.Name = "check_ADD_User";
            check_ADD_User.Size = new Size(173, 19);
            check_ADD_User.TabIndex = 54;
            check_ADD_User.TabStop = false;
            check_ADD_User.Text = "애드 유저 체크(각성키 2번)";
            check_ADD_User.UseVisualStyleBackColor = true;
            check_ADD_User.CheckedChanged += check_ADD_User_CheckedChanged;
            // 
            // check_Resize
            // 
            check_Resize.AutoSize = true;
            check_Resize.Location = new Point(464, 616);
            check_Resize.Name = "check_Resize";
            check_Resize.Size = new Size(186, 34);
            check_Resize.TabIndex = 55;
            check_Resize.TabStop = false;
            check_Resize.Text = "칭호창 크기 다 바꾸면 누르셈\r\n(개거슬리는 버튼 제거)";
            check_Resize.TextAlign = ContentAlignment.MiddleCenter;
            check_Resize.UseVisualStyleBackColor = true;
            check_Resize.CheckedChanged += check_Resize_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(707, 726);
            Controls.Add(check_Resize);
            Controls.Add(check_ADD_User);
            Controls.Add(label5);
            Controls.Add(btn_Chg_Imgsize);
            Controls.Add(text_imgSize);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btn_FOD_reset);
            Controls.Add(label_FOD);
            Controls.Add(btn_FOD);
            Controls.Add(btn_loadPreset);
            Controls.Add(comboBox_Preset);
            Controls.Add(btn_savePreset);
            Controls.Add(label12);
            Controls.Add(text_Preset);
            Controls.Add(label_TimerReset);
            Controls.Add(label_Apple);
            Controls.Add(label_Onion);
            Controls.Add(label_Awakening);
            Controls.Add(label_Natural);
            Controls.Add(label_Dusk);
            Controls.Add(label_FreedShadow);
            Controls.Add(label_NPWG_Skill);
            Controls.Add(label_NPWG);
            Controls.Add(label_Switching);
            Controls.Add(label1);
            Controls.Add(check_Dusk_FOD);
            Controls.Add(check_FreedShadow_FOD);
            Controls.Add(check_NPWG_FOD);
            Controls.Add(check_Dusk);
            Controls.Add(check_FreedShadow);
            Controls.Add(check_NPWG);
            Controls.Add(btn_TimerReset_reset);
            Controls.Add(btn_Apple_reset);
            Controls.Add(btn_Onion_reset);
            Controls.Add(btn_Awakening_reset);
            Controls.Add(btn_Natural_reset);
            Controls.Add(btn_Dusk_reset);
            Controls.Add(btn_FreedShadow_reset);
            Controls.Add(btn_NPWG_Skill_reset);
            Controls.Add(btn_NPWG_reset);
            Controls.Add(btn_TimerReset);
            Controls.Add(btn_Apple);
            Controls.Add(btn_Onion);
            Controls.Add(btn_Awakening);
            Controls.Add(btn_Natural);
            Controls.Add(btn_Dusk);
            Controls.Add(btn_FreedShadow);
            Controls.Add(btn_NPWG_Skill);
            Controls.Add(btn_NPWG);
            Controls.Add(btn__Switching_reset);
            Controls.Add(btn_Switching);
            Controls.Add(btn_Chg_Fontsize);
            Controls.Add(text_Fontsize);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text_Fontsize;
        private Button btn_Chg_Fontsize;
        private Button btn_Switching;
        private Button btn__Switching_reset;
        private Button btn_NPWG;
        private Button btn_NPWG_Skill;
        private Button btn_FreedShadow;
        private Button btn_Dusk;
        private Button btn_Natural;
        private Button btn_Awakening;
        private Button btn_Onion;
        private Button btn_Apple;
        private Button btn_TimerReset;
        private Button btn_NPWG_reset;
        private Button btn_NPWG_Skill_reset;
        private Button btn_FreedShadow_reset;
        private Button btn_Dusk_reset;
        private Button btn_Natural_reset;
        private Button btn_Awakening_reset;
        private Button btn_Onion_reset;
        private Button btn_Apple_reset;
        private Button btn_TimerReset_reset;
        private CheckBox check_NPWG;
        private CheckBox check_FreedShadow;
        private CheckBox check_Dusk;
        private CheckBox check_NPWG_FOD;
        private CheckBox check_FreedShadow_FOD;
        private CheckBox check_Dusk_FOD;
        private Label label1;
        private Label label_Switching;
        private Label label_NPWG;
        private Label label_NPWG_Skill;
        private Label label_FreedShadow;
        private Label label_Dusk;
        private Label label_Natural;
        private Label label_Awakening;
        private Label label_Onion;
        private Label label_Apple;
        private Label label_TimerReset;
        private TextBox text_Preset;
        private Label label12;
        private Button btn_savePreset;
        private ComboBox comboBox_Preset;
        private Button btn_loadPreset;
        private Button btn_FOD;
        private Label label_FOD;
        private Button btn_FOD_reset;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btn_Chg_Imgsize;
        private TextBox text_imgSize;
        private CheckBox check_ADD_User;
        private CheckBox check_Resize;
    }
}