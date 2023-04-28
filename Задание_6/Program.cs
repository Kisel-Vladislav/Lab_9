using System;
using System.Collections.Generic;

namespace Задание_6
{
    public class BinaryTree
    {
        public BinaryTree(string[] nameTeam)
        {
            BinaryTreeCreate(parent, nameTeam.Length);
            List<TreeNode> list = new List<TreeNode>();
            SetList(parent, list);

            for (int i = 0; i + 1 < list.Count; i++)
            {
                for (int j = 0; j < nameTeam.Length; j++)
                {
                    list[i].team1 = nameTeam[j++];
                    list[i].team2 = nameTeam[j];
                    i++;
                }
                break;
            }
        }
        private class TreeNode
        {
            public TreeNode(string nameTeam1 = null, string nameTeam2 = null)
            {
                team1 = nameTeam1;
                team2 = nameTeam2;
            }

            public string team1, team2;
            public int? scoreTeam1, scoreTeam2;
            public TreeNode left, rigth;
        }
        private TreeNode parent = new TreeNode();

        private void BinaryTreeCreate(TreeNode parent, int countyeam, int i = 0)
        {
            if (i > countyeam - 1)
                return;

            parent.left = new TreeNode();
            BinaryTreeCreate(parent.left, countyeam / 2, i + 1);

            parent.rigth = new TreeNode();
            BinaryTreeCreate(parent.rigth, countyeam / 2, i + 1);
        }
        private List<TreeNode> SetList(TreeNode node, List<TreeNode> treeNodes)//, string[] nameTeam, int i = 0, int nomNameTeam = 0)
        {
            if (node == null)
                return null;

            SetList(node.left, treeNodes);//, nameTeam, i, nomNameTeam);
            SetList(node.rigth, treeNodes);//, nameTeam, i, nomNameTeam);

            if (node.left == null)
            {
                treeNodes.Add(node);
                //node.team1 = "1";
                //node.team2 = "2";
            }
            return treeNodes;
        }
        private void Result(TreeNode node, Random r)
        {
            if (node == null)
                return;

            Result(node.left, r);
            Result(node.rigth, r);

            node.scoreTeam1 = r.Next(11);
            node.scoreTeam2 = r.Next(11);

            if (node.left == null)
                return;

            if (node.left.scoreTeam1 >= node.left.scoreTeam2)
            {
                node.team1 = node.left.team1;
            }
            else
            {
                node.team1 = node.left.team2;
            }

            if (node.rigth.scoreTeam1 >= node.rigth.scoreTeam2)
            {
                node.team2 = node.rigth.team1;
            }
            else
            {
                node.team2 = node.rigth.team2;
            }
        }
        public void GenerateResults()
        {
            Random r = new Random();
            Result(parent, r);
        }
        public void BFS()
        {
            List<string[]> strings = new List<string[]>();
            Print(parent, strings);

            int j = 0;
            for (int k = 0; k < strings.Count; k++)
            {
                if (k == 1 || k == 8)
                    j = 5;
                else if (k == 2 || k == 5 || k == 9 || k == 12)
                    j = 10;
                else if (k == 3 || k == 6 || k == 10 || k == 13)
                    j = 15;

                for (int i = 0; i < j; i++)
                    Console.Write(' ');
                for (int i = 0; i < strings[k].Length; i++)
                {
                    Console.WriteLine(@"{0,-1} - {1,-1} : {2,-2} - {3,-2}", strings[k][i++], strings[k][i++], strings[k][i++], strings[k][i]);
                }
            }

        }
        private List<string[]> Print(TreeNode parent, List<string[]> strings)
        {
            if (parent == null)
                return null;

            strings.Add(new string[] { parent.team1, parent.team2, parent.scoreTeam1.ToString(), parent.scoreTeam2.ToString() });
            //Console.WriteLine(@"{0,-1} - {1,-1} : {2,-2} - {3,-2}", parent.team1, parent.team2, parent.scoreTeam1, parent.scoreTeam2);
            Print(parent.left, strings);
            Print(parent.rigth, strings);

            return strings;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] name = { "Team1", "Team2", "Team3", "Team4", "Team5", "Team6", "Team7", "Team8",
                                  "Team9", "Team10", "Team11", "Team12", "Team13", "Team14", "Team15", "Team16"};
            BinaryTree binaryTree = new BinaryTree(name);
            binaryTree.GenerateResults();
            binaryTree.BFS();
        }
    }
}
