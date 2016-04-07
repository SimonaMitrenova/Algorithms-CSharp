namespace ConnectedAreasInAMatrix
{
    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        public override string ToString()
        {
            return string.Format($"({this.Row}, {this.Col})");
        }
    }
}
