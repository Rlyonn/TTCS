using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Code
{
    class Code
    {

        public void bubblesort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void BubbleSort(int a[],int n)");
            lst_Code.Items.Add("  {");
            lst_Code.Items.Add("     int i, j;");
            lst_Code.Items.Add("     for (i = 0 ; i<n-1; i++)");
            lst_Code.Items.Add("         for (j = n-1; j > i ; j --)");
            if (tang)
                lst_Code.Items.Add("            if (a[j] < a[j-1]) ");
            else
                lst_Code.Items.Add("            if (a[j] > a[j-1]) ");
            lst_Code.Items.Add("              Swap(a[j], a[j-1]);");
            lst_Code.Items.Add("  }");
            lst_Code.Items.Add("  void Swap(int &a,int &b)  {");
            lst_Code.Items.Add("           int temp = a;");
            lst_Code.Items.Add("            a = b;");
            lst_Code.Items.Add("            b=temp;");
            lst_Code.Items.Add(" }");
        }


        public void quicksort(ListBox lst_Code, Boolean tang)
        {
            lst_Code.Items.Add("void QuickSort(int a[], int left, int right)");
            lst_Code.Items.Add("{");
            lst_Code.Items.Add("            int i, j, x;");
            lst_Code.Items.Add("            x = a[(left + right) / 2]; ");
            lst_Code.Items.Add("            i = left; j = right;");
            lst_Code.Items.Add("               do");
            lst_Code.Items.Add("                  {");
            if (tang)
                lst_Code.Items.Add("                   while(a[i] < x) i++;");
            else
                lst_Code.Items.Add("                   while(a[i] > x) i++;");
            if (tang)
                lst_Code.Items.Add("                   while(a[j] > x) j--;");
            else
                lst_Code.Items.Add("                   while(a[j] < x) j--;");

            lst_Code.Items.Add("                       if(i <= j)");
            lst_Code.Items.Add("                         { ");
            lst_Code.Items.Add("                           Swap(a[i], a[j]);");
            lst_Code.Items.Add("                           i++ ; j--;");
            lst_Code.Items.Add("                         }");
            lst_Code.Items.Add("                   }");
            lst_Code.Items.Add("               while(i <= j);");
            lst_Code.Items.Add("               if(left < j)");
            lst_Code.Items.Add("                   QuickSort(a, left, j);");
            lst_Code.Items.Add("               if(i < right)");
            lst_Code.Items.Add("                   QuickSort(a, i, right);");
            lst_Code.Items.Add("}");
            lst_Code.Items.Add("  void Swap(int &a,int &b)  {");
            lst_Code.Items.Add("           int temp = a;");
            lst_Code.Items.Add("            a = b;");
            lst_Code.Items.Add("            b=temp;");
            lst_Code.Items.Add(" }");


        }
    }
}
