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
		public DirectoryLeaf m_TopLevel;

		public DirectoryTree(string name)
		{
			m_TopLevel = new DirectoryLeaf(null, "Head");
		}

		public DirectoryLeaf AddDirectory(string parent, string name)
		{
			if(parent is null)
			{
				DirectoryLeaf d = new DirectoryLeaf(null, name);
				m_TopLevel.Add(d);
				return d;
			}
			else
			{
				string[] tree = parent.Split('\\');
				DirectoryLeaf currentDir = m_TopLevel;
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

				DirectoryLeaf d = new DirectoryLeaf(currentDir, name);
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

		public override string ToString()
		{
			return m_TopLevel.ToString();
		}
	}

	public class DirectoryLeaf
	{
		public string Name;
		public DirectoryLeaf Parent;
		public List<DirectoryLeaf> Children = new List<DirectoryLeaf>();

		public DirectoryLeaf(DirectoryLeaf parent, string name)
		{
			Parent = parent;
			Name = name;
		}

		public void Add(DirectoryLeaf directory)
		{
			Children.Add(directory);
		}

		public List<DirectoryLeaf> GetPath()
		{
			List<DirectoryLeaf> path = new List<DirectoryLeaf>() { this };
			DirectoryLeaf current = this;

			while(current.Parent != null)
			{
				current = current.Parent;
				path.Add(current);
			}
			
			return path;
		}

		public DirectoryLeaf this[string key]
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
		}

		private void BuildString(DirectoryLeaf directory, ref string main, int level)
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
