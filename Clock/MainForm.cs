using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		FontDialog FontDialog = new FontDialog();
		ColorDialog colorDialodForeground = new ColorDialog();
		ColorDialog colorDialodBackground = new ColorDialog();
		public MainForm()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point
				(
				Screen.PrimaryScreen.Bounds.Width - 250,
				50
				);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			SetVisibility(false);
			this.TopMost = tsmiTopmost.Checked = true;
		}

		void SetVisibility(bool visible)
		{
			cbShowWeekDay.Visible = visible;
			cbShowDate.Visible = visible;
			btnHideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedSingle : FormBorderStyle.None;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			labelTime.Text=DateTime.Now.ToString
				(
				"hh:mm:ss tt",
				System.Globalization.CultureInfo.InvariantCulture
				);

			if (cbShowDate.Checked)
			{
				labelTime.Text+= "\n";
				labelTime.Text+=DateTime.Now.ToString("yyyy.MM.dd");
			}

			if (cbShowWeekDay.Checked) labelTime.Text+= $"\n{DateTime.Now.DayOfWeek}";

			notifyIcon.Text = labelTime.Text;
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			//cbShowWeekDay.Visible = false;
			//cbShowDate.Visible = false;
			//btnHideControls.Visible = false;
			//this.ShowInTaskbar = false;
			//this.FormBorderStyle = FormBorderStyle.None;
			//this.TransparencyKey = this.BackColor;

			SetVisibility(tsmiShowControls.Checked = false);
		}

		//private void labelTime_MouseHover(object sender, EventArgs e)
		//{
		//	//cbShowWeekDay.Visible = true;
		//	//cbShowDate.Visible = true;
		//	//btnHideControls.Visible = true;
		//	//this.ShowInTaskbar = true;
		//	//this.FormBorderStyle = FormBorderStyle.FixedSingle;
		//	//this.TransparencyKey = Color.Empty;

		//	SetVisibility(true);
		//}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			this.TopMost = true;
			this.TopMost = false;
		}

		private void tsmiShowWeekday_Click(object sender, EventArgs e)
		{

		}

		private void tsmiTopmost_Click(object sender, EventArgs e)
		{
			this.TopMost = tsmiTopmost.Checked;
		}

		private void tsmiShowControls_CheckedChanged(object sender, EventArgs e)
		{
			SetVisibility((sender as ToolStripMenuItem).Checked);

		}

		private void tsmiShowDate_CheckedChanged(object sender, EventArgs e)
		{
			cbShowDate.Checked = tsmiShowDate.Checked;
		}

		private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) => 
			cbShowWeekDay.Checked = tsmiShowWeekday.Checked;

		private void cbShowWeekDay_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowWeekday.Checked = cbShowWeekDay.Checked;

		private void tsmiQuit_Click(object sender, EventArgs e) => this.Close();

		private void tsmiForegroundColor_Click(object sender, EventArgs e)
		{
			if (colorDialodForeground.ShowDialog() == DialogResult.OK)
			{
				labelTime.ForeColor = colorDialodForeground.Color;
			}
		}

		private void tsmiBackgroundColor_Click(object sender, EventArgs e)
		{
			if (colorDialodBackground.ShowDialog() == DialogResult.OK)
			{
				labelTime.BackColor = colorDialodBackground.Color;
			}
		}

		private void tsmiFont_Click(object sender, EventArgs e)
		{
			FontDialog.Location = new Point
				(
				this.Location.X - FontDialog.Width - 10,
				this.Location.Y
				);
			FontDialog.Font = labelTime.Font;
			DialogResult result = FontDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				labelTime.Font = FontDialog.Font;
			}
		}
	}
}
