using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager
{
	public partial class PathLabel : Panel
	{
		private string Delimiter = " >> ";
		RichTextBox m_Label = new RichTextBox();
		public PathLabel()
		{
			InitializeComponent();
			Width = 400;
			m_Label.Width = 400;
			m_Label.ReadOnly = true;
			m_Label.BorderStyle = BorderStyle.None;
			m_Label.Enter += M_Label_Enter;
			m_Label.MouseMove += M_Label_MouseMove;
			m_Label.MouseHover += M_Label_MouseHover;
			//m_Label.
			//m_Label.Foc
		}

		private void M_Label_MouseHover(object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
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

		private void M_Label_MouseMove(object sender, MouseEventArgs e)
		{
			Cursor = Cursors.Default;
		}

		private void M_Label_Enter(object sender, EventArgs e)
		{
			Focus();
		}

		public void Update(DirectoryLeaf path)
		{
			Controls.Clear();
			List<DirectoryLeaf> p = path.GetPath();


			m_Label.AutoSize = true;
			//l.Location = new Point(60, 10);

			var defaultColor = m_Label.SelectionColor;
			for(int leaf = p.Count - 1; leaf >= 0; leaf--)
			{
				m_Label.SelectionColor = defaultColor;
				m_Label.AppendText(p[leaf].Name);
				m_Label.SelectionColor = Color.FromArgb(128, 128, 128);

				if(leaf != 0)
					m_Label.AppendText(Delimiter);
			}

			Controls.Add(m_Label);
		}

		private void L_TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
