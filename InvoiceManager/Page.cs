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

		public Directory m_TopLevel = new Directory(null, "TOP_LEVEL");

		public DirectoryTree()
		{

		}

		public Directory AddDirectory(string parent, string name)
		{
			if(parent is null)
			{
				Directory d = new Directory(null, name);
				m_TopLevel.Add(d);
				return d;
			}
			else
			{
				string[] tree = parent.Split('\\');
				Directory currentDir = m_TopLevel;
				foreach(var dir in tree)
				{
					if(currentDir[dir] != null)
					{
						currentDir = currentDir[dir];
					}
					else
					{
						return null;
					}
				}

				Directory d = new Directory(currentDir, name);
				currentDir.Add(d);
				return d;
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

		public Directory this[string key]
		{
			get
			{
				foreach(var child in Children)
				{
					if (child.Name == key)
						return child;
				}

				return null;
			}
		}

		public override string ToString()
		{
			string main = "";
			int level = 0;
			BuildString(this, ref main, level);
			return main;
			// Recursive function that adds a name to a string with \n and then calls the same function on its children
		}

		private void BuildString(Directory directory, ref string main, int level)
		{
			for (int i = 0; i < level; i++)
				main += '\t';
			main += directory.Name + '\n';
			foreach(var child in directory.Children)
			{
				BuildString(child, ref main, level + 1);
			}
		}
	}
}
