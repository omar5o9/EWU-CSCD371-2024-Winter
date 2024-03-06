using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace GenericsHomework;


public class Node<T> : IEnumerable<Node<T>> where T : notnull
{

    public Node<T> Next { get; private set; }
    public T Data { get; }

    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public void Append(T value)
    {
        if(Exists(value))
        {
            throw new InvalidOperationException(nameof(value));
        }   
        Node<T> newNode = new(value);
        Node<T> cur = this;

        while (cur.Next != this)
        {
            cur = cur.Next;
        }

        newNode.Next = cur.Next;
        cur.Next = newNode;
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
    
    public void Clear()
    {
        // C# will automatically garbage collect the rest of the nodes
        Node<T> cur = this;
        cur.Next = this;
       

    }

    public bool Exists(T value)
    {

        Node<T> cur = this;
        while (cur.Next != this)
        {
            if (cur.Data != null && cur.Data.Equals(value))
            {
                return true;
            }
            cur = cur.Next;
        }
        return cur.Data != null && cur.Data.Equals(value);
        
        
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> current = this;
        do
        {
            yield return current;
            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<Node<T>> ChildItems(int maximum)
    {
        Node<T> current = this;
        int count = 0;
        do
        {
            yield return current;
            current = current.Next;
            count++;
        } while (current != this && count < maximum);
        
    }




}

