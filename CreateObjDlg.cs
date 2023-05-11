using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Power2000.General.StandardDef;

namespace Power2000.CommuCfg
{

	public class CreateObjDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button butnAdd;
		private System.Windows.Forms.Button butnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button butnFinish;

		private PropertyValueChanged pvcHandler = null;
		private System.Windows.Forms.PropertyGrid PropGrid;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreateObjDlg(PropertyValueChanged PVCHandler)
		{
			pvcHandler = PVCHandler;

			InitializeComponent();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreateObjDlg));
			this.butnAdd = new System.Windows.Forms.Button();
			this.butnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.butnFinish = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.PropGrid = new System.Windows.Forms.PropertyGrid();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// butnAdd
			// 
			this.butnAdd.AccessibleDescription = resources.GetString("butnAdd.AccessibleDescription");
			this.butnAdd.AccessibleName = resources.GetString("butnAdd.AccessibleName");
			this.butnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("butnAdd.Anchor")));
			this.butnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butnAdd.BackgroundImage")));
			this.butnAdd.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("butnAdd.Dock")));
			this.butnAdd.Enabled = ((bool)(resources.GetObject("butnAdd.Enabled")));
			this.butnAdd.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("butnAdd.FlatStyle")));
			this.butnAdd.Font = ((System.Drawing.Font)(resources.GetObject("butnAdd.Font")));
			this.butnAdd.Image = ((System.Drawing.Image)(resources.GetObject("butnAdd.Image")));
			this.butnAdd.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("butnAdd.ImageAlign")));
			this.butnAdd.ImageIndex = ((int)(resources.GetObject("butnAdd.ImageIndex")));
			this.butnAdd.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("butnAdd.ImeMode")));
			this.butnAdd.Location = ((System.Drawing.Point)(resources.GetObject("butnAdd.Location")));
			this.butnAdd.Name = "butnAdd";
			this.butnAdd.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("butnAdd.RightToLeft")));
			this.butnAdd.Size = ((System.Drawing.Size)(resources.GetObject("butnAdd.Size")));
			this.butnAdd.TabIndex = ((int)(resources.GetObject("butnAdd.TabIndex")));
			this.butnAdd.Text = resources.GetString("butnAdd.Text");
			this.butnAdd.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("butnAdd.TextAlign")));
			this.butnAdd.Visible = ((bool)(resources.GetObject("butnAdd.Visible")));
			this.butnAdd.Click += new System.EventHandler(this.butnAdd_Click);
			// 
			// butnCancel
			// 
			this.butnCancel.AccessibleDescription = resources.GetString("butnCancel.AccessibleDescription");
			this.butnCancel.AccessibleName = resources.GetString("butnCancel.AccessibleName");
			this.butnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("butnCancel.Anchor")));
			this.butnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butnCancel.BackgroundImage")));
			this.butnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butnCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("butnCancel.Dock")));
			this.butnCancel.Enabled = ((bool)(resources.GetObject("butnCancel.Enabled")));
			this.butnCancel.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("butnCancel.FlatStyle")));
			this.butnCancel.Font = ((System.Drawing.Font)(resources.GetObject("butnCancel.Font")));
			this.butnCancel.Image = ((System.Drawing.Image)(resources.GetObject("butnCancel.Image")));
			this.butnCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("butnCancel.ImageAlign")));
			this.butnCancel.ImageIndex = ((int)(resources.GetObject("butnCancel.ImageIndex")));
			this.butnCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("butnCancel.ImeMode")));
			this.butnCancel.Location = ((System.Drawing.Point)(resources.GetObject("butnCancel.Location")));
			this.butnCancel.Name = "butnCancel";
			this.butnCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("butnCancel.RightToLeft")));
			this.butnCancel.Size = ((System.Drawing.Size)(resources.GetObject("butnCancel.Size")));
			this.butnCancel.TabIndex = ((int)(resources.GetObject("butnCancel.TabIndex")));
			this.butnCancel.Text = resources.GetString("butnCancel.Text");
			this.butnCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("butnCancel.TextAlign")));
			this.butnCancel.Visible = ((bool)(resources.GetObject("butnCancel.Visible")));
			this.butnCancel.Click += new System.EventHandler(this.butnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.AccessibleDescription = resources.GetString("panel1.AccessibleDescription");
			this.panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panel1.Anchor")));
			this.panel1.AutoScroll = ((bool)(resources.GetObject("panel1.AutoScroll")));
			this.panel1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMargin")));
			this.panel1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMinSize")));
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Controls.Add(this.butnAdd);
			this.panel1.Controls.Add(this.butnCancel);
			this.panel1.Controls.Add(this.butnFinish);
			this.panel1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panel1.Dock")));
			this.panel1.Enabled = ((bool)(resources.GetObject("panel1.Enabled")));
			this.panel1.Font = ((System.Drawing.Font)(resources.GetObject("panel1.Font")));
			this.panel1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panel1.ImeMode")));
			this.panel1.Location = ((System.Drawing.Point)(resources.GetObject("panel1.Location")));
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panel1.RightToLeft")));
			this.panel1.Size = ((System.Drawing.Size)(resources.GetObject("panel1.Size")));
			this.panel1.TabIndex = ((int)(resources.GetObject("panel1.TabIndex")));
			this.panel1.Text = resources.GetString("panel1.Text");
			this.panel1.Visible = ((bool)(resources.GetObject("panel1.Visible")));
			// 
			// butnFinish
			// 
			this.butnFinish.AccessibleDescription = resources.GetString("butnFinish.AccessibleDescription");
			this.butnFinish.AccessibleName = resources.GetString("butnFinish.AccessibleName");
			this.butnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("butnFinish.Anchor")));
			this.butnFinish.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butnFinish.BackgroundImage")));
			this.butnFinish.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("butnFinish.Dock")));
			this.butnFinish.Enabled = ((bool)(resources.GetObject("butnFinish.Enabled")));
			this.butnFinish.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("butnFinish.FlatStyle")));
			this.butnFinish.Font = ((System.Drawing.Font)(resources.GetObject("butnFinish.Font")));
			this.butnFinish.Image = ((System.Drawing.Image)(resources.GetObject("butnFinish.Image")));
			this.butnFinish.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("butnFinish.ImageAlign")));
			this.butnFinish.ImageIndex = ((int)(resources.GetObject("butnFinish.ImageIndex")));
			this.butnFinish.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("butnFinish.ImeMode")));
			this.butnFinish.Location = ((System.Drawing.Point)(resources.GetObject("butnFinish.Location")));
			this.butnFinish.Name = "butnFinish";
			this.butnFinish.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("butnFinish.RightToLeft")));
			this.butnFinish.Size = ((System.Drawing.Size)(resources.GetObject("butnFinish.Size")));
			this.butnFinish.TabIndex = ((int)(resources.GetObject("butnFinish.TabIndex")));
			this.butnFinish.Text = resources.GetString("butnFinish.Text");
			this.butnFinish.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("butnFinish.TextAlign")));
			this.butnFinish.Visible = ((bool)(resources.GetObject("butnFinish.Visible")));
			this.butnFinish.Click += new System.EventHandler(this.butnFinish_Click);
			// 
			// panel2
			// 
			this.panel2.AccessibleDescription = resources.GetString("panel2.AccessibleDescription");
			this.panel2.AccessibleName = resources.GetString("panel2.AccessibleName");
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panel2.Anchor")));
			this.panel2.AutoScroll = ((bool)(resources.GetObject("panel2.AutoScroll")));
			this.panel2.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panel2.AutoScrollMargin")));
			this.panel2.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panel2.AutoScrollMinSize")));
			this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
			this.panel2.Controls.Add(this.PropGrid);
			this.panel2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panel2.Dock")));
			this.panel2.Enabled = ((bool)(resources.GetObject("panel2.Enabled")));
			this.panel2.Font = ((System.Drawing.Font)(resources.GetObject("panel2.Font")));
			this.panel2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panel2.ImeMode")));
			this.panel2.Location = ((System.Drawing.Point)(resources.GetObject("panel2.Location")));
			this.panel2.Name = "panel2";
			this.panel2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panel2.RightToLeft")));
			this.panel2.Size = ((System.Drawing.Size)(resources.GetObject("panel2.Size")));
			this.panel2.TabIndex = ((int)(resources.GetObject("panel2.TabIndex")));
			this.panel2.Text = resources.GetString("panel2.Text");
			this.panel2.Visible = ((bool)(resources.GetObject("panel2.Visible")));
			// 
			// PropGrid
			// 
			this.PropGrid.AccessibleDescription = resources.GetString("PropGrid.AccessibleDescription");
			this.PropGrid.AccessibleName = resources.GetString("PropGrid.AccessibleName");
			this.PropGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PropGrid.Anchor")));
			this.PropGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PropGrid.BackgroundImage")));
			this.PropGrid.CommandsVisibleIfAvailable = true;
			this.PropGrid.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PropGrid.Dock")));
			this.PropGrid.Enabled = ((bool)(resources.GetObject("PropGrid.Enabled")));
			this.PropGrid.Font = ((System.Drawing.Font)(resources.GetObject("PropGrid.Font")));
			this.PropGrid.HelpVisible = ((bool)(resources.GetObject("PropGrid.HelpVisible")));
			this.PropGrid.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PropGrid.ImeMode")));
			this.PropGrid.LargeButtons = false;
			this.PropGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.PropGrid.Location = ((System.Drawing.Point)(resources.GetObject("PropGrid.Location")));
			this.PropGrid.Name = "PropGrid";
			this.PropGrid.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PropGrid.RightToLeft")));
			this.PropGrid.Size = ((System.Drawing.Size)(resources.GetObject("PropGrid.Size")));
			this.PropGrid.TabIndex = ((int)(resources.GetObject("PropGrid.TabIndex")));
			this.PropGrid.Text = resources.GetString("PropGrid.Text");
			this.PropGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.PropGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.PropGrid.Visible = ((bool)(resources.GetObject("PropGrid.Visible")));
			this.PropGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			// 
			// CreateObjDlg
			// 
			this.AcceptButton = this.butnFinish;
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.butnCancel;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "CreateObjDlg";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.CreateObjDlg_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public object SelectedObj
		{
			get{ return PropGrid.SelectedObject;}
			set{ PropGrid.SelectedObject = value;}
		}

		public void ShowDlg(object obj)
		{
			PropGrid.SelectedObject = obj;
			PropGrid.ExpandAllGridItems();
            PropGrid.PropertySort = PropertySort.Categorized;
			PropGrid.Focus();
			butnAdd.Enabled = butnFinish.Enabled = false;

			if (!Visible)
				ShowDialog();				
		}		

		private void butnCancel_Click(object sender, System.EventArgs e)
		{
			if (Cancel != null)
				Cancel(this, null);

			Close();
		}
        private bool objNewCheck()
        {
            IObjectVerify newObj = PropGrid.SelectedObject as IObjectVerify;
            if (newObj != null)
            {
                return newObj.Verify();
            }
            return true;
        }

		private void butnFinish_Click(object sender, System.EventArgs e)
		{
            if (!objNewCheck())
                return;
			if (Finish != null)
				Finish(this, null);

			Close();
		}

		private void butnAdd_Click(object sender, System.EventArgs e)
		{
            if (!objNewCheck())
                return;
			if (ContinueCreate != null)
				ContinueCreate(this, null);
		}

		private void propertyGrid_PropertyValueChanged(object sender, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			if(null == pvcHandler || pvcHandler(sender, e))
				butnFinish.Enabled = butnAdd.Enabled = true;
		}

		private void CreateObjDlg_Load(object sender, System.EventArgs e)
		{
			PropGrid.Focus();
		}

		public event EventHandler ContinueCreate;
		public event EventHandler Finish;
		public event EventHandler Cancel;
	}
	public delegate bool PropertyValueChanged(object sender, PropertyValueChangedEventArgs e);

}
