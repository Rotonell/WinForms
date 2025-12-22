using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			this.MaximizeBox = false;
			this.MinimizeBox = false;
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

			SetVisibility(false);
		}

		private void labelTime_MouseHover(object sender, EventArgs e)
		{
			//cbShowWeekDay.Visible = true;
			//cbShowDate.Visible = true;
			//btnHideControls.Visible = true;
			//this.ShowInTaskbar = true;
			//this.FormBorderStyle = FormBorderStyle.FixedSingle;
			//this.TransparencyKey = Color.Empty;

			SetVisibility(true);
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			this.TopMost = true;
			this.TopMost = false;
		}

		private void tsmiShowWeekday_Click(object sender, EventArgs e)
		{

		}
	}
}
