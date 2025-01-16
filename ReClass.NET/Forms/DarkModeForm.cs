using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using ReClassNET;

namespace DarkModeForms
{
	public class DarkModeForm : Form
	{
		private DarkModeCS darkMode;

		public DarkModeForm()
		{
			//initialization will happen in OnHandleCreated
		}

		protected virtual void InitializeDarkMode()
		{
			if (darkMode == null && !DesignMode && !LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
			{
				// Get components from the derived form
				IContainer formComponents = null;
				var componentsField = GetType().GetField("components",
					BindingFlags.NonPublic |
					BindingFlags.Instance |
					BindingFlags.DeclaredOnly);

				if (componentsField != null)
				{
					formComponents = componentsField.GetValue(this) as IContainer;
				}

				darkMode = new DarkModeCS(this)
				{
					Components = formComponents?.Components,
					ColorMode = Program.Settings.DarkMode,
					ColorizeIcons = Program.Settings.ColorizeIcons,
					RoundedPanels = Program.Settings.RoundedPanels
				};

			}
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);

			if (!DesignMode && !LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
			{
				InitializeDarkMode();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!DesignMode && !LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
			{
				InitializeDarkMode();
			}
		}

		public DarkModeCS DarkMode { get { return darkMode; } }

		public void UpdateDarkMode()
		{
			if (!DesignMode && !LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime) && darkMode != null)
			{
				darkMode.ApplyTheme(Program.Settings.DarkMode);
			}
		}
	}
}