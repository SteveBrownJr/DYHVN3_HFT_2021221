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
        #region Stations
        public RestCollection<Station> Stations { get; set; }
        private Station selectedStation;
        private Station stationUnderUpdate;
        private string nonCRUDOuput;
        public string NonCRUDOuput
        {
            get
            {
                return nonCRUDOuput;
            }
            set
            {
                SetProperty(ref nonCRUDOuput, value);
            }
        }

        public Station StationUnderUpdate
        {
            get
            {
                return stationUnderUpdate;
            }
            set
            {
                SetProperty(ref stationUnderUpdate, value);
            }
        }
        public Station SelectedStation { get
            {
                return selectedStation;
            }
            set
            {
                if (value!=null)
                {
                    SetProperty(ref selectedStation, value);
                    StationUnderUpdate = new Station()
                    {
                        Station_Id=selectedStation.Station_Id,
                        Locomotive_Id=selectedStation.Locomotive_Id,
                        Name=selectedStation.Name,
                        x_cordinate=selectedStation.x_cordinate,
                        y_cordinate=selectedStation.y_cordinate
                    };
                }
                (DeleteStationCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand CreateStationCommand { get; set; }

        public ICommand UpdateStationCommand { get; set; }

        public ICommand DeleteStationCommand { get; set; }
        #endregion
        #region Wagons
        public RestCollection<Wagon> Wagons { get; set; }

        private Wagon wagonUnderUpdate;
        public Wagon WagonUnderUpdate
        {
            get
            {
                return wagonUnderUpdate;
            }
            set
            {
                SetProperty(ref wagonUnderUpdate, value);
            }
        }

        private Wagon selectedWagon;
        public Wagon SelectedWagon 
        { 
            get 
            {
                return selectedWagon;
            } 
            set
            {
                if (value!=null)
                {
                    SetProperty(ref selectedWagon, value);
                    WagonUnderUpdate = new Wagon()
                    {
                        Locomotive_Id=selectedWagon.Locomotive_Id,
                        Quantity= selectedWagon.Quantity,
                        CargoType= selectedWagon.CargoType,
                        Wagon_Id= selectedWagon.Wagon_Id
                    };
                }
                (DeleteWagonCommand as RelayCommand).NotifyCanExecuteChanged();
            } 
        }
        public ICommand CreateWagonCommand { get; set; }

        public ICommand UpdateWagonCommand { get; set; }

        public ICommand DeleteWagonCommand { get; set; }
        #endregion
        #region Locomotives
        public RestCollection<Locomotive> Locomotives { get; set; }
        public ICommand CreateLocomotiveCommand { get; set; }
        
        public ICommand UpdateLocomotiveCommand { get; set; }
        
        public ICommand DeleteLocomotiveCommand { get; set; }
        
        private Locomotive locomotiveUnderUpdate;
        public Locomotive LocomotiveUnderUpdate
        {
            get
            {
                return locomotiveUnderUpdate;
            }
            set
            {
                SetProperty(ref locomotiveUnderUpdate, value);
            }
        }
        private Locomotive selectedLocomotive;
        public Locomotive SelectedLocomotive 
        { 
            get 
            { 
                return selectedLocomotive; 
            } 
            set 
            {
                if (value!=null)
                {
                    SetProperty(ref selectedLocomotive, value);
                    LocomotiveUnderUpdate = new Locomotive()
                    {
                        Staff = selectedLocomotive.Staff,
                        Starting_Torque = selectedLocomotive.Starting_Torque,
                        Name = selectedLocomotive.Name,
                        Type = selectedLocomotive.Type,
                        Locomotive_Id= selectedLocomotive.Locomotive_Id
                    };
                }
                (DeleteLocomotiveCommand as RelayCommand).NotifyCanExecuteChanged();
            } 
        }
        #endregion
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
                Wagons = new RestCollection<Wagon>("http://localhost:38193/", "Wagon", "hub");
                Stations = new RestCollection<Station>("http://localhost:38193/", "Station", "hub");
                
                #region LocomotiveCommandDefinitions
                CreateLocomotiveCommand = new RelayCommand(() =>
                {
                    Locomotives.Add(new Locomotive()
                    {
                        Name = LocomotiveUnderUpdate.Name,
                        Staff = LocomotiveUnderUpdate.Staff,
                        Starting_Torque = LocomotiveUnderUpdate.Starting_Torque,
                        Type = LocomotiveUnderUpdate.Type,
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

                UpdateLocomotiveCommand = new RelayCommand(()=>
                {
                    Locomotives.Update(LocomotiveUnderUpdate);
                });
                #endregion

                #region WagonCommandDefinitions
                CreateWagonCommand = new RelayCommand(() =>
                {
                    Wagons.Add(new Wagon()
                    {
                        CargoType=WagonUnderUpdate.CargoType,
                        Quantity= WagonUnderUpdate.Quantity,
                        Locomotive_Id= WagonUnderUpdate.Locomotive_Id
                    }
                    );
                });

                DeleteWagonCommand = new RelayCommand(() =>
                {
                    Wagons.Delete(SelectedWagon.Wagon_Id);
                },
                () =>
                {
                    return SelectedWagon != null;
                }
                );

                UpdateWagonCommand = new RelayCommand(() =>
                {
                    Wagons.Update(WagonUnderUpdate);
                });
                #endregion

                #region StationCommandDefinitions
                CreateStationCommand = new RelayCommand(() =>
                {
                    Stations.Add(new Station()
                    {
                        Name=StationUnderUpdate.Name,
                        x_cordinate = StationUnderUpdate.x_cordinate,
                        y_cordinate= StationUnderUpdate.y_cordinate,
                        Locomotive_Id=StationUnderUpdate.Locomotive_Id
                    }
                    );
                });

                DeleteStationCommand = new RelayCommand(() =>
                {
                    Stations.Delete(SelectedStation.Station_Id);
                },
                () =>
                {
                    return SelectedStation != null;
                }
                );

                UpdateStationCommand = new RelayCommand(() =>
                {
                    Stations.Update(StationUnderUpdate);
                });
                #endregion

            }

            selectedLocomotive = new Locomotive();
            selectedWagon = new Wagon();
            selectedStation = new Station();
        
        }
    }
}
