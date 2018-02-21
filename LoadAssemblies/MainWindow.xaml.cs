using LoadAssemblyHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace LoadAssemblies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var files = Directory.GetFiles(".", "G9PX_*.dll");
            string where = Directory.GetCurrentDirectory();

           

            AppDomain ad = AppDomain.CreateDomain("TestDomain1");
            ITypeFinder tt = (ITypeFinder)ad.CreateInstanceFromAndUnwrap(where + "/" + "LoadAssemblyHelpers.dll", "LoadAssemblyHelpers.TypeFinder");
            //ITypeFinder tz = (ITypeFinder)ad.CreateInstanceAndUnwrap("LoadAssemblyHelpers.dll", "LoadAssemblyHelpers.TypeFinder");

            //ad.

            string result = tt.WhatAmI();
            string otherResult = tt.WhereAmI();

            foreach (string file in files)
            {
                var item = Assembly.LoadFile(where + "/" + file);

                System.Type[] stuff = item.GetExportedTypes();
                MyTestInterface myObject = (MyTestInterface)Activator.CreateInstance(stuff[0]);

                string name = myObject.TestMethod();

                //var otherItem = Assembly.LoadFrom(file);


            }
        }
    }
}
