using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReClassNET.Forms
{
	public partial class HotkeyInputForm : Form
	{
		public Keys HotKey { get; private set; }

		private readonly Type currentNodeType;
		private readonly Settings settings;

		private System.Windows.Forms.TextBox hotkeyTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;

		public HotkeyInputForm(Settings settings, Type nodeType)
		{
			InitializeComponent();
			this.settings = settings;
			this.currentNodeType = nodeType;
			hotkeyTextBox.KeyDown += HotkeyTextBox_KeyDown;
			hotkeyTextBox.KeyUp += HotkeyTextBox_KeyUp;
		}

		private void HotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			e.SuppressKeyPress = true;

			if (e.KeyCode == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
				Close();
				return;
			}

			if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
			{
				HotKey = Keys.None;
				hotkeyTextBox.Text = "None";
				return;
			}

			Keys modifiers = e.Modifiers;
			Keys pressedKey = e.KeyCode;

			if (pressedKey == Keys.ShiftKey || pressedKey == Keys.ControlKey ||
				pressedKey == Keys.Menu || pressedKey == Keys.LWin || pressedKey == Keys.RWin)
			{
				return;
			}

			Keys newHotkey;
			if (modifiers == Keys.None)
			{
				// Allow single keys only if they are valid Keys enum values
				if (!IsValidSingleKey(pressedKey))
				{
					hotkeyTextBox.Text = "Invalid key. Use a valid key or add Ctrl, Alt, or Shift";
					return;
				}
				newHotkey = pressedKey;
			}
			else
			{
				newHotkey = modifiers | pressedKey;
			}

			// Check for duplicates
			if (settings.IsHotkeyInUse(newHotkey, currentNodeType))
			{
				string owner = settings.GetHotkeyOwner(newHotkey);
				MessageBox.Show($"This hotkey is already assigned to {owner}.",
							  "Duplicate Hotkey",
							  MessageBoxButtons.OK,
							  MessageBoxIcon.Warning);
				return;
			}

			// Check for system hotkeys
			if (IsSystemHotkeyInUse(newHotkey))
			{
				var result = MessageBox.Show(
					"This hotkey might conflict with system or other application shortcuts. Use anyway?",
					"Potential Conflict",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);

				if (result == DialogResult.No)
					return;
			}

			HotKey = newHotkey;
			hotkeyTextBox.Text = HotKey.ToString();

			if (e.KeyCode == Keys.Return)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private bool IsValidSingleKey(Keys key)
		{
			return
				// Letters
				(key >= Keys.A && key <= Keys.Z) ||
				// Numbers
				(key >= Keys.D0 && key <= Keys.D9) ||
				// Function keys
				(key >= Keys.F1 && key <= Keys.F12) ||
				// Other common valid keys
				key == Keys.Tab ||
				key == Keys.Space ||
				key == Keys.Insert ||
				key == Keys.Delete ||
				key == Keys.Home ||
				key == Keys.End ||
				key == Keys.PageUp ||
				key == Keys.PageDown ||
				key == Keys.PrintScreen;
		}

		private bool IsSystemHotkeyInUse(Keys hotkey)
		{
			// Common system hotkeys to check against
			var commonHotkeys = new Dictionary<Keys, string>
		{
			{ Keys.Control | Keys.C, "Copy" },
			{ Keys.Control | Keys.V, "Paste" },
			{ Keys.Control | Keys.X, "Cut" },
			{ Keys.Control | Keys.Z, "Undo" },
			{ Keys.Control | Keys.Y, "Redo" },
			{ Keys.Control | Keys.A, "Select All" },
			{ Keys.Control | Keys.S, "Save" },
			{ Keys.Control | Keys.O, "Open" },
			{ Keys.Control | Keys.N, "New" },
			{ Keys.Control | Keys.P, "Print" },
			{ Keys.Control | Keys.F, "Find" },
			{ Keys.F1, "Help" },
            // Add more as needed
        };

			return commonHotkeys.ContainsKey(hotkey);
		}

		private void HotkeyTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			e.SuppressKeyPress = true;
		}

		private void InitializeComponent()
		{
			this.hotkeyTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// hotkeyTextBox
			// 
			this.hotkeyTextBox.Location = new System.Drawing.Point(12, 25);
			this.hotkeyTextBox.Name = "hotkeyTextBox";
			this.hotkeyTextBox.Size = new System.Drawing.Size(260, 20);
			this.hotkeyTextBox.TabIndex = 0;
			this.hotkeyTextBox.Text = "Press new hotkey...";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Press new hotkey";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(116, 51);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(197, 51);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// HotkeyInputForm
			// 
			this.AcceptButton = this.okButton;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(284, 86);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.hotkeyTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HotkeyInputForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Hotkey";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

	}
}