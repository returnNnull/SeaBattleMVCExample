namespace SeaBatleExample;

public class Ship
{
    private List<Cell> _cells = new ();
    private int count;


    public Cell GetCell(int x, int y)
    {
        return _cells.Find(c => c.X == x && c.Y == y);
    }
    public void Open(int x, int y)
    {
        var cell = GetCell(x, y);
        if (!cell.IsEmpty)
        {
            count++;
        }
        cell.IsOpen = true;
    }
    
    public void  AddCell(Cell cell)
    {
        _cells.Add(cell);
    }

    public bool IsDead()
    {
        return count == _cells.Count;
    }
}