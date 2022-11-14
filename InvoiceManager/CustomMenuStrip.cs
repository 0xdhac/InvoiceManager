using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace InvoiceManager
{
	class SideMenu : Panel
	{
		private List<Tab> m_Tabs = new List<Tab>();

		public SideMenu()
		{
			BackColor = SystemColors.ControlDark;
			Resize += SideMenu_Resize;
		}

		private void SideMenu_Resize(object sender, EventArgs e)
		{
			foreach(Tab t in m_Tabs)
			{
				t.Width = Width;
			}
		}

		public void AddTab(string name)
		{
			Tab t = new Tab(this, name);
			t.Location = new Point(0, m_Tabs.Count * Tab.TabHeight);
			m_Tabs.Add(t);
		}
	}

	class Tab : Label
	{
		public const int TabHeight = 48;
		public const int FontSize = 14;
		public const string FontFamily = "Segoe UI";

		public Tab(Control parent, string name)
		{
			parent.Controls.Add(this);
			TextAlign = ContentAlignment.MiddleRight;
			Text = name;
			Height = TabHeight;
			Width = Parent.Width;
			MouseMove += Tab_MouseMove;
			MouseLeave += Tab_MouseLeave;
			MouseEnter += Tab_MouseEnter;
			Font = new Font(FontFamily, FontSize);
		}

		private void Tab_MouseEnter(object sender, EventArgs e)
		{
			ForeColor = SystemColors.ControlLight;
		}

		private void Tab_MouseLeave(object sender, EventArgs e)
		{
			ForeColor = SystemColors.ControlText;
		}

		private Rectangle ImageArea(Control c)
		{
			Size si = c.Size;
			Size sp = c.ClientSize;
			float ri = 1f * si.Width / si.Height;
			float rp = 1f * sp.Width / sp.Height;
			if (rp > ri)
			{
				int width = si.Width * sp.Height / si.Height;
				int left = (sp.Width - width) / 2;
				return new Rectangle(left, 0, width, sp.Height);
			}
			else
			{
				int height = si.Height * sp.Width / si.Width;
				int top = (sp.Height - height) / 2;
				return new Rectangle(0, top, sp.Width, height);
			}
		}

		private void Tab_MouseMove(object sender, MouseEventArgs e)
		{
			Cursor = ImageArea(this).Contains(e.Location) ? Cursors.Hand : Cursors.Default;
		}
	}
}
