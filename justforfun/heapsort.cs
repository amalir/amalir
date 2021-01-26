using System;
using System.Linq;

class MainClass {

  static int[] arr = {
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
  };

  static int n = arr.Length;

  public static void Main(string[] args) {

    vypis();

    for (int x = n/2-1; x>=0; x--) {
      porovnej(x);
    }
    for (int i = n-1; i>=0; i--) {
      prohod(i,0);
      n--;
      porovnej(0);
    }

    vypis();

  }



  static void porovnej(int i) {

    int mx = i;
    if(2*i+1 < n) {
    mx = (arr[2 * i + 1] < arr[mx]) ? 2 * i + 1 : mx;
    if (2 * i + 2 < n) mx = (arr[2 * i + 2] < arr[mx]) ? 2 * i + 2 : mx; 
    }
   
    if(i!=mx) {
     prohod(mx,i);
     porovnej(mx);
    }

  }

  static void prohod(int x, int y) {

    int c = arr[x];
    arr[x] = arr[y];
    arr[y] = c;

  }

  static void vypis() {

    foreach(int i in arr) {
      Console.Write(i + " ");
    }
    Console.WriteLine("");

  }
}
