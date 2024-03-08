﻿using System.Collections;
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
        Node<T> currentNode = this;

        while (currentNode.Next != this)
        {
            currentNode = currentNode.Next;
        }

        newNode.Next = currentNode.Next;
        currentNode.Next = newNode;
    }

    public override string ToString()
    {
        Node<T> currentNode = this;
        string result = "";
        while (currentNode.Next != this)
        {
            result += currentNode.Data + " -> ";
            currentNode = currentNode.Next;
        }
        result += currentNode.Data;
        return result;
    }
    
    public void Clear()
    {
        // C# will automatically garbage collect the rest of the nodes
        Node<T> currentNode = this;
        currentNode.Next = this;
       

    }

    public bool Exists(T value)
    {

        Node<T> currentNode = this;
        while (currentNode.Next != this)
        {
            if (currentNode.Data != null && currentNode.Data.Equals(value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return currentNode.Data != null && currentNode.Data.Equals(value);
        
        
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

