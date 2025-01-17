﻿using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VRChatModeSwitcher
{
    public partial class formVRChatModeSwitcher : Form
    {
        // 初期化
        private readonly string[] args;
        private readonly string arg;
        public formVRChatModeSwitcher(string[] inArgs)
        {
            args = inArgs;
            arg = "";
            foreach (var item in args)
            {
                arg += item + " ";
            }
            InitializeComponent();
            ConfigLoad();

            if (arg == "")
                textBoxLink.Text = "-no arguments-";
            else
            {
                textBoxLink.Text = arg;
                if (arg.Contains("BuildAndRun"))
                    EnableParalellLaunch();
            }
        }
        private void EnableParalellLaunch()
        {
            labelParallel.Visible = true;
            intboxParallel.Visible = true;
        }

        string steamPath;
        string oculusPath;
        string arguments;

        Dictionary<string, string> profiles;
        private void ConfigLoad()
        {
            var textSteamPath = ConfigurationManager.AppSettings["steamPath"];
            var test = Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess;
            RegistryKey rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 438100");
            if (rkey != null && (textSteamPath == "" || textSteamPath == null))
                steamPath = (string)rkey.GetValue("InstallLocation") + @"\VRChat.exe";
            else
                steamPath = ConfigurationManager.AppSettings["steamPath"];

            oculusPath = ConfigurationManager.AppSettings["oculusPath"];
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            arguments = ConfigurationManager.AppSettings["Arguments"];

            if ((steamPath == "" || steamPath == null) && (oculusPath == "" || oculusPath == null))
            {
                MessageBox.Show("Steam版VRChatのインストール場所の読み込みに失敗しました。\n設定からSteam版かOculus版のVRChat.exeのパスを設定してください。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonSelectDesktop.Enabled = false;
                buttonSelectVR.Enabled = false;
                radioSteam.Enabled = false;
                radioOculus.Enabled = false;
            }
            else
            {
                var radioSelected = ConfigurationManager.AppSettings["selected"];
                if (radioSelected == "1")
                    radioSteam.Checked = true;
                else if (radioSelected == "2")
                    radioOculus.Checked = true;


                string profilesJson = ConfigurationManager.AppSettings["Profiles"];
                if (profilesJson == "" || profilesJson == null)
                    profilesJson = @"{""0"":""Default""}";
                profiles = JsonConvert.DeserializeObject<Dictionary<string, string>>(profilesJson);
                comboBox1.Items.Clear();
                foreach (var item in profiles)
                {
                    comboBox1.Items.Add($"{item.Key} : {item.Value}");
                }
                string selectedProfiles = ConfigurationManager.AppSettings["SelectedProfiles"];
                if (selectedProfiles == null)
                    selectedProfiles = "0";
                if (profiles.Count <= int.Parse(selectedProfiles))
                    selectedProfiles = "0";

                comboBox1.SelectedIndex = int.Parse(selectedProfiles);

                radioSteam.Enabled = (steamPath != "") && (steamPath != null);
                radioOculus.Enabled = (oculusPath != "") && (oculusPath != null);
                buttonSelectDesktop.Enabled = radioOculus.Checked || radioSteam.Checked;
                buttonSelectVR.Enabled = radioOculus.Checked || radioSteam.Checked;
            }

        }

        // クリックイベント

        private void ButtonSelectVR_Click(object sender, EventArgs e)
        {
            bool result = RunVRChat(true);
            if (result)
                Application.Exit();
        }

        private void ButtonSelectDesktop_Click(object sender, EventArgs e)
        {
            bool result = RunVRChat(false);
            if (result)
                Application.Exit();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool RunVRChat(bool VRMode)
        {
            string profileNo = comboBox1.SelectedItem.ToString().Split(':')[0]
                .Substring(0, comboBox1.SelectedItem.ToString().Split(':')[0].Length - 1);
            string outArg = $"--profile={profileNo} {arg}";
            if (arguments != "")
                outArg = $"{arguments} {outArg}";
            if (!VRMode)
                outArg = $"--no-vr {outArg}";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "VRChat.exe";
            psi.Arguments = outArg;
            string path = "";

            if (radioSteam.Checked)
                path = Path.GetDirectoryName(steamPath);
            else if (radioOculus.Checked)
                path = Path.GetDirectoryName(oculusPath);
            try
            {
                Environment.CurrentDirectory = path;
                for (int i = 0; i < intboxParallel.Value; i++)
                {
                    Process p = Process.Start(psi);
                    if (VRMode && i == 0) psi.Arguments = $"--no-vr {outArg}";
                }
                return true;
            }
            catch(Win32Exception ex)
            {
                if (ex.NativeErrorCode == 2)
                    MessageBox.Show("VRChatの起動に失敗しました。\nVRChat.exeが見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("VRChatの起動に失敗しました。\n未知のエラーが発生しました。\nエラーコード : " + ex.NativeErrorCode + "\nエラーメッセージ : " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VRChatの起動に失敗しました。\n未知のエラーが発生しました。\nエラーメッセージ : " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Assembly myAssembly = Assembly.GetEntryAssembly();
            path = Path.GetDirectoryName(myAssembly.Location);
            Environment.CurrentDirectory = path;
            return false;
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            Form2 fs2 = new Form2();
            fs2.ShowDialog(this);
            ConfigLoad();
        }

        private void radioSteam_CheckedChanged(object sender, EventArgs e)
        {
            buttonSelectDesktop.Enabled = true;
            buttonSelectVR.Enabled = true;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["Selected"] == null)
                config.AppSettings.Settings.Add("Selected", "0");

            if (radioSteam.Checked)
                config.AppSettings.Settings["Selected"].Value = "1";
            else
                config.AppSettings.Settings["Selected"].Value = "2";

            config.Save();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["SelectedProfiles"] == null)
                config.AppSettings.Settings.Add("SelectedProfiles", "0");
            config.AppSettings.Settings["SelectedProfiles"].Value = comboBox1.SelectedIndex.ToString();

            config.Save();
        }
    }
}
