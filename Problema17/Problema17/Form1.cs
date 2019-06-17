using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Problema17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(textBox1.Text);
        }

        private void ToXML_Click(object sender, EventArgs e)
        {
            XmlWriter xmlWriter = XmlWriter.Create("res.xml");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("treeView");
            foreach (var node in treeView1.Nodes)
            {
                try
                {
                    xmlWriter.WriteStartElement("element");
                    xmlWriter.WriteString(node.ToString());
                    xmlWriter.WriteEndElement();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            xmlWriter.WriteEndDocument();
            try
            {
                xmlWriter.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
