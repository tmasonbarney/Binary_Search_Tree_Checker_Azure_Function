
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using BinarySearchTreeChecker.Models;
using Xunit;

namespace BinarySearchTreeCheckerTests
{
    public class FunctionsTests
    {
        private readonly ILogger _logger = TestFactory.CreateLogger();

        [Fact]
        public async System.Threading.Tasks.Task Http_trigger_should_return_BinarySearchTree_false()
        {

            //Arrange
            var tree = new BinaryTree();
            tree.root = new Node(4);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);
            tree.root.left.left = new Node(7);
            tree.root.left.right = new Node(3);


            var request = TestFactory.CreateHttpRequest(tree);

            //Act
            var response = (OkObjectResult)await BinarySearchTreeChecker.BinarySearchTreeChecker.Run(request, _logger);

            var info = (TreeInfo)response.Value;

            //Assert
            Assert.False(info.BinarySearchTree);
        }

        [Fact]
        public async System.Threading.Tasks.Task Http_trigger_should_Depth_3()
        {

            //Arrange
            var tree = new BinaryTree();
            tree.root = new Node(4);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);
            tree.root.left.left = new Node(7);
            tree.root.left.right = new Node(3);


            var request = TestFactory.CreateHttpRequest(tree);

            //Act
            var response = (OkObjectResult)await BinarySearchTreeChecker.BinarySearchTreeChecker.Run(request, _logger);

            var info = (TreeInfo)response.Value;

            //Assert
            Assert.Equal(3, info.Depth);
       
        }

        [Fact]
        public async System.Threading.Tasks.Task Http_trigger_should_return_Size_5()
        {

            //Arrange
            var tree = new BinaryTree();
            tree.root = new Node(4);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);
            tree.root.left.left = new Node(7);
            tree.root.left.right = new Node(3);


            var request = TestFactory.CreateHttpRequest(tree);

            //Act
            var response = (OkObjectResult)await BinarySearchTreeChecker.BinarySearchTreeChecker.Run(request, _logger);

            var info = (TreeInfo)response.Value;

            //Assert
            Assert.Equal(5, info.Size);

        }

        [Fact]
        public async void Http_trigger_should_return_BinarySearchTree_true()
        {
            //Arrange
            var tree = new BinaryTree();
            tree.root = new Node(4);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);

            var request = TestFactory.CreateHttpRequest(tree);

            //Act
            var response = (OkObjectResult)await BinarySearchTreeChecker.BinarySearchTreeChecker.Run(request, _logger);

            var info = (TreeInfo)response.Value;

            //Assert
            Assert.True(info.BinarySearchTree);
        }
    }
}
