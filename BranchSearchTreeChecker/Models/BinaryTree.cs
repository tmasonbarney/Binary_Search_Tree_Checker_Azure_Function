using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BinarySearchTreeCheckerTests")]
namespace BinarySearchTreeChecker.Models
{
    internal class BinaryTree
    {
                 
        public Node root;

        public virtual TreeInfo Info
        {
            get
            {
                return new TreeInfo()
                {
                    Size = Size(root),
                    Depth = MaxDepth(root),
                    BinarySearchTree = IsBstUtil(root, int.MinValue, int.MaxValue)
                };
            }
        }

        public virtual int Size(Node node)
        {
            if (node == null) return 0;

            return (Size(node.left) + 1 + Size(node.right));
        }

        public virtual int MaxDepth(Node node)
        {
            if (node == null) return 0;


            int leftDepth = MaxDepth(node.left);
            int rightDepth = MaxDepth(node.right);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }
            
     
        public virtual bool IsBstUtil(Node node, int min, int max)
        {
            
            if (node == null)
            {
                return true;
            }

            if (node.data < min || node.data > max)
            {
                return false;
            }

        
            return (IsBstUtil(node.left, min, node.data - 1) && IsBstUtil(node.right, node.data + 1, max));
        }
    }
    
}
