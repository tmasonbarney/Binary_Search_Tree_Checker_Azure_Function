using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("BinarySearchTreeCheckerTests")]
namespace BinarySearchTreeChecker.Models
{
    internal class TreeInfo
    {
        public int Size { get; set; }
        public int Depth { get; set; }
        public bool BinarySearchTree { get; set; }
    }
}

