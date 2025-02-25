using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Forms;
using ReClassNET.Nodes;
using ReClassNET.UI;

namespace ReClassNET.Forms
{
	public partial class TypeSelectionForm : IconForm
	{
		private readonly List<BaseNode> allTypes;

		public BaseNode SelectedType => typesListBox.SelectedItem as BaseNode;

		public TypeSelectionForm()
		{

			allTypes = NodeTypesBuilder.GetNodes();

			InitializeComponent();

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
			selectButton.Enabled = SelectedType != null;
		}

		private void classesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedType != null)
			{
				selectButton.PerformClick();
			}
		}

		private void ShowFilteredClasses()
		{
			IEnumerable<BaseNode> classes = allTypes;

			if (!string.IsNullOrEmpty(filterNameTextBox.Text))
			{
				classes = classes.Where(c => c.Name.IndexOf(filterNameTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			typesListBox.DataSource = classes.ToList();
		}
	}
}
