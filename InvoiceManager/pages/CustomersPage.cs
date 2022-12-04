using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace InvoiceManager.pages
{
	class CustomersPage : Page
	{
		ListView m_Customers = new ListView();
		Button m_AddButton = new Button();
		Button m_RemoveButton = new Button();
		Button m_ModifyButton = new Button();
		Panel m_Parent = null;
		const int WidthFraction = 20;
		const int HeightFraction = 15;

		public CustomersPage(Panel parent)
		{
			m_Parent = parent;

			m_Parent.Resize += Parent_Resize;
			Draw();
			UpdateControls();
		}

		private void Parent_Resize(object sender, EventArgs e)
		{
			UpdateControls();
		}

		// Main page lists customers
		// Secondary page lets you add customers
		public void Draw()
		{
			m_Parent.Controls.Add(m_Customers);
			// Large scrollable box with list of customers

			// Buttons to delete, add, or modify a customer
			// Button to show customer profile
		}

		public void UpdateControls()
		{
			m_Customers.Location = new Point(m_Parent.Width / WidthFraction, m_Parent.Height / HeightFraction + 64);
			m_Customers.Height = (int)((float)m_Parent.Height * (float)((HeightFraction - 2) / (float)HeightFraction) - 64);
			m_Customers.Width = (int)((float)m_Parent.Width * (float)((WidthFraction - 2) / (float)WidthFraction));
		}
	}
}
