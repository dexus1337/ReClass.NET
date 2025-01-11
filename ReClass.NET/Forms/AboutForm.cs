using System;
using System.Diagnostics;
using System.Windows.Forms;
using ReClassNET.UI;
using DarkModeForms;

namespace ReClassNET.Forms
{
	public partial class AboutForm : IconForm
	{
		public DarkModeForms.DarkModeCS darkMode = null;

		public AboutForm()
		{
		    InitializeComponent();
			darkMode = new DarkModeForms.DarkModeCS(this)
			{
				Components = components != null ? components.Components:null,
				ColorMode = Program.Settings.DarkMode // DarkModeCS.DisplayMode.SystemDefault
			};

			bannerBox.Icon = Properties.Resources.ReClassNet.ToBitmap();
			bannerBox.Title = Constants.ApplicationName;
			bannerBox.Text = $"Version: {Constants.ApplicationVersion}";

			platformValueLabel.Text = Constants.Platform;
			buildTimeValueLabel.Text = Properties.Resources.BuildDate;
			authorValueLabel.Text = Constants.Author;
			homepageValueLabel.Text = Constants.HomepageUrl;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			GlobalWindowManager.AddWindow(this);
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);

			GlobalWindowManager.RemoveWindow(this);
		}

		private void homepageValueLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(Constants.HomepageUrl);
		}
	}
}
