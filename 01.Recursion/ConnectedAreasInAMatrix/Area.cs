namespace ConnectedAreasInAMatrix
{
    using System;
    public class Area : IComparable<Area>
    {
        public Area(Cell startCell)
        {
            this.StartCell = startCell;
            this.Size = 0;
        }

        public Cell StartCell { get; set; }
        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            int result = other.Size.CompareTo(this.Size);
            if (result == 0)
            {
                result = this.StartCell.Row.CompareTo(other.StartCell.Row);
            }
            if (result == 0)
            {
                result = this.StartCell.Col.CompareTo(other.StartCell.Col);
            }

            return result;
        }
    }
}
