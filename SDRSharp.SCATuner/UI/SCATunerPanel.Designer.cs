using System;

namespace SDRSharp.SCATuner
{
    partial class SCATunerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.disbalanceLabel = new System.Windows.Forms.Label();
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.bufferProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SCAGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fineTunningCtrl = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.rb67 = new System.Windows.Forms.RadioButton();
            this.rb92 = new System.Windows.Forms.RadioButton();
            this.auxAudioEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.audioDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.SampleRateLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SCAGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fineTunningCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeTrackBar.AutoSize = false;
            this.volumeTrackBar.Location = new System.Drawing.Point(5, 201);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(188, 35);
            this.volumeTrackBar.TabIndex = 5;
            this.volumeTrackBar.TickFrequency = 10;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output level";
            // 
            // disbalanceLabel
            // 
            this.disbalanceLabel.AutoSize = true;
            this.disbalanceLabel.Location = new System.Drawing.Point(124, 248);
            this.disbalanceLabel.Name = "disbalanceLabel";
            this.disbalanceLabel.Size = new System.Drawing.Size(71, 13);
            this.disbalanceLabel.TabIndex = 7;
            this.disbalanceLabel.Text = "Lost buffers 0";
            // 
            // displayTimer
            // 
            this.displayTimer.Enabled = true;
            this.displayTimer.Interval = 500;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // bufferProgressBar
            // 
            this.bufferProgressBar.Location = new System.Drawing.Point(68, 243);
            this.bufferProgressBar.Name = "bufferProgressBar";
            this.bufferProgressBar.Size = new System.Drawing.Size(50, 23);
            this.bufferProgressBar.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Use buffer";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SampleRateLbl);
            this.groupBox1.Controls.Add(this.SCAGroup);
            this.groupBox1.Controls.Add(this.auxAudioEnableCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.audioDeviceComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.volumeTrackBar);
            this.groupBox1.Controls.Add(this.bufferProgressBar);
            this.groupBox1.Controls.Add(this.disbalanceLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 315);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // SCAGroup
            // 
            this.SCAGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCAGroup.Controls.Add(this.label5);
            this.SCAGroup.Controls.Add(this.fineTunningCtrl);
            this.SCAGroup.Controls.Add(this.label4);
            this.SCAGroup.Controls.Add(this.rb67);
            this.SCAGroup.Controls.Add(this.rb92);
            this.SCAGroup.Location = new System.Drawing.Point(0, 76);
            this.SCAGroup.Name = "SCAGroup";
            this.SCAGroup.Size = new System.Drawing.Size(200, 96);
            this.SCAGroup.TabIndex = 14;
            this.SCAGroup.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fine tune: ";
            // 
            // fineTunningCtrl
            // 
            this.fineTunningCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fineTunningCtrl.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.fineTunningCtrl.Location = new System.Drawing.Point(68, 68);
            this.fineTunningCtrl.Maximum = new decimal(new int[] {
            92000,
            0,
            0,
            0});
            this.fineTunningCtrl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fineTunningCtrl.Name = "fineTunningCtrl";
            this.fineTunningCtrl.Size = new System.Drawing.Size(125, 20);
            this.fineTunningCtrl.TabIndex = 16;
            this.fineTunningCtrl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fineTunningCtrl.ValueChanged += new System.EventHandler(this.fineTunningCtrl_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Subsidiary Communications Authority";
            // 
            // rb67
            // 
            this.rb67.AutoSize = true;
            this.rb67.Location = new System.Drawing.Point(5, 19);
            this.rb67.Name = "rb67";
            this.rb67.Size = new System.Drawing.Size(59, 17);
            this.rb67.TabIndex = 11;
            this.rb67.Text = "67 kHz";
            this.rb67.UseVisualStyleBackColor = true;
            this.rb67.CheckedChanged += new System.EventHandler(this.SCAGroup_Buttons);
            // 
            // rb92
            // 
            this.rb92.AutoSize = true;
            this.rb92.Location = new System.Drawing.Point(5, 42);
            this.rb92.Name = "rb92";
            this.rb92.Size = new System.Drawing.Size(59, 17);
            this.rb92.TabIndex = 12;
            this.rb92.Text = "92 kHz";
            this.rb92.UseVisualStyleBackColor = true;
            this.rb92.CheckedChanged += new System.EventHandler(this.SCAGroup_Buttons);
            // 
            // auxAudioEnableCheckBox
            // 
            this.auxAudioEnableCheckBox.AutoSize = true;
            this.auxAudioEnableCheckBox.Location = new System.Drawing.Point(9, 0);
            this.auxAudioEnableCheckBox.Name = "auxAudioEnableCheckBox";
            this.auxAudioEnableCheckBox.Size = new System.Drawing.Size(59, 17);
            this.auxAudioEnableCheckBox.TabIndex = 3;
            this.auxAudioEnableCheckBox.Text = "Enable";
            this.auxAudioEnableCheckBox.UseVisualStyleBackColor = true;
            this.auxAudioEnableCheckBox.CheckedChanged += new System.EventHandler(this.auxAudioEnableCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Audio device";
            // 
            // audioDeviceComboBox
            // 
            this.audioDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioDeviceComboBox.DropDownWidth = 330;
            this.audioDeviceComboBox.FormattingEnabled = true;
            this.audioDeviceComboBox.Location = new System.Drawing.Point(5, 39);
            this.audioDeviceComboBox.Name = "audioDeviceComboBox";
            this.audioDeviceComboBox.Size = new System.Drawing.Size(188, 21);
            this.audioDeviceComboBox.TabIndex = 0;
            this.audioDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.audioDeviceComboBox_SelectedIndexChanged);
            // 
            // SampleRateLbl
            // 
            this.SampleRateLbl.AutoSize = true;
            this.SampleRateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SampleRateLbl.Location = new System.Drawing.Point(6, 282);
            this.SampleRateLbl.Name = "SampleRateLbl";
            this.SampleRateLbl.Size = new System.Drawing.Size(123, 20);
            this.SampleRateLbl.TabIndex = 11;
            this.SampleRateLbl.Text = "Sample Rate: ";
            // 
            // SCATunerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SCATunerPanel";
            this.Size = new System.Drawing.Size(204, 332);
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SCAGroup.ResumeLayout(false);
            this.SCAGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fineTunningCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label disbalanceLabel;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.ProgressBar bufferProgressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox auxAudioEnableCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox audioDeviceComboBox;
        private System.Windows.Forms.GroupBox SCAGroup;
        private System.Windows.Forms.RadioButton rb67;
        private System.Windows.Forms.RadioButton rb92;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown fineTunningCtrl;
        private System.Windows.Forms.Label SampleRateLbl;
    }
}
