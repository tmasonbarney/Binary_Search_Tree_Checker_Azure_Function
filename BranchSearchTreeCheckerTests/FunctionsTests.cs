
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
        public async System.Threading.Tasks.Task Http_trigger_should_return_is_not_search_treeAsync()
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

            //Assert
            Assert.Equal("Unfortunately its not a Branch Search Tree!", response.Value);
        }

        [Fact]
        public async void Http_trigger_should_return_is_search_tree()
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

            //Assert
            Assert.Equal("It is a Branch Search Tree!", response.Value);
        }
    }
}
