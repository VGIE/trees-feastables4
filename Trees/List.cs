namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        return m_numItems;
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        ListNode<T> node = First;
        int aux = 0;

        if (Count() < index)
        {
            return default;
        }
        else
        {
            while (aux < index)
            {
                node = node.Next;
                aux++;
            }
            return node.Value;
        }
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        if (First == null)
        {
            First = new ListNode<T>(value);
            Last = First;
            m_numItems++;
        }
        else
        {
            Last.Next = new ListNode<T>(value);
            Last = Last.Next;
            m_numItems++;
        }
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> node = First;
        T removedValue = default(T);

        if (index < 0 || index >= Count() || First == null)
        {
            return default;
        }
        else if (index == 0)
        {
            removedValue = First.Value;
            First = First.Next;
            m_numItems--;

            if (Count() == 0)
            {
                Last = null;
            }

            return removedValue;
        }
        else
        {
            ListNode<T> anterior = First;
            for (int i = 0; i < index - 1; i++)
            {
                anterior = anterior.Next;
            }

            ListNode<T> toRemove = anterior.Next;
            removedValue = toRemove.Value;
            anterior.Next = toRemove.Next;

            if (toRemove == Last)
            {
                Last = anterior;
            }

            m_numItems--;
            return removedValue;
        }
        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        while (First != null)
        {
            ListNode<T> node = First;
            First = First.Next;
            node = null;
        }
        m_numItems = 0;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list

        if (First == null)
        {
            yield return null;
        }
        else
        {
            ListNode<T> node = First;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
        
    }
}