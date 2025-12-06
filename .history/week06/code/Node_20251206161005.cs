public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // If the value is equal, do nothing (no duplicates allowed)
        if (value == Data)
        return; 

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
         // If the current node matches the value, return true
        if (value == Data)
            return true;

        if (value < Data)
        {
            // Search on the left side of the tree
            return Left != null && Left.Contains(value);
        }

        // Search on the right side of the tree
        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
         // Get heights of left and right subtrees (0 if they don't exist)
    <        int leftHeight = Left?.GetHeight() ?? 0;
            int rightHeight = Right?.GetHeight() ?? 0;

            // Height is 1 (this node) plus the larger subtree height
            return 1 + Math.Max(leftHeight, rightHeight);>
}