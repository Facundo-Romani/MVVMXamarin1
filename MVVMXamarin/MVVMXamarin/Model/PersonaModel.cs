using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMXamarin.Model
{
    public class PersonaModel:INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private bool isBusy=false;

        public bool Isbusy
        {
            get { return isBusy=false; }
            set { isBusy=value;
                OnPropertyChanged();
            }
        }


        // PropFull. 
        private string id;
        private string nombre;
        private string apellido;
        private int edad;

        public string Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(nombreCompleto));
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(nombreCompleto));
            }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value;
                OnPropertyChanged();
            }
        }

        // PropFull para concatenar dos variables y luego hacer el Binding.

        private string nombreCompleto;

        public string NombreCompleto
        {
            get { 
                return $"{Nombre} {Apellido}"; }  // Concatenación.
            set { nombreCompleto = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(mensaje));
            }
        }

        private string mensaje;

        public string Mensaje
        {
            get { return $"Tu nombre es {nombreCompleto}"; }
        }

    }
}
