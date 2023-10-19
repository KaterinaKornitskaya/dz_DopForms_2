using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz_DopForms_2
{
    public partial class Form2 : Form
    {
        Tovar t;    // ссылка на товар
        bool edit;  // если true - редактируем товар,
                    // если false - добавляем новый
        public Form2(Tovar t, bool edit)
        {
            InitializeComponent();

            this.t = t;
            this.edit=edit;

            if (edit)  // если true - редактируем
            {
                // инициализируем текстбоксы полями выбранного товара
                textBoxName.Text = t.Name;
                textBoxDescript.Text = t.Description;
                textBoxPrice.Text = t.Price.ToString();
                // меняем заголовок Форм2
                this.Text = "Редактирование товара";
            }
            else
            {
                // меняем заголовок Форм2
                this.Text = "Добавление товара";
            }
        }

        // обработчик нажатия кнопки Ок
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // проверка на заполнение полей
            if(textBoxName.Text == "" || textBoxDescript.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            // присваиваем полям экземпляра Товар новые значения
            t.Name = textBoxName.Text;
            t.Description = textBoxDescript.Text;
            // для поля Цена делаем доп проверку
            try
            {
                t.Price = int.Parse(textBoxPrice.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Укажите цену цифрами! (int)");
                return;
            }
            // закрываем Форм2
            this.Close();
        }

        // обработчик события Загрузка Форм2
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Название товара";
            label2.Text = "Описание";
            label3.Text = "Цена";
        }
    }
}
