using System;
using System.Linq;

namespace Maximal_Square
{
  class Program
  {
    static void Main(string[] args)
    {
      /// [["1","1","1","1","0"],["1","1","1","1","0"],["1","1","1","1","1"],["1","1","1","1","1"],["0","0","1","1","1"]]
      //char[][] matrix = new char[4][] { new char[] { '1', '0', '1', '0', '0' },
      //  new char[] { '1', '0', '1', '1', '1' }, new char[] { '1', '1', '1', '1', '1' }, new char[] { '1', '0', '0', '1', '0' } };
      char[][] matrix = new char[2][] { new char[] { '0', '1' }, new char[] { '1', '0' } };
      Solution s = new Solution();
      var answer = s.MaximalSquare(matrix);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int MaximalSquare(char[][] matrix)
    {
      int row = matrix.Length;
      int column = matrix[0].Length;
      int max = 0;

      int[][] dp = new int[row][];
      for (int i = row - 1; i >= 0; i--)
      {
        dp[i] = new int[column];
        for (int j = column - 1; j >= 0; j--)
        {
          if (i == row - 1 || j == column - 1)
          {
            dp[i][j] = matrix[i][j] - '0';
          }
          else if (matrix[i][j] == '1')
          {
            int right = dp[i][j + 1];
            int down = dp[i + 1][j];
            int diagonal = dp[i + 1][j + 1];
            int newValue = (new int[] { right, down, diagonal }).Min() + 1;
            dp[i][j] = newValue;
          }

          max = Math.Max(max, dp[i][j]);
        }
      }
      return max * max;
    }
  }
}
