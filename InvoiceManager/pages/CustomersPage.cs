﻿using System;
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
		public override void Draw()
		{
			m_Parent.Controls.Add(m_Customers);
			// Large scrollable box with list of customers

			// Buttons to delete, add, or modify a customer
			// Button to show customer profile
		}

		public override void UpdateControls()
		{
			m_Customers.Location = new Point(m_Parent.Width / WidthFraction, m_Parent.Height / HeightFraction);
			m_Customers.Height = (int)((float)m_Parent.Height * (float)((HeightFraction - 2) / (float)HeightFraction));
			m_Customers.Width = (int)((float)m_Parent.Width * (float)((WidthFraction - 2) / (float)WidthFraction));
		}
	}
}