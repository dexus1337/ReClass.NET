using System;
using System.Windows.Forms;

namespace ReClassNET.Forms
{
	public partial class InputForm : IconForm
	{
		public string Value { get; private set; }

		public InputForm(string title, string prompt)
		{
			InitializeComponent();

			Text = title;
			promptLabel.Text = prompt;

			MinimizeBox = false;
			MaximizeBox = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			Value = inputTextBox.Text;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void inputTextBox_TextChanged(object sender, EventArgs e)
		{
			okButton.Enabled = !string.IsNullOrWhiteSpace(inputTextBox.Text);
		}
	}
}