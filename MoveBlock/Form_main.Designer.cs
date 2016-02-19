namespace MoveBlock {
	partial class Form_main {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
			this.pB = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
			this.SuspendLayout();
			// 
			// pB
			// 
			this.pB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pB.Location = new System.Drawing.Point(0, 0);
			this.pB.Name = "pB";
			this.pB.Size = new System.Drawing.Size(374, 273);
			this.pB.TabIndex = 0;
			this.pB.TabStop = false;
			// 
			// Form_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 273);
			this.Controls.Add(this.pB);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "Form_main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Block::Move";
			this.Load += new System.EventHandler(this.Form_main_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_main_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pB;


	}
}

