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

  public static void Main(string[] args) {

    Vypis();
    Porovnej(arr.Length);
    Vypis();

  }

  static void Porovnej(int pocet) {

    int i = 0;
    int mx = 2 * i;

    while (i < pocet / 2) {
      mx = (arr[2 * i + 1] < arr[mx]) ? 2 * i + 1 : mx;
      if (2 * i + 2 < pocet) mx = (arr[2 * i + 2] < arr[mx]) ? 2 * i + 2 : mx;
      i++;
    }

    Prohod(mx, pocet - 1);
    pocet--;
    if (pocet != 1) Porovnej(pocet);

  }

  static void Prohod(int x, int y) {

    int c = arr[x];
    arr[x] = arr[y];
    arr[y] = c;

  }

  static void Vypis() {

    foreach(int i in arr) {
      Console.Write(i + " ");
    }
    Console.WriteLine("");

  }
}
