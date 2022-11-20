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
using System.Diagnostics;
using InvoiceManager.pages;

namespace InvoiceManager
{
	public partial class Form1 : Form
	{
		SideMenu m_Menu = new SideMenu();
		Panel m_BackgroundPanel = new Panel();
		Page m_Page;

		public Form1()
		{
			InitializeComponent();

			m_Menu.Width = (ClientSize.Width / 5) > 256 ? 256 : ClientSize.Width / 5;
			m_Menu.Height = ClientSize.Height;
			m_Menu.Location = new Point(0, 0);
			m_Menu.AddTab("Expenses", Expenses_OnClick);
			m_Menu.AddTab("Invoicing", Invoicing_OnClick);
			m_Menu.AddTab("Budgeting", Budgeting_OnClick);
			m_Menu.AddTab("Customers", Customers_OnClick);
			Controls.Add(m_Menu);

			
			Controls.Add(m_BackgroundPanel);
			m_BackgroundPanel.Width = ClientSize.Width - m_Menu.Width;
			m_BackgroundPanel.Height = ClientSize.Height;
			m_BackgroundPanel.Location = new Point(m_Menu.Width, 0);

			Resize += Form1_Resize;
		}

		private void Customers_OnClick(object sender, EventArgs e)
		{
			m_BackgroundPanel.Controls.Clear();
			m_Page = new CustomersPage(m_BackgroundPanel);
			//m_Page.UpdateControls();
		}

		private void Budgeting_OnClick(object sender, EventArgs e)
		{
			m_BackgroundPanel.Controls.Clear();
			//new BudgetingPage().Draw(m_Page);
		}

		private void Invoicing_OnClick(object sender, EventArgs e)
		{
			m_BackgroundPanel.Controls.Clear();
			//new InvoicingPage().Draw(m_Page);
		}

		private void Expenses_OnClick(object sender, EventArgs e)
		{
			m_BackgroundPanel.Controls.Clear();
			//new ExpensesPage().Draw(m_Page);
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			m_Menu.Width = (Width / 5) > 256 ? 256 : Width / 5;
			m_Menu.Height = ClientSize.Height;

			m_BackgroundPanel.Width = ClientSize.Width - m_Menu.Width;
			m_BackgroundPanel.Height = ClientSize.Height;
			m_BackgroundPanel.Location = new Point(m_Menu.Width, 0);
			//Controls.
		}
	}
}
