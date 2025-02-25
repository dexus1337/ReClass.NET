using ReClassNET.Controls;

namespace ReClassNET.Forms
{
	partial class PluginForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pluginsTabPage = new System.Windows.Forms.TabPage();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.pluginsDataGridView = new System.Windows.Forms.DataGridView();
            this.iconColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nativesTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.functionsProvidersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getMoreLinkLabel = new System.Windows.Forms.LinkLabel();
            this.closeButton = new System.Windows.Forms.Button();
            this.bannerBox = new ReClassNET.Controls.BannerBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.unloadPlugin = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.pluginsTabPage.SuspendLayout();
            this.descriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pluginsDataGridView)).BeginInit();
            this.nativesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.pluginsTabPage);
            this.tabControl.Controls.Add(this.nativesTabPage);
            this.tabControl.Location = new System.Drawing.Point(14, 74);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(835, 404);
            this.tabControl.TabIndex = 0;
            // 
            // pluginsTabPage
            // 
            this.pluginsTabPage.Controls.Add(this.descriptionGroupBox);
            this.pluginsTabPage.Controls.Add(this.pluginsDataGridView);
            this.pluginsTabPage.Location = new System.Drawing.Point(4, 25);
            this.pluginsTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.pluginsTabPage.Name = "pluginsTabPage";
            this.pluginsTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.pluginsTabPage.Size = new System.Drawing.Size(827, 375);
            this.pluginsTabPage.TabIndex = 0;
            this.pluginsTabPage.Text = "Plugins";
            this.pluginsTabPage.UseVisualStyleBackColor = true;
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(7, 254);
            this.descriptionGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.descriptionGroupBox.Size = new System.Drawing.Size(812, 111);
            this.descriptionGroupBox.TabIndex = 1;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "<>";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(7, 20);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(798, 80);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "<>";
            // 
            // pluginsDataGridView
            // 
            this.pluginsDataGridView.AllowUserToAddRows = false;
            this.pluginsDataGridView.AllowUserToDeleteRows = false;
            this.pluginsDataGridView.AllowUserToResizeRows = false;
            this.pluginsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.pluginsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pluginsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconColumn,
            this.nameColumn,
            this.versionColumn,
            this.authorColumn});
            this.pluginsDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pluginsDataGridView.Location = new System.Drawing.Point(4, 4);
            this.pluginsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.pluginsDataGridView.MultiSelect = false;
            this.pluginsDataGridView.Name = "pluginsDataGridView";
            this.pluginsDataGridView.ReadOnly = true;
            this.pluginsDataGridView.RowHeadersVisible = false;
            this.pluginsDataGridView.RowHeadersWidth = 51;
            this.pluginsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pluginsDataGridView.Size = new System.Drawing.Size(819, 242);
            this.pluginsDataGridView.TabIndex = 0;
            this.pluginsDataGridView.SelectionChanged += new System.EventHandler(this.pluginsDataGridView_SelectionChanged);
            // 
            // iconColumn
            // 
            this.iconColumn.DataPropertyName = "Icon";
            this.iconColumn.HeaderText = "";
            this.iconColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.iconColumn.MinimumWidth = 18;
            this.iconColumn.Name = "iconColumn";
            this.iconColumn.ReadOnly = true;
            this.iconColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.iconColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.iconColumn.Width = 18;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.MinimumWidth = 6;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // versionColumn
            // 
            this.versionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.versionColumn.DataPropertyName = "Version";
            this.versionColumn.HeaderText = "Version";
            this.versionColumn.MinimumWidth = 6;
            this.versionColumn.Name = "versionColumn";
            this.versionColumn.ReadOnly = true;
            this.versionColumn.Width = 81;
            // 
            // authorColumn
            // 
            this.authorColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.authorColumn.DataPropertyName = "Author";
            this.authorColumn.HeaderText = "Author";
            this.authorColumn.MinimumWidth = 6;
            this.authorColumn.Name = "authorColumn";
            this.authorColumn.ReadOnly = true;
            this.authorColumn.Width = 79;
            // 
            // nativesTabPage
            // 
            this.nativesTabPage.Controls.Add(this.label2);
            this.nativesTabPage.Controls.Add(this.functionsProvidersComboBox);
            this.nativesTabPage.Controls.Add(this.label1);
            this.nativesTabPage.Location = new System.Drawing.Point(4, 25);
            this.nativesTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.nativesTabPage.Name = "nativesTabPage";
            this.nativesTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.nativesTabPage.Size = new System.Drawing.Size(827, 375);
            this.nativesTabPage.TabIndex = 1;
            this.nativesTabPage.Text = "Native Helper";
            this.nativesTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Functions Provider:";
            // 
            // functionsProvidersComboBox
            // 
            this.functionsProvidersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionsProvidersComboBox.FormattingEnabled = true;
            this.functionsProvidersComboBox.Location = new System.Drawing.Point(128, 78);
            this.functionsProvidersComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.functionsProvidersComboBox.Name = "functionsProvidersComboBox";
            this.functionsProvidersComboBox.Size = new System.Drawing.Size(355, 24);
            this.functionsProvidersComboBox.TabIndex = 20;
            this.functionsProvidersComboBox.SelectionChangeCommitted += new System.EventHandler(this.functionsProvidersComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plugins can provide different methods how ReClass.NET accesses a remote process.\r" +
    "\n\r\nWarning: You should detach from the current process before changing a functio" +
    "n.";
            // 
            // getMoreLinkLabel
            // 
            this.getMoreLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getMoreLinkLabel.AutoSize = true;
            this.getMoreLinkLabel.Location = new System.Drawing.Point(10, 487);
            this.getMoreLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.getMoreLinkLabel.Name = "getMoreLinkLabel";
            this.getMoreLinkLabel.Size = new System.Drawing.Size(123, 17);
            this.getMoreLinkLabel.TabIndex = 1;
            this.getMoreLinkLabel.TabStop = true;
            this.getMoreLinkLabel.Text = "Get more plugins...";
            this.getMoreLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getMoreLinkLabel_LinkClicked);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(762, 481);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(88, 28);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // bannerBox
            // 
            this.bannerBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.bannerBox.Icon = global::ReClassNET.Properties.Resources.B32x32_Plugin;
            this.bannerBox.Location = new System.Drawing.Point(0, 0);
            this.bannerBox.Margin = new System.Windows.Forms.Padding(4);
            this.bannerBox.Name = "bannerBox";
            this.bannerBox.Size = new System.Drawing.Size(863, 48);
            this.bannerBox.TabIndex = 3;
            this.bannerBox.Text = "Here you can configure all loaded ReClass.NET plugins.";
            this.bannerBox.Title = "Plugins";
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.loadButton.Location = new System.Drawing.Point(471, 481);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(115, 28);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load Plugin";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // unloadPlugin
            // 
            this.unloadPlugin.Enabled = false;
            this.unloadPlugin.Font = new System.Drawing.Font("Tahoma", 8F);
            this.unloadPlugin.Location = new System.Drawing.Point(608, 481);
            this.unloadPlugin.Name = "unloadPlugin";
            this.unloadPlugin.Size = new System.Drawing.Size(115, 28);
            this.unloadPlugin.TabIndex = 6;
            this.unloadPlugin.Text = "Unload Plugin";
            this.unloadPlugin.UseVisualStyleBackColor = true;
            this.unloadPlugin.Click += new System.EventHandler(this.unloadPlugin_Click);
            // 
            // PluginForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 521);
            this.Controls.Add(this.unloadPlugin);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.bannerBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.getMoreLinkLabel);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReClass.NET - Plugins";
            this.tabControl.ResumeLayout(false);
            this.pluginsTabPage.ResumeLayout(false);
            this.descriptionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pluginsDataGridView)).EndInit();
            this.nativesTabPage.ResumeLayout(false);
            this.nativesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage pluginsTabPage;
		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.DataGridView pluginsDataGridView;
		private System.Windows.Forms.TabPage nativesTabPage;
		private System.Windows.Forms.LinkLabel getMoreLinkLabel;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.Label label1;
		private BannerBox bannerBox;
		private System.Windows.Forms.ComboBox functionsProvidersComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridViewImageColumn iconColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn versionColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn authorColumn;
		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.Button unloadPlugin;
	}
}