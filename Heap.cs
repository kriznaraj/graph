using System;
using System.Collections.Generic;
using System.Linq;

namespace graph
{
	public class Heap<T> where T:IComparable<T>
	{
		private List<T> heap;
		private int size;

		public Heap(IEnumerable<T> arr)
		{
			heap = arr.ToList();
			size = heap.Count();
			buildHeap();
		}

		public List<T> GetHeap()
		{
			return heap;
		}

		public void Add(T data)
		{
			heap.Add(data);
			size++;
			upLift(size-1);
		}

		public T HeapTop() 
		{
			if(size <= 0)
				throw new Exception("Heap is empty");
			
			return heap[0];
		}

		public T PopHeapTop()
		{
			var x = HeapTop();
			swap(0, size-1);
			heap.RemoveAt(size-1);
			size--;
			heapify(0);
			return x;
		}

		private void buildHeap()
		{
			for (int i = (size-1)/2; i >= 0; i--)
			{
				heapify(i);
			}
		}

		private int left(int n)
		{
			return 2*n +1;
		}

		private int right(int n)
		{
			return 2*n +2;
		}

		private int parent(int n)
		{
			return (n-1)/2;
		}

		private void swap(int p1, int p2)
		{
			var t = heap[p1];
			heap[p1] = heap[p2];
			heap[p2] = t;
		}

		private int minChild(int pos)
		{
			var l = left(pos);
			var r = right(pos);
			if(r < size) //both child
			{
				return heap[l].CompareTo(heap[r]) <= 0 ? l : r;
			}
			if (l < size) //only left child
			{
				return l;
			}
			return -1;
		}

		private void heapify(int pos) 
		{
			var mc = minChild(pos);

			if(mc != -1 && heap[pos].CompareTo(heap[mc]) > 0)
			{
				swap(pos, mc);
				heapify(mc);
			}
		}

		private void upLift(int pos)
		{
			var p = parent(pos);
			if(heap[pos].CompareTo(heap[p]) < 0)
			{
				swap(pos, p);
				upLift(p);
			}
		}
	}
}