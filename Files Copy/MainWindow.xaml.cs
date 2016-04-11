using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Files_Copy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowseInputFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                tbxFileList.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseSource_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (System.Windows.Forms.DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                tbxSource.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseDestination_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (System.Windows.Forms.DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                tbxDestination.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxLog.Clear();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            List<string> files = new List<string>();

            foreach (string line in File.ReadAllLines(tbxFileList.Text, Encoding.UTF8))
            {
                files.Add(line);
            }

            foreach (string file in files)
            {
                File.Copy(Path.Combine(tbxSource.Text, file), Path.Combine(tbxDestination.Text, file), true);
                tbxLog.Text += Path.Combine(tbxSource.Text, file) + " copied to " + Path.Combine(tbxDestination.Text, file) + "\n\r";
            }
        }
    }
}
