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

		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			cbShowWeekDay.Visible = false;
			cbShowDate.Visible = false;
			btnHideControls.Visible = false;
			this.ShowInTaskbar = false;
		}
	}
}
