using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Forms;
using ReClassNET.Nodes;
using ReClassNET.UI;

namespace ReClassNET.Forms
{
	public partial class ClassSelectionForm : IconForm
	{
		private readonly List<ClassNode> allClasses;
		public static DarkModeForms.DarkModeCS darkMode = null; 

		public ClassNode SelectedClass => classesListBox.SelectedItem as ClassNode;

		public ClassSelectionForm(IEnumerable<ClassNode> classes)
		{
			Contract.Requires(classes != null);

			allClasses = classes.ToList();

			InitializeComponent();     
			darkMode = new DarkModeForms.DarkModeCS(this)
			{
        Components = components != null ? components.Components:null,
				ColorMode = Program.Settings.DarkMode // DarkModeCS.DisplayMode.SystemDefault
			};      

			ShowFilteredClasses();
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

		private void filterNameTextBox_TextChanged(object sender, EventArgs e)
		{
			ShowFilteredClasses();
		}

		private void classesListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectButton.Enabled = SelectedClass != null;
		}

		private void classesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedClass != null)
			{
				selectButton.PerformClick();
			}
		}

		private void ShowFilteredClasses()
		{
			IEnumerable<ClassNode> classes = allClasses;

			if (!string.IsNullOrEmpty(filterNameTextBox.Text))
			{
				classes = classes.Where(c => c.Name.IndexOf(filterNameTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			classesListBox.DataSource = classes.ToList();
		}
	}
}
