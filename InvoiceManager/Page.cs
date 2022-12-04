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
	public class Page
	{
		public static void AddPath()
		{

		}
	}

	public class DirectoryTree
	{
		static readonly int TOP_LEVEL = 0;

		Directory m_TopLevel = new Directory(null, "TOP_LEVEL");

		public DirectoryTree()
		{

		}

		public void AddDirectory(string parent, string name)
		{
			if(parent is null)
			{
				m_TopLevel.Add(new Directory(null, name));
			}
			else
			{

			}
		}

		/*
		Directory FindDirectory(string directory, Directory main)
		{
			foreach(Directory d in main.Children)
			{
				if (d.Name == directory)
					return d;
			}

			
		}
		*/
	}

	public class Directory
	{
		public string Name;
		public Directory Parent;
		public List<Directory> Children = new List<Directory>();

		public Directory(Directory parent, string name)
		{
			Parent = parent;
			Name = name;
		}

		public void Add(Directory directory)
		{
			Children.Add(directory);
		}
	}
}
