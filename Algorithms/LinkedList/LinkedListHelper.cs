using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedList
{
    public class LinkedListHelper
    {
        public static void RemoveKthNodeFromEnd(Node head, int k)
        {
            if (head == null || head.next == null)
            {
                return;
            }

            Node fast = head;
            Node slow = head;
            int counter = 1;

            while (counter <= k)
            {
                fast = fast.next;
                counter++;
            }

            if (fast == null)
            {
                head.value = head.next.value;
                head.next = head.next.next;
                return;
            }

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;           
        }

        public static bool HasCycle(Node head)
        {
            if (head == null)
            {
                return false;
            }
            Node fast = head;
            Node slow = head;
            bool hasCycle = false;

            while ( fast != null && fast.next != null && slow != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    hasCycle = true;
                    break;
                }
            }
            return hasCycle;
        }

        public static Node ReverseLinkedList(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            
            Node previous = null, current = head, next = null;

            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            return previous;
        }

        // Watch Algoexp - Mathematical formula
        public static Node FindLoop(Node head)
        {
            Node slow = head.next;
            Node fast = head.next.next;

            while (fast != slow)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            slow = head;

            while (slow != fast)
            {
                fast = fast.next;
                slow = slow.next;
            }

            return slow;
        }
    }
}
