using Bruhuhuhu;

Matrix<int> matrix = new Matrix<int>(5,4);
matrix.Fill(123);
Console.WriteLine("Original\n");
Console.WriteLine(matrix.ToString());

// RotateX 
matrix.RotateX();
Console.WriteLine("X rotate of the elements\n");
Console.WriteLine(matrix.ToString());

// RotateY 
matrix.RotateY();
Console.WriteLine("Y rotate of the elements\n");
Console.WriteLine(matrix.ToString());