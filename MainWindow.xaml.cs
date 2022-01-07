using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    /// Для участия в конкурсе на замещение вакантной
    //    должности сотрудника предприятия желающие
    //подают информацию:
    //■Ф.И.О.;
    //■год рождения;
    //■образование(среднее, среднее специальное,
    //высшее);
    //■знание иностранных языков(английский,
    //немецкий, французский; владею свободно, читаю и
    //перевожу со словарем);
    //■владение компьютером;
    //■стаж работы;
    //■наличие рекомендаций;
    //    Создайте приложение, которое должно
    //    позволять выводить информацию о тех, кто подал
    //    заявку на участие в конкурсе с учетом вывода всех
    //или выбора по каким-то характеристикам(выберите
    //самостоятельно).
    //При разработке приложения необходимо
    //использовать ресурсы, стили.
    //Задание 2(дополнительное) При создании приложения
    //создайте несколько окон для вывода необходимой
    //информации, в зависимости от выбора просмотра


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var editableCollectionView = itemsControl.Items as IEditableCollectionView;
            if (!editableCollectionView.CanAddNew)
            {
                MessageBox.Show("Вы не можете добавлять элементы в список.");
                return;
            }
            var win = new newWorksheet { DataContext = editableCollectionView.AddNew() };
            if ((bool)win.ShowDialog())
            {
                editableCollectionView.CommitNew();
                itemsControl.Items.Refresh();
            }
            else
            {
                editableCollectionView.CancelNew();
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (itemsControl.SelectedItem == null)
            {
                MessageBox.Show("Тема не выбрана");
                return;
            }
            var editableCollectionView = itemsControl.Items as IEditableCollectionView;
            var win = new newWorksheet();
            editableCollectionView.EditItem(itemsControl.SelectedItem);
            win.DataContext = itemsControl.SelectedItem;

            if ((bool)win.ShowDialog())
            {
                editableCollectionView.CommitEdit();
                itemsControl.Items.Refresh();
            }
            else
            {
                editableCollectionView.CancelEdit();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var item = itemsControl.SelectedItem as Emploee;
            if (item == null)
            {
                MessageBox.Show("Тема не выбрана");
                return;
            }
            var editableCollectionView = itemsControl.Items as IEditableCollectionView;
            if (!editableCollectionView.CanRemove)
            {
                MessageBox.Show("Вы не можете удалить элемент из списка");
                return;
            }
            if (MessageBox.Show("Ты уверен что хочешь удалить " + item.Surnaname +" "+item.FirstName, 
                "Удаление анкеты", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                editableCollectionView.Remove(itemsControl.SelectedItem);
            }
        }
    }
}
