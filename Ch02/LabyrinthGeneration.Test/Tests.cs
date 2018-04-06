using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LabyrinthGeneration.Test
{
    [TestFixture]
    public class LabyrinthGeneration
    {
        [Test]
        public void Generate_FiveNodes_Success()
        {
            var labyrinth = new LabyrinthGeneration<string>(new string[] {"A", "B", "C", "D", "E"});
            var visitedNodes = labyrinth.Generate();

            Assert.AreEqual(visitedNodes.Count(), new HashSet<string>(visitedNodes).Count);
        }
        
        [Test]
        public void Generate_FifteenNodes_Success()
        {
            var labyrinth = new LabyrinthGeneration<string>(new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O"});
            var visitedNodes = labyrinth.Generate();

            Assert.AreEqual(visitedNodes.Count(), new HashSet<string>(visitedNodes).Count);
        }
    }
}