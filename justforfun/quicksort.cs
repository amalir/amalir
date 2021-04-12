using System;
using System.Linq;
using System.Collections.Generic;

class MainClass {

  static List < int > arr;

  public static void Main(string[] args) {

    arr = Sort(new List < int > (new int[] {
      12,
      13,
      14,
      25,
      14,
      14,
      78,
      12,
      34,
      124,
      16
    }));
    Vypis();

  }

  static List < int > Sort(List < int > arr) {

    List < int > left = new List < int > (), right = new List < int > ();
    int mx = arr.Count - 1, pivot = arr[mx];

    for (int i = 0; i < mx; i++) {
      if (arr[i] > pivot) right.Add(arr[i]);
      else left.Add(arr[i]);
    }

    left = (left.Count > 0) ? Sort(left) : left;
    right = (right.Count > 0) ? Sort(right) : right;

    left.Add(pivot);
    left.AddRange(right);

    return left;

  }

  static void Vypis() {

    foreach(int i in arr) 
      Console.Write(i + " ");
    Console.WriteLine("");

  }
}
