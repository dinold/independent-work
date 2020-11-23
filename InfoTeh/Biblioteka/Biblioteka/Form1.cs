using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Biblioteka
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        const string Knigi = "Книги";
        const string Chit = "Читатели";
        const string Vidacha = "Выдали";
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-IVC6MV0\SQLEXPRESS;Initial Catalog=BazaBiblio;User ID=admin;Password=123qwe");
        }


        void GetList(string tabl)
        {
            da = new SqlDataAdapter("SELECT * FROM "+ tabl +"", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, tabl);
            switch (tabl)
            {
                case Knigi:
                    dataGridView1.DataSource = ds.Tables[tabl];
                    break;
                case Chit:
                    dataGridView2.DataSource = ds.Tables[tabl];
                    break;
                case Vidacha:
                    dataGridView3.DataSource = ds.Tables[tabl];
                    break;
            }
            con.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaBiblioDataconnect.Выдали". При необходимости она может быть перемещена или удалена.
            this.выдалиTableAdapter.Fill(this.bazaBiblioDataconnect.Выдали);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaBiblioDataconnect.Читатели". При необходимости она может быть перемещена или удалена.
            this.читателиTableAdapter.Fill(this.bazaBiblioDataconnect.Читатели);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaBiblioDataconnect.Книги". При необходимости она может быть перемещена или удалена.
            this.книгиTableAdapter.Fill(this.bazaBiblioDataconnect.Книги);

        }

        private void Button1_Click(object sender, EventArgs e) //Добавление в таблице Книги
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Книги(Шифр,Автор,Название,Год,Количество) values (N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList(Knigi);
        }

        private void Button2_Click(object sender, EventArgs e) //Удаление в таблице Книги
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Книги WHERE Шифр= N'" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList(Knigi);
        }

        private void Button4_Click(object sender, EventArgs e) //Добавление в таблице Читатели
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Читатели(Билет,Фамилия,Имя,Отчество,Адрес) values (N'" + textBox6.Text + "',N'" + textBox7.Text + "',N'" + textBox8.Text + "',N'" + textBox9.Text + "',N'" + textBox10.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList(Chit);
        }

        private void Button3_Click(object sender, EventArgs e) //Удаление в таблице Читатели
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Читатели WHERE Билет= N'" + textBox6.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList(Chit);
        }

        private void Button6_Click(object sender, EventArgs e) //Добавление в таблице Выданные книги
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd.MM.yyyy";
            DateTime vid = DateTime.ParseExact(textBox13.Text, format, provider);
            DateTime vozvr = DateTime.ParseExact(textBox14.Text, format, provider);
            DateTime fact = DateTime.ParseExact(textBox15.Text, format, provider);


            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Выдали(Шифр,Билет,Выдача,Возврат,Факт) values (N'" + textBox11.Text + "',N'" + textBox12.Text + "','" + vid + "','" + vozvr + "','" + fact + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList(Vidacha);
        }

        private void Button5_Click(object sender, EventArgs e) //Удаление в таблице Выданные книги
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Выдали WHERE Шифр= N'" + textBox11.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            GetList(Chit);
        }
    }
}
