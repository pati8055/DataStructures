using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithms.LinkedList
{
    public class LinkedListHelper
    {
        public static Node ReverseList(Node head)
        {
            if (head == null)
            {
                return head;
            }

            Node prev = null;
            Node current = head;

            while (current != null)
            {
                Node nextTemp = current.next;
                current.next = prev;
                prev = current;
                current = nextTemp;
            }
            return prev;
        }

        public static bool IsPalindrome(Node head)
        {
            if (head == null)
            {
                return false;
            }

            Node current = head;
            List<int> values = new List<int>();
            while (current != null)
            {
                values.Add(current.value);
                current = current.next;
            }

            int start = 0;
            int end = values.Count - 1;

            while(start < end)
            {
                if (values[start] != values[end])
                {
                    return false;
                }
                start++;
                end--;
            }

            return true;
        }
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

        public static Node AddTwoNumbers(Node l1, Node l2)
        {
            Node dummyHead = new Node(0);
            Node current = dummyHead;
            int carry = 0;

            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            while (l1 != null || l2 != null)
            {
                int val1 = l1 == null ? 0 : l1.value;
                int val2 = l2 == null ? 0 : l2.value;

                int sum = val1 + val2 + carry;
                carry = sum / 10;// Division gives firstNumber number i..e, 13/10 => 1 
                var newNode = new Node(sum % 10); // MOD gives last number i..e, 13%10 => 3
                current.next = newNode;
                current = current.next;

                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }
               
            }

            if (carry > 0)
            {
                var newNode = new Node(carry);
                current.next = newNode;
            }


            return dummyHead.next;
        }

        public static Node MergeTwoLists(Node l1, Node l2)
        {
            var dummyNode = new Node(0);
            Node previous = dummyNode;

            if (l1 == null && l2 == null)
                return null;

            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }

            while (l1 != null && l2 != null)
            {
                if (l1.value >= l2.value)
                {
                    previous.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    previous.next = l1;
                    l1 = l1.next;
                }

                previous = previous.next;
            }
            previous.next = l1 == null ? l2 : l1;

            return dummyNode.next;
        }

       
    }
}
