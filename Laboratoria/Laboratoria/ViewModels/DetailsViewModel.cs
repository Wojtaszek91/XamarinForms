using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Laboratoria.ViewModels
{
    class DetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _CAQI;
        public int CAQI
        {
            get => _CAQI;
            set
            {
                if (_CAQI == value)
                    return;
                _CAQI = value;
                OnPropertyChanged();
            }
        }
        private string _airQuality;
        public string airQuality { get => _airQuality;
            set
            {
                if (_airQuality == value)
                    return;
                _airQuality = value;
                OnPropertyChanged();
            }
        }
        private string _description;
        public string description {
            get => _description;
            set
            {
                if (_description == value)
                    return;
                _description = value;
                OnPropertyChanged();
            }
        }
        private int _pm25Value;
        public int pm25Value { get => _pm25Value;
            set
            {
                if (_pm25Value == value)
                    return;
                _pm25Value = value;
                OnPropertyChanged();
            }
        }
        private int _pm25Percent;
        public int pm25Percent { get => _pm25Percent;
            set
            {
                if (_pm25Percent == value)
                    return;
                _pm25Percent = value;
                OnPropertyChanged();
            }
        }
        private int _pm10Value;
        public int pm10Value { get => _pm10Value;
            set
            {
                if (_pm10Value == value)
                    return;
                _pm10Value = value;
                OnPropertyChanged();
            }
        }
        private int _pm10Percent;
        public int pm10Percent { get => _pm10Percent;
            set {
                if (_pm10Percent == value)
                    return;
                _pm10Percent = value;
                OnPropertyChanged();
                    } 
        }
        private double _humidityValue;
        public double humidityValue { get => _humidityValue;
            set 
            {
                if (_humidityValue == value)
                    return;
                _humidityValue = value;
                OnPropertyChanged();
            } 
        }
        private int _pressureValue;
        public int pressureValue
        {
            get => _pressureValue;
            set
            {
                if (_pressureValue == value)
                    return;
                _pressureValue = value;
                OnPropertyChanged();
            }
        }
    }
}
