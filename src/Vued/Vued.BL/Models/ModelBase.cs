using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Vued.BL.Models;

public abstract record ModelBase : INotifyPropertyChanged, IModel
{
    public int Id { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

