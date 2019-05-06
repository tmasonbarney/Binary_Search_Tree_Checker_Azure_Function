using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BinarySearchTreeCheckerTests")]
namespace BinarySearchTreeChecker.Models
{
    internal class Node
    {
        public int data;
        public Node left, right;

        public Node(int value)
        {
            data = value;
            left = right = null;
        }
    }
}
