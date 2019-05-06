using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BinarySearchTreeCheckerTests")]
namespace BinarySearchTreeChecker.Models
{
    internal class BinaryTree
    {
                 
            public Node root;

            /* can give min and max value according to your code or  
            can write a function to find min and max value of tree. */

            /* returns true if given search tree is binary  
             search tree (efficient version) */
            public virtual bool BST
            {
                get
                {
                    return IsBstUtil(root, int.MinValue, int.MaxValue);
                }
            }

            /* Returns true if the given tree is a BST and its  
              values are >= min and <= max. */
            public virtual bool IsBstUtil(Node node, int min, int max)
            {
                /* an empty tree is BST */
                if (node == null)
                {
                    return true;
                }

                /* false if this node violates the min/max constraints */
                if (node.data < min || node.data > max)
                {
                    return false;
                }

                /* otherwise check the subtrees recursively  
                tightening the min/max constraints */
                // Allow only distinct values  
                return (IsBstUtil(node.left, min, node.data - 1) && IsBstUtil(node.right, node.data + 1, max));
            }
    }
    
}
