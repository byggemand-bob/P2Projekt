﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Game.AI.GameTree {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            
            
        }

        private void ConvertToTreeNode(TreeNode tn, Node n) {
            if(n.Children.Count != 0) {
                for(int i = 0; i < n.Children.Count; i++) {
                    tn.Nodes.Add(NodeToTreeNode(n.Children[i]));
                    ConvertToTreeNode(tn.Nodes[i], n.Children[i]);
                }
            }
        }

        private TreeNode NodeToTreeNode(Node node) {
            return new TreeNode(node.Action);
        }

        private void Button1_Click(object sender, EventArgs e) {
            List<Tuple<string, double>> pathInfo = TextToPathInfo(textBox1.Lines);


            TreeNode rootTreeNode = new TreeNode("Root");
            ConvertToTreeNode(rootTreeNode, CreateTree(pathInfo));
            treeView3.Nodes.Add(rootTreeNode);

        }

        private List<Tuple<string, double>> TextToPathInfo(string[] textBoxStrings) {
            List<Tuple<string, double>> result = new List<Tuple<string, double>>();
            foreach(string line in textBoxStrings) {
                string[] tempStrings = line.Split(',');
                result.Add(new Tuple<string, double>(tempStrings[0], double.Parse(tempStrings[1])));
            }

            return result;
        }

        private Node CreateTree(List<Tuple<string, double>> pathInfo) {
            Node rootNode = new Node(null, "Root");
            PathConstructor ph = new PathConstructor();
            foreach(Tuple<string, double> path in pathInfo) {
                ph.ConstructPath(rootNode, path.Item1, path.Item2);
            }

            return rootNode;
        }

    }
}
