using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _Idea
{
    class Idea
    {
        public void Bubblesort(ListBox lst_Code)
        {
            lst_Code.Items.Add("- Xuất phát từ cuối dãy, đổi chỗ các cặp phần tử kế cận để đưa phần tử nhỏ hơn trong cặp phần tử đó về vị trí đúng dãy hiện hành, sau đó sẽ không xét đến nó ở bước tiếp theo, do vậy ở lần xử lý thứ i sẽ có vị trí đầu dãy là i.");
            lst_Code.Items.Add("- Lặp lại xử lý trên cho đến khi không còn cặp phần tử nào để xét.");
        }

        public void Quicksort(ListBox lst_Code)
        {
            lst_Code.Items.Add("- Giải thuật Quicksort sắp xếp dãy a1,a2,...,aN dựa trên việc phân hoạch dãy ban đầu thành 3 phần");
            lst_Code.Items.Add("    + Phần 1: Gồm các phần tử có giá trị bé hơn x");
            lst_Code.Items.Add("    + Phần 2: Gồm các phần tử có giá trị bằng x");
            lst_Code.Items.Add("    + Phần 3: Gồm các phần tử có giá trị lớn hơn x");
            lst_Code.Items.Add("\n* với x là giá trị một phần tử tùy ý trong dãy ban đầu");
            lst_Code.Items.Add("\n- Sau khi phân hoạch xong ta đã có 3 dãy:");
            lst_Code.Items.Add("Dãy 1 có giá trị bé hơn x => chưa được sắp xếp");
            lst_Code.Items.Add("Dãy 2 có giá trị bằng x => đã sắp xếp");
            lst_Code.Items.Add("Dãy 3 có giá trị lớn hơn x => chưa được sắp xếp");
            lst_Code.Items.Add("\n- Cuối cùng ta chỉ cần thực hiện sắp xếp tương tự cho dãy 1 và dãy 3 đến khi tất cả các dãy con đều đã sắp xếp xong chúng ta ghép lần lượt các dãy lại với nhau theo thứ tự");
        }

    }
}