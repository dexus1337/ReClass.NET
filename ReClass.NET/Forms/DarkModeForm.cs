using System;
using System.ComponentModel;
using System.Windows.Forms;
using ReClassNET;

namespace DarkModeForms
{
	public class DarkModeForm : Form
	{
		private DarkModeCS darkMode;

		public DarkModeForm()
		{
			InitializeDarkMode();
		}

		protected virtual void InitializeDarkMode()
		{
			if (darkMode == null)
			{
				// Get components from the derived form
				IContainer formComponents = null;
				var componentsProp = GetType().GetProperty("components",
					System.Reflection.BindingFlags.NonPublic |
					System.Reflection.BindingFlags.Instance);

				if (componentsProp != null)
				{
					formComponents = componentsProp.GetValue(this) as IContainer;
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

		public void UpdateDarkMode()
		{
			if (darkMode != null)
			{
				darkMode.ApplyTheme(Program.Settings.DarkMode);
			}
		}

		public DarkModeCS GetDarkMode()
		{
			return darkMode;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			InitializeDarkMode();
		}
	}
}