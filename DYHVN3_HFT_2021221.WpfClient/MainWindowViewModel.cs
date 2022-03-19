using DYHVN3_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DYHVN3_HFT_2021221.WpfClient
{
    class MainWindowViewModel : ObservableRecipient
    {
        
        public RestCollection<Locomotive> Locomotives { get; set; }
        
        public ICommand CreateLocomotiveCommand { get; set; }
        
        public ICommand UpdateLocomotiveCommand { get; set; }
        
        public ICommand DeleteLocomotiveCommand { get; set; }
        
        private Locomotive selectedLocomotive;
        
        public Locomotive SelectedLocomotive { 
            get 
            { 
                return selectedLocomotive; 
            } 
            set 
            { 
                SetProperty(ref selectedLocomotive, value);
                (DeleteLocomotiveCommand as RelayCommand).NotifyCanExecuteChanged();
            } 
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {
                Locomotives = new RestCollection<Locomotive>("http://localhost:38193/","Locomotive","hub");
            
                CreateLocomotiveCommand = new RelayCommand(() =>
                {
                    Locomotives.Add(new Locomotive()
                    {
                        Name = "NagyLeó",
                        Starting_Torque = 200,
                        Staff=2,
                        Type="V45",
                    }
                    );
                });
            
                DeleteLocomotiveCommand = new RelayCommand(() =>
                {
                    Locomotives.Delete(SelectedLocomotive.Locomotive_Id);
                },
                () => 
                {
                    return SelectedLocomotive != null; 
                }
                );
            }
    
            SelectedLocomotive = new Locomotive();
        
        }
    }
}
