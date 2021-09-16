using System;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    class LinkedList {

        public Node Head { get; set; }


        public LinkedList() {
            Head = new Node();
        }

        //functions needed
        // insert order
        // clear

        /// <summary>
        /// 
        ///     Insert Order
        ///     
        ///     Inserts tiles in order by which they are played on the board
        ///     IE: from left to right, top to bottom
        /// 
        /// </summary>
        /// <param name="tile"> Tile of play </param>
        /// <param name="row"> Row of Play </param>
        /// <param name="col"> Col of Play </param>
        /// <returns> 
        /// 
        ///     True if the tile is allowed to be inserted
        ///     False if it is not within row or col
        ///     
        /// </returns>
        public bool insertOrder(Tile tile, int row, int col) {
            Node newNode = new Node(tile, row, col);
            // if head.next is null then the list is empty
            if(Head.next == null) {
                Head.next = newNode;
                newNode.prev = Head;
                return true;
            }
            else {
                // temp used to iterate
                for(Node temp = Head; temp.next != null; temp = temp.next) {
                    if(row < temp.next.row && col == temp.next.col || row == temp.next.row && col < temp.next.col) {
                        newNode.next = temp.next;
                        newNode.prev = temp.next.prev;
                        newNode.next.prev = newNode;
                        newNode.prev.next = newNode;
                        return true;
                    }
                }

                return insertLast(tile, row, col);


            }

        }

        /// <summary>
        /// 
        ///     Insert Last
        ///     
        ///     Called by Insert Order
        ///     Only called when tile is inserted at the end of list
        ///     
        ///     IE: furthest right or down cell on grid
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="tile">  Tile Data </param>
        /// <param name="row"> Row of play </param>
        /// <param name="col"> Col of play </param>
        /// <returns> 
        /// 
        ///     True if the tile is allowed to be inserted
        ///     False if it is not within row or col
        ///     
        /// </returns>
        public bool insertLast(Tile tile, int row, int col) {
            Node newNode = new Node(tile, row, col);
            // if head.next is null then the list is empty
            if (Head.next == null) {
                Head.next = newNode;
                newNode.prev = Head;
                return true;
            }
            else {
                Node current = new Node();
                current.next = Head.next;
                while(current.next.next != null) {
                    current = current.next;
                }
                if(current.next.row < row && current.next.col == col || current.next.row == row && current.next.col < col) {
                    current.next.next = newNode;
                    newNode.prev = current.next;
                    newNode.next = null;
                    return true;
                }
                return false;
            }
        }

        public string toWord() {
            string LL = "";
            for (Node test = Head.next; test != null; test = test.next) {
                LL += test.data;
            }
            return LL;
        }


        // Helper obj for LL
        // LL is comprised of Nodes
        public class Node {
            public Node next { get; set; }
            public Node prev { get; set; }
            public Tile data { get; set; }
            public int row { get; set; }
            public int col { get; set; }

            public Node() {
                next = null;
                prev = null;
                row = -1;
                col = -1;
            }

            public Node(Tile data, int row, int col) {
                this.data = data;
                this.row = row;
                this.col = col;
            }
           
        }


        // Testing purposes, shows LL
        public override string ToString() {

            string LL = "head -> ";
            for(Node test = Head.next; test != null; test = test.next) {
                LL += test.data + " -> ";
            }
            return LL;
        }

    }
}
