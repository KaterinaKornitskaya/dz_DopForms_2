using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace dz_DopForms_2
{
    public partial class Form1 : Form
    {
         List<Tovar> list;
        public Form1()
        {
            InitializeComponent();
        }
        
        // обработчик события Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Компьютерный магазин";
            label2.Text = "Выберите товар из списка,\n" +
                "нажмите кнопку добавить -\n" +
                "слева отобразится ваш \nсписок товаров";
            groupBox1.Text = "Корзина";
            groupBox2.Text = "Работа с товаром";
            label7.Text = "*Что бы выделить \nтовар для редактирования -\n" +
                "выберите товар из \nвыпадающего списка";
            textBoxPrice.ReadOnly = true;

            // создаем экземпляры класса Товар для возможности работы
            Tovar t1 = new Tovar("t1", "desc1", 25);
            Tovar t2 = new Tovar("t2", "desc2", 27);
            Tovar t3 = new Tovar("t3", "desc3", 32);
            // создаем список товаров
            list = new List<Tovar> { t1, t2, t3 };
            // инициализируем пункты Комбобокса товарами из списка
            foreach (var i in list)
            {
                comboBox1.Items.Add(i);
            }
           
        }

        // обработчик событий Выбран пункт комбобокса
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // если выбранный пункт комбобокса равен пункту списка
                if (i == comboBox1.SelectedIndex)
                {
                    // то выводим в текстбоксе цену этого товара
                    textBoxPrice.Text = list[i].Price.ToString();
                }
            }
               
        }

        // обработчик кнопки Добавить товар в корзину (листбокс)
        private void buttonAddGood_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // если выбранный пункт комбобокса равен пункту списка
                if (i == comboBox1.SelectedIndex)
                {
                    // добавляем товар в листбокс (корзина)
                    listBox1.Items.Add(list[i]);
                }
            }
            Sum();  // вызов метода Сумма всех заказов в корзине
        }

        // обработчик кнопки Добавить новый товар
        private void buttonForm2_Click(object sender, EventArgs e)
        {
            // создаем новй экземпляр товара
            Tovar t = new Tovar();
            // создаем экземпляр Форм2, передаем товар, false
            // значит вызвать Форм2 с особенностями добавления товара
            Form2 f2 = new Form2(t, false);
            // вызов форм2
            f2.ShowDialog();
            // добавляем товар в список Лист и в комбобокс
            list.Add(t);
            comboBox1.Items.Add(t);
        }

        // обработчик кнопки Редактировать товар
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // проверка, выбран ли товар в комбобокс
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали товар");
                return;
            }
           
            // запоминаем выбранный товар
            int n = comboBox1.SelectedIndex;
            // приводим выделенную строку к типу Tovar
            Tovar t = (Tovar)comboBox1.Items[n];
            // создаем экземпляр Форм2, передаем товар,  true
            // значит вызвать Форм2 с особенностями редактирования товара
            Form2 f2 = new Form2(t, true);
            // вызов Форм2
            f2.ShowDialog();
            // удаляем из комбобокс выделенный товар
            comboBox1.Items.RemoveAt(n);
            // вставляем в комбобокс в прежнее место новый товар
            comboBox1.Items.Insert(n, t);
        }

      
        // метод для суммирования цены товаров, добавленных в корзину (листбокс)
        public void Sum()
        {
            int sum = 0;  // сумма всех товаров в корзине
            for(int i = 0; i < listBox1.Items.Count; i++)  // листбокс - это корзина
            {
                // преобразуем строку листбокса к типу Tovar t и берем поле Цена
                Tovar t = (Tovar)listBox1.Items[i];
                // суммируем цену
                sum += t.Price;  
            }
            // выводи цену в лейбле Всего
            labelTotalPrice.Text = sum.ToString();
        }
    }
}
