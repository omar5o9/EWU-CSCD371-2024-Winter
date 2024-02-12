namespace GenericsHomework;

public class Node<T>
{

    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public void Append(T value)
    {
        Node<T> newNode = new(value);
        Node<T> cur = this;

        while (cur.Next != this)
        {
            newNode.Next = cur.Next;
            cur.Next = newNode;
        }
    }

    public override string ToString()
    {
        Node<T> cur = this;
        string result = "";
        while (cur.Next != this)
        {
            result += cur.Data + " -> ";
            cur = cur.Next;
        }
        result += cur.Data;
        return result;
    }

}

