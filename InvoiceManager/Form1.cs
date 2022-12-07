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
			DirectoryTree tree = new DirectoryTree("Program");
			tree.AddDirectory(null, "Test1");
			tree.AddDirectory(null, "Test2");
			tree.AddDirectory(null, "Test3");
			tree.AddDirectory("Test1", "Leaf");
			tree.AddDirectory("Test1\\Leaf", "Leaf inside a leaf");
			var leaf = tree.AddDirectory("Test1\\Leaf\\Leaf inside a leaf", "Another leaf");

			Debug.Write(tree.ToString());
			/*
			 * Page.AddPath(Page.TOP_LEVEL, "Expenses")
			 * Page.AddPath(Page.TOP_LEVEL, "Customers")
			 * Page.AddPath(Page.TOP_LEVEL, "Budgeting")
			 * Page.AddPath(Page.TOP_LEVEL, "Invoicing")
			 * 
			 * Page.AddPath(Page.GetPath("Customers"), "New customer")
			 * Page.AddPath(Page.GetPath("Customers"), "Modify customer")
			 * Page.AddPath(Page.GetPath("Customers"), "Delete customer")
			 */
			InitializeComponent();

			m_Menu.Width = (ClientSize.Width / 5) > 256 ? 256 : ClientSize.Width / 5;
			m_Menu.Height = ClientSize.Height;
			m_Menu.Location = new Point(0, 0);
			Controls.Add(m_Menu);

			Controls.Add(m_BackgroundPanel);
			m_BackgroundPanel.Width = ClientSize.Width - m_Menu.Width;
			m_BackgroundPanel.Height = ClientSize.Height;
			m_BackgroundPanel.Location = new Point(m_Menu.Width, 0);
			PathLabel p = new PathLabel();
			p.Update(leaf);
			m_BackgroundPanel.Controls.Add(p);

			Resize += Form1_Resize;
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
