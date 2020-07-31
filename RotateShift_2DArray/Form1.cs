using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RotateShift_2DArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int biggest = 0;
        private int line = 1;
        private void Clockwise_Click(object sender, EventArgs e)
        {
            //clock
            string temp = tb1.Text;
            tb1.Text = tb4.Text;
            tb4.Text = tb7.Text;
            tb7.Text = tb8.Text;
            tb8.Text = tb9.Text;
            tb9.Text = tb6.Text;
            tb6.Text = tb3.Text;
            tb3.Text = tb2.Text;
            tb2.Text = temp;
            tbMove.Text += "顺";
        }

        private void Anticlock_Click_1(object sender, EventArgs e)
        {
            //anticlock
            string temp1 = tb1.Text;
            tb1.Text = tb2.Text;
            tb2.Text = tb3.Text;
            tb3.Text = tb6.Text;
            tb6.Text = tb9.Text;
            tb9.Text = tb8.Text;
            tb8.Text = tb7.Text;
            tb7.Text = tb4.Text;
            tb4.Text = temp1;
            tbMove.Text += "逆";
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            tb1.Text = t1.Text;
            tb2.Text = t2.Text;
            tb3.Text = t3.Text;
            tb4.Text = t4.Text;
            tb5.Text = t5.Text;
            tb6.Text = t6.Text;
            tb7.Text = t7.Text;
            tb8.Text = t8.Text;
            tb9.Text = t9.Text;
            tbMove.Text = "";
        }

        private void Up_Click(object sender, EventArgs e)
        {
            string temp1 = tb1.Text;
            tb1.Text = tb4.Text;
            tb4.Text = tb7.Text;
            tb7.Text = temp1;

            string temp2 = tb2.Text;
            tb2.Text = tb5.Text;
            tb5.Text = tb8.Text;
            tb8.Text = temp2;

            string temp3 = tb3.Text;
            tb3.Text = tb6.Text;
            tb6.Text = tb9.Text;
            tb9.Text = temp3;

            tbMove.Text += "上";
        }

        private void Bclear_Click(object sender, EventArgs e)
        {
            tb1.Text = "1";
            tb2.Text = "2";
            tb3.Text = "3";
            tb4.Text = "4";
            tb5.Text = "5";
            tb6.Text = "6";
            tb7.Text = "7";
            tb8.Text = "8";
            tb9.Text = "9";
            tbMove.Text = "";
        }
        private void PerformSingle(string single)
        {
            switch (single)
            {
                case "顺":
                    clockwise.PerformClick();
                    break;
                case "逆":
                    anticlock.PerformClick();
                    break;
                default:
                    up.PerformClick();
                    break;
            }
        }
        private void Perform(string record)
        {
            for (int i = 0; i < record.Length; i++)
            {
                string temp = record.Substring(i, 1);
                PerformSingle(temp);
            }
        }
        /*
         * 逆逆逆上逆逆逆上上逆逆逆上逆逆逆上上-------->1、5、8进行了顺时针三轮换；
           顺顺顺上顺顺顺上上顺顺顺上顺顺顺上上-------->3、5、8进行了逆时针三轮换；
           逆逆逆上上逆逆逆上逆逆逆上上逆逆逆上-------->2、5、9进行了顺时针三轮换；
           顺顺顺上上顺顺顺上顺顺顺上上顺顺顺上-------->2、5、7进行了逆时针三轮换； 
         */

        private void BtnPerform_Click(object sender, EventArgs e)
        {
            switch (tbformula.Text)
            {
                case "158顺":
                    Perform("逆逆逆上逆逆逆上上逆逆逆上逆逆逆上上");
                    break;
                case "158逆":
                    Perform("上顺顺顺上上顺顺顺上顺顺顺上上顺顺顺");
                    break;
                case "358顺":
                    Perform("上逆逆逆上上逆逆逆上逆逆逆上上逆逆逆");
                    break;
                case "358逆":
                    Perform("顺顺顺上顺顺顺上上顺顺顺上顺顺顺上上");
                    break;
                case "259顺":
                    Perform("逆逆逆上上逆逆逆上逆逆逆上上逆逆逆上");
                    break;
                case "259逆":
                    Perform("上上顺顺顺上顺顺顺上上顺顺顺上顺顺顺");
                    break;
                case "257顺":
                    Perform("上上逆逆逆上逆逆逆上上逆逆逆上逆逆逆");
                    break;
                case "257逆":
                    Perform("顺顺顺上上顺顺顺上顺顺顺上上顺顺顺上");
                    break;
            }
        }

        private void BtnUno_Click(object sender, EventArgs e)
        {
            string temp = tbMove.Text;
            if (temp.Length == 0)
                return;
            switch (temp.Substring(temp.Length - 1, 1))
            {
                case "顺":
                    Perform("逆");
                    tbMove.Text = tbMove.Text.Substring(0, tbMove.Text.Length - 2);
                    break;
                case "逆":
                    Perform("顺");
                    tbMove.Text = tbMove.Text.Substring(0, tbMove.Text.Length - 2);
                    break;
                case "上":
                    Perform("上上");
                    tbMove.Text = tbMove.Text.Substring(0, tbMove.Text.Length - 3);
                    break;
            }
            return;
        }

        private void BtnUndoMacro_Click(object sender, EventArgs e)
        {
            switch (tbformula.Text)
            {
                case "158顺":
                case "358逆":
                case "259顺":
                case "257逆":
                case "158逆":
                case "358顺":
                case "259逆":
                case "257顺":
                    for (int i = 0; i < 18; i++)
                        BtnUno.PerformClick();
                    break;

            }
        }

        private void Permutation(int[] a, int width, int height, int cur)
        {  //
            if (cur == width * height)
            {

                int now = Cal9sum(a, width, height);
                int big = Convert.ToInt32(TBBiggest.Text);
                if (TBBiggest.Text == "-1" && now > biggest&&line<=100)
                {
                    biggest = now;
                    tbMove.Text += (line++) + " " + now + ":";
                    {
                        for (int i = 0; i < width * height - 1; i++)
                            tbMove.Text += a[i] + ",";
                    }
                    tbMove.Text += a[width * height - 1] + "\r\n";
                }
                else if (TBBiggest.Text != "-1" && now == Convert.ToInt32(TBBiggest.Text))
                {
                    tbMove.Text += (line++) + " " + now + ":";
                    {
                        for (int i = 0; i < width * height - 1; i++)
                            tbMove.Text += a[i] + ",";
                    }
                    tbMove.Text += a[width * height - 1] + "\r\n";
                }
            }
            else for (int i = 1; i <= width * height; i++)
                {  //从小到大尝试在a[cur]中填各种整数i 
                    int ok = 1;
                    for (int j = 0; j < cur; j++)
                    {
                        if (a[j] == i) ok = 0;  //如果i已经在a[0]~a[cur-1]出现过，则不可再选 
                    }
                    if (ok == 1)
                    {
                        a[cur] = i;
                        Permutation(a, width, height, cur + 1);  //递归调用 
                    }
                }
        }

        private int Cal9sum(int[] a, int width, int height)
        {
            int[] arr = new int[width * height];
            arr[a[0] - 1] = 1;
            for (int i = 1; i < width * height; i++)
            {
                arr[a[i] - 1] = CalNext(arr, a[i] - 1, width, height);
            }
            return arr[a[width * height - 1] - 1];
        }

        /// <summary>
        /// 上下左右中：01234，左上20，右上30，坐下21，右下21.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private int GetPosition(int index, int width, int height)
        {
            if (index == 0)
                return 20;
            if (index == width - 1)
                return 30;
            if (index == width * (height - 1))
                return 21;
            if (index == width * height - 1)
                return 31;

            if (index < width)
                return 0;
            if (index > width * (height - 1))
                return 1;
            if (index % width == 0)
                return 2;
            if (index % width == width - 1)
                return 3;

            return 4;
        }

        /// <summary>
        /// 上下左右中：01234，左上20，右上30，坐下21，右下21.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private int CalNext(int[] arr, int index, int width, int height)
        {
            switch (GetPosition(index, width, height))
            {
                case 20:
                    return arr[index + 1] + arr[index + width] + arr[index + width + 1];
                case 30:
                    return arr[index - 1] + arr[index + width] + arr[index + width - 1];
                case 21:
                    return arr[index + 1] + arr[index - width] + arr[index - width + 1];
                case 31:
                    return arr[index - 1] + arr[index - width] + arr[index - width - 1];
                case 0:
                    return arr[index - 1] + arr[index + 1] + arr[index + width] + arr[index + width - 1] + arr[index + width + 1];
                case 1:
                    return arr[index - 1] + arr[index + 1] + arr[index - width] + arr[index - width - 1] + arr[index - width + 1];
                case 2:
                    return arr[index + 1] + arr[index + width] + arr[index + width + 1] + +arr[index - width] + arr[index - width + 1];
                case 3:
                    return arr[index - 1] + arr[index + width] + arr[index + width - 1] + +arr[index - width] + arr[index - width - 1];
                case 4:
                    return arr[index + width] + arr[index + width - 1] + arr[index + width + 1]
                        + arr[index - 1] + arr[index + 1]
                        + arr[index - width] + arr[index - width - 1] + arr[index - width + 1];
            }
            return 0;

        }

        private void BtnBiggest_Click(object sender, EventArgs e)
        {
            tbMove.Text = "";
            biggest = 0;
            line = 1;
            int width = Convert.ToInt32(TBWidth.Text);
            int height = Convert.ToInt32(TBHeight.Text);
            int[] a = new int[width * height];
            Permutation(a, width, height, 0);
        }
    }
}
