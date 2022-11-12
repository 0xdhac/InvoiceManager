using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InvoiceManager
{
	public partial class Form1 : Form
	{
		SideMenu m_Menu = new SideMenu();

		public Form1()
		{
			InitializeComponent();

			m_Menu.Width = (Width / 5) > 256 ? 256 : Width / 5;
			m_Menu.Height = Height;
			m_Menu.Location = new Point(0, 0);
			m_Menu.AddTab("Expenses");
			m_Menu.AddTab("Invoicing");
			m_Menu.AddTab("Budgeting");
			Controls.Add(m_Menu);

			Resize += Form1_Resize;
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			m_Menu.Width = (Width / 5) > 256 ? 256 : Width / 5;
			m_Menu.Height = Height;
		}
	}
}
