using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;

namespace ToDoListApp
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable toDoList = new DataTable();
        bool isEditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            // Create Columns
            toDoList.Columns.Add("Task");

            // Point datagridview to our datasource
            toDoListView.DataSource = toDoList;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // fill text fields with data from table
            taskTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void taskTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isEditing)
                {
                    toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Task"] = taskTextBox.Text;
                }
                else
                {
                    toDoList.Rows.Add(taskTextBox.Text);
                    taskTextBox.Text = "";
                }
            }
        }
    }
}
