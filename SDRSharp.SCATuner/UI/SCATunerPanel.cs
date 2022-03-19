using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;
using SDRSharp.Radio.PortAudio;

namespace SDRSharp.SCATuner
{

    public partial class SCATunerPanel : UserControl
    {
        private AudioProcessor _audioProcessor;
        private ISharpControl _control;
        private AudioPlayer _player;
        private bool _playerIsStarted;
        public SCATunerPanel(AudioProcessor audioProcessor, ISharpControl control)
        {
            InitializeComponent();

            this._audioProcessor = audioProcessor;
            this._control = control;
            this._control.PropertyChanged += this.PropertyChangedHandler;
            this._player = new AudioPlayer(control, this._audioProcessor);
            this.AudioDeviceGet();
            this.audioDeviceComboBox_SelectedIndexChanged(null, null);
            this.volumeTrackBar.Value = Utils.GetIntSetting("SCATunerGain", 50);
            this.volumeTrackBar_Scroll(null, null);
            this.auxAudioEnableCheckBox.Checked = Utils.GetBooleanSetting("SCATunerEnable");

            //Trying to remember what SCA was selected
            //Yea I know not the nicest code but if you know any better way of doing, please submit PR

            this.rb67.Checked = Utils.GetBooleanSetting("SCAFrequency67", true);
            this.rb92.Checked = Utils.GetBooleanSetting("SCAFrequency92");

            this.EnableControls();
        }

        private void EnableControls()
        {
            bool isPlaying = this._control.IsPlaying;
            this.auxAudioEnableCheckBox.Enabled = isPlaying;
            this.audioDeviceComboBox.Enabled = !this._playerIsStarted;
        }

        public void StartAux()
        {
            if (this._playerIsStarted)
            {
                return;
            }
            this._player.Start();
            this._playerIsStarted = true;
            _control.AudioIsMuted = true;
            this.EnableControls();
        }

        public void StopAux()
        {
            if (!this._playerIsStarted)
            {
                return;
            }
            this._player.Stop();
            this._playerIsStarted = false;
            _control.AudioIsMuted = false;
            this.EnableControls();
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (!(propertyName == "StartRadio"))
            {
                if (!(propertyName == "StopRadio"))
                {
                    return;
                }
                this.EnableControls();
                this.StopAux();
            }
            else
            {
                this.EnableControls();
                if (this.auxAudioEnableCheckBox.Checked)
                {
                    this.StartAux();
                    return;
                }
            }
        }
        private void AudioDeviceGet()
        {
            int num = 0;
            int num2 = -1;
            List<AudioDevice> devices = AudioDevice.GetDevices(DeviceDirection.Output);
            string stringSetting = Utils.GetStringSetting("SCATunerDevice", string.Empty);
            for (int i = 0; i < devices.Count; i++)
            {
                this.audioDeviceComboBox.Items.Add(devices[i]);
                if (devices[i].IsDefault)
                {
                    num = i;
                }
                if (devices[i].ToString() == stringSetting)
                {
                    num2 = i;
                }
            }
            if (this.audioDeviceComboBox.Items.Count > 0)
            {
                this.audioDeviceComboBox.SelectedIndex = ((num2 >= 0) ? num2 : num);
            }
        }

        public void StoreSettings()
        {
            Utils.SaveSetting("SCATunerEnable", this.auxAudioEnableCheckBox.Checked);
            Utils.SaveSetting("SCATunerDevice", this.audioDeviceComboBox.SelectedItem);
            Utils.SaveSetting("SCATunerGain", this.volumeTrackBar.Value);

            //Trying to remember what SCA was selected
            //Yea I know not the nicest code but if you know any better way of doing, please submit PR
            if (this.rb67.Checked)
            {
                Utils.SaveSetting("SCAFrequency67", this.rb67.Checked);
                Utils.SaveSetting("SCAFrequency92", false);
            }
            else if (this.rb92.Checked)
            {
                Utils.SaveSetting("SCAFrequency67", false);
                Utils.SaveSetting("SCAFrequency92", this.rb92.Checked);
            }
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            this._player.Gain = (float)Math.Pow((double)this.volumeTrackBar.Value, 3.0);
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            this.disbalanceLabel.Text = string.Format("Lost buffers {0:f0}", this._player.LostBuffers);
            this.bufferProgressBar.Value = this._player.BufferSize;
        }

        private void audioDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioDevice audioDevice = (AudioDevice)this.audioDeviceComboBox.SelectedItem;
            this._player.DeviceIndex = audioDevice.Index;
        }

        private void auxAudioEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!this._control.IsPlaying)
            {
                return;
            }
            if (this.auxAudioEnableCheckBox.Checked)
            {
                this.StartAux();
                return;
            }
            if (!this.auxAudioEnableCheckBox.Checked)
            {
                this.StopAux();
            }
        }

        //Determine which Radio Button was pressed
        private void SCAGroup_Buttons(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = sender as System.Windows.Forms.RadioButton;
            if (radioButton.Checked == true)
            {
                switch (radioButton.Text)
                {
                    case "67 kHz":
                        _player.SCAFrequency = 67000.0; this.fineTunningCtrl.Value = 67000;
                        break;
                    case "92 kHz":
                        _player.SCAFrequency = 92000.0; this.fineTunningCtrl.Value = 92000;
                        break;
                }
            }
        }

        private void fineTunningCtrl_ValueChanged(object sender, EventArgs e)
        {
            _player.SCAFrequency = (double)this.fineTunningCtrl.Value;
            if (this.fineTunningCtrl.Value == 67000)
                this.rb67.Checked = true;
            else if (this.fineTunningCtrl.Value == 92000)
                this.rb92.Checked = true;
        }
    }
}
