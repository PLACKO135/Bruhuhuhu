using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruhuhuhu
{
    public class Matrix<T>
    {
        private T[,] data;
        private int rows;
        private int columns;

        public Matrix(int m, int n)
        {
            rows = m; 
            columns = n; 
            data = new T[m, n]; 
        }
        public Matrix(int n) : this(n, n)
        {
        }

        public Matrix() : this(3, 3)
        {
        }

        public override string ToString()
        {
            string result = ""; // Initialize an empty result string
            for (int i = 0; i < rows; i++)
            {
                result += "| "; // Start a new row with a pipe character
                for (int j = 0; j < columns; j++)
                {
                    result += $"{data[i, j]} "; // Add the element to the result
                    if (j < columns - 1)
                        result += ", "; // Add a comma if it's not the last element in the row
                }
                result += "|\n"; // End the row with a pipe character and a newline
            }
            return result; // Return the constructed string representation of the matrix
        }

        // Method to get the size of the matrix as a tuple (rows, columns)
        public (int rows, int columns) Size()
        {
            return (rows, columns); // Return the number of rows and columns
        }

        // Static method to add two matrices A and B
        public static Matrix<object> Plus(Matrix<object> A, Matrix<object> B)
        {
            // Check if the dimensions of both matrices are the same
            if (A.rows != B.rows || A.columns != B.columns)
                throw new ArgumentException("The two matrix's size aren't equal");

            // Create a new matrix to store the result
            Matrix<object> result = new Matrix<object>(A.rows, A.columns);

            for (int i = 0; i < A.rows; i++)
            {
                for (int j = 0; j < A.columns; j++)
                {
                    // Use the Add method to perform addition
                    result.data[i, j] = Add(A.data[i, j], B.data[i, j]);
                }
            }

            return result; // Return the resulting matrix
        }

        // A helper method to perform addition for specific types
        private static object Add(object a, object b)
        {
            // Check the types of a and b and perform addition accordingly
            if (a is int intA && b is int intB)
            {
                return intA + intB;
            }
            else if (a is double doubleA && b is double doubleB)
            {
                return doubleA + doubleB;
            }
            else if (a is float floatA && b is float floatB)
            {
                return floatA + floatB;
            }
            // Add more types as necessary
            else
            {
                throw new InvalidOperationException($"Addition not supported for types {a.GetType()} and {b.GetType()}.");
            }
        }

        // Method to fill the matrix with a specified element
        public void Fill(T element)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = element; // Set each element of the matrix to the specified value
                }
            }
        }

        // Method to rotate the matrix around the X-axis (flip vertically)
        public void RotateX()
        {
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Swap elements symmetrically across the X-axis
                    T temp = data[i, j];
                    data[i, j] = data[rows - 1 - i, j];
                    data[rows - 1 - i, j] = temp;
                }
            }
        }

        // Method to rotate the matrix around the Y-axis (flip horizontally)
        public void RotateY()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns / 2; j++)
                {
                    // Swap elements symmetrically across the Y-axis
                    T temp = data[i, j];
                    data[i, j] = data[i, columns - 1 - j];
                    data[i, columns - 1 - j] = temp;
                }
            }
        }
    }
}