using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace ProblemDump.Uva
{
    public class Uva1
    {
        //10245 - The Closest Pair Problem
        //https://uva.onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=42&page=show_problem&problem=1186
        [Fact]
        public void ClosestPairTests()
        {
            //Infinity Test
            var inputBuilder = new StringBuilder();
            inputBuilder.AppendLine("0 2");
            inputBuilder.AppendLine("6 67");
            inputBuilder.AppendLine("43 71");
            inputBuilder.AppendLine("39 107");
            inputBuilder.AppendLine("189 140");

            ClosestPairSolution(new ProblemInput(inputBuilder)).Should().Be("36.2215");
        }

        private string ClosestPairSolution(ProblemInput input)
        {
            double closestDistanceBetweenPoints = 10000;
            int[] previousPointCoordinates = null;

            while (input.InputRemaining())
            {
                var xAndYCoordinates = input.GetInputLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                var xCoordinate = xAndYCoordinates[0];
                var yCoordinate = xAndYCoordinates[1];

                if (previousPointCoordinates != null)
                {
                    var xCoordinateDiff = xCoordinate - previousPointCoordinates[0];
                    var yCoordinateDiff = yCoordinate - previousPointCoordinates[1];

                    var distanceBetweenCurrentAndPreviousPoint =
                        Math.Round(Math.Sqrt(Math.Pow(xCoordinateDiff, 2) + Math.Pow(yCoordinateDiff, 2)), 4);

                    if (distanceBetweenCurrentAndPreviousPoint < closestDistanceBetweenPoints)
                        closestDistanceBetweenPoints = distanceBetweenCurrentAndPreviousPoint;
                }

                previousPointCoordinates = new[] {xCoordinate, yCoordinate};
            }

            return closestDistanceBetweenPoints >= 10000 ? "INFINITY" : closestDistanceBetweenPoints.ToString(CultureInfo.CurrentCulture);
        }              
    }
}
